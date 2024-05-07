using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
using SubjectTracker.Command;
using SubjectTracker.GitSaves;
using SubjectTracker.Models;

namespace SubjectTracker.ViewModel;

public class ViewModelMain : ViewModelBase
{
    readonly DataBase.DataBase db;

    AddedSubject addedSubject;

    ICommand? addSubject;

    ICommand? changeConIndex;

    ICommand? changeCurIndex;

    ICommand? changeSubject;

    ICommand? changeWorkIndex;

    ICommand? deleteSubject;

    ICommand? loadFile;

    ICommand? openLabs;

    ICommand? openPra;

    ICommand? openUpdatePanel;

    TableSubject selectedSubject;

    Works selectedWorks;

    string selectionTypeWork;

    BindingList<TableSubject> tableWithSubject;

    BindingList<Works> tableWithWorks;

    TableSubject updatedSubject;

    ICommand? uploadFile;

    ViewModelVisibility visibility;

    public ViewModelMain()
    {
        tableWithSubject = [];
        tableWithWorks = [];
        addedSubject = new();
        db = new();
        Changes = [];
        Git = new();
        visibility = new();
        db.Initialize();
        ReadingSubjectDB();
    }

    public Git Git { get; set; }

    public List<string> Changes { get; set; }

    public string SelectionTypeWork
    {
        get => selectionTypeWork;
        set => SetProperty(ref selectionTypeWork, value);
    }

    public ViewModelVisibility Visibility
    {
        get => visibility;
        set => SetProperty(ref visibility, value);
    }

    public ICommand AddSubject
    {
        get
        {
            return addSubject ??= new RelayCommand(obj =>
            {
                string name = AddedSubject.Name.Replace("'", "");
                if (name != string.Empty)
                {
                    if (!int.TryParse(AddedSubject.CountLab, out int countLab))
                    {
                        countLab = 0;
                    }

                    if (!int.TryParse(AddedSubject.CountPra, out int countPra))
                    {
                        countPra = 0;
                    }

                    if (db.AddSubject(name, countLab, countPra, AddedSubject.BoolCon, AddedSubject.BoolCur))
                    {
                        int con = AddedSubject.BoolCon ? 1 : 0;
                        int cur = AddedSubject.BoolCur ? 1 : 0;
                        Changes.Add("ADD " + name + " " + countLab + " " + countPra + " " + con + " " + cur);
                        TableWithSubject.Add(new(name, countLab, countPra, con, cur));
                    }
                    else
                    {
                        MessageBox.Show("Такой предмет уже есть");
                    }
                }
                else
                {
                    MessageBox.Show("Вы не ввели имя");
                }
            });
        }
    }

    public ICommand DeleteSubject
    {
        get
        {
            return deleteSubject ??= new RelayCommand(obj =>
            {
                db.DeleteSubject(UpdatedSubject.Name);
                Changes.Add("DELETE " + SelectedSubject.Name);
                Visibility.WorkPanelVisibility = System.Windows.Visibility.Collapsed;
                Visibility.WorkPanel = new(0, GridUnitType.Pixel);
                visibility.UpdatePanelVisibility = System.Windows.Visibility.Collapsed;
                ReadingSubjectDB();
            });
        }
    }

    public AddedSubject AddedSubject
    {
        get => addedSubject;
        set => SetProperty(ref addedSubject, value);
    }

    public TableSubject SelectedSubject
    {
        get => selectedSubject;
        set => SetProperty(ref selectedSubject, value);
    }

    public TableSubject UpdatedSubject
    {
        get => updatedSubject;
        set => SetProperty(ref updatedSubject, value);
    }


    public Works SelectedWorks
    {
        get => selectedWorks;
        set => SetProperty(ref selectedWorks, value);
    }

    public BindingList<TableSubject> TableWithSubject
    {
        get => tableWithSubject;
        set => SetProperty(ref tableWithSubject, value);
    }

    public BindingList<Works> TableWithWorks
    {
        get => tableWithWorks;
        set => SetProperty(ref tableWithWorks, value);
    }

    public ICommand ChangeCurIndex
    {
        get
        {
            return changeCurIndex ??= new RelayCommand(obj =>
            {
                db.UpdateConCur(SelectedSubject.IndexCur, SelectedSubject.Name, "cur_stage");
                Changes.Add("UPDATE C " + SelectedSubject.IndexCur + " " + SelectedSubject.Name + " " + "cur_stage");
            });
        }
    }

    public ICommand LoadFile
    {
        get
        {
            return loadFile ??= new RelayCommand(obj =>
            {
                var dialog = new OpenFileDialog
                {
                    FileName = "Document",
                    DefaultExt = ".pdf",
                    Filter = "Text documents (.pdf)|*.pdf"
                };

                bool? result = dialog.ShowDialog();

                if (result == true)
                {
                    string filename = dialog.FileName;
                    byte[] file;
                    using (var stream = new FileStream(filename, FileMode.Open, FileAccess.Read))
                    {
                        using var reader = new BinaryReader(stream);
                        file = reader.ReadBytes((int)stream.Length);
                    }

                    db.LoadFile(SelectedSubject.Name, SelectedWorks.Number,
                        SelectionTypeWork, file);
                }

                ReadingWorkDB(SelectionTypeWork);
            });
        }
    }

    public ICommand UploadFile
    {
        get
        {
            return uploadFile ??= new RelayCommand(obj =>
            {
                var dialog = new SaveFileDialog
                {
                    FileName = "Document",
                    DefaultExt = ".pdf",
                    Filter = "Text documents (.pdf)|*.pdf"
                };

                bool? result = dialog.ShowDialog();

                if (result == true)
                {
                    string filename = dialog.FileName;
                    var file = db.UploadFile(SelectedWorks.Id);
                    using var fs = new FileStream(filename, FileMode.Create, FileAccess.Write);
                    fs.Write(file, 0, file.Length);
                }
            });
        }
    }

    public ICommand ChangeConIndex
    {
        get
        {
            return changeConIndex ??= new RelayCommand(obj =>
            {
                db.UpdateConCur(SelectedSubject.IndexCon, SelectedSubject.Name, "con_stage");
                Changes.Add("UPDATE C " + SelectedSubject.IndexCon + " " + SelectedSubject.Name + " " + "con_stage");
            });
        }
    }

    public ICommand ChangeSubject
    {
        get
        {
            return changeSubject ??= new RelayCommand(obj =>
            {
                Changes.Add("UPDATE S " + UpdatedSubject.Name + " " + UpdatedSubject.CountLab + " " +
                            UpdatedSubject.CountPra + " " + UpdatedSubject.IndexCon + " " + UpdatedSubject.IndexCur);

                db.UpdateSubject(UpdatedSubject.Name,
                    UpdatedSubject.CountLab,
                    UpdatedSubject.CountPra,
                    UpdatedSubject.IndexCon,
                    UpdatedSubject.IndexCur);
                if (Visibility.WorkPanelVisibility == System.Windows.Visibility.Visible)
                {
                    ReadingWorkDB(SelectionTypeWork);
                }

                Visibility.UpdatePanelVisibility = System.Windows.Visibility.Collapsed;
                ReadingSubjectDB();
            });
        }
    }


    public ICommand ChangeWorkIndex
    {
        get
        {
            return changeWorkIndex ??= new RelayCommand(obj =>
            {
                db.UpdateWork(SelectedSubject.Name, SelectedWorks.Number,
                    SelectionTypeWork, SelectedWorks.IndexStage);
                Changes.Add("UPDATE WORK " + SelectedSubject.Name + " " + SelectedWorks.Number + " " +
                            SelectionTypeWork + " " + SelectedWorks.IndexStage);
                ReadingSubjectDB();
            });
        }
    }

    public ICommand OpenLabs
    {
        get { return openLabs ??= new RelayCommand(obj => { ReadingWorkDB("Лабораторная"); }); }
    }

    public ICommand OpenPra
    {
        get { return openPra ??= new RelayCommand(obj => { ReadingWorkDB("Практическая"); }); }
    }

    public ICommand OpenUpdatePanel
    {
        get
        {
            return openUpdatePanel ??=
                new RelayCommand(obj =>
                {
                    UpdatedSubject = (TableSubject)SelectedSubject.Clone();
                    Visibility.UpdatePanelVisibility = System.Windows.Visibility.Visible;
                });
        }
    }

    public void ReadingSubjectDB()
    {
        string selectedName = string.Empty;
        if (selectedSubject != null)
        {
            selectedName = selectedSubject.Name;
        }

        TableWithSubject.Clear();
        List<TableSubject> infoAll = db.GeneralInformation();
        foreach (var infoRow in infoAll)
        {
            TableWithSubject.Add(infoRow);
            if (selectedName == infoRow.Name)
            {
                SelectedSubject = TableWithSubject[^1];
            }
        }
    }

    void ReadingWorkDB(string type)
    {
        TableWithWorks.Clear();
        Visibility.WorkPanel = new(30, GridUnitType.Star);
        Visibility.WorkPanelVisibility = System.Windows.Visibility.Visible;
        SelectionTypeWork = type;

        DataRowCollection rows = db.InfoWork(SelectedSubject.Name, type);

        foreach (DataRow row in rows)
        {
            TableWithWorks.Add(new(Convert.ToInt64(row["id_works"]), row["number"].ToString(),
                row["name"].ToString(), Convert.ToInt64(row["file"])));
        }
    }

    public void InitGit()
    {
        foreach (var subject in tableWithSubject)
        {
            Changes.Add("ADD " + subject.Name + " " + subject.CountLab + " " + subject.CountPra + " " +
                        subject.IndexCon + " " + subject.IndexCur);
        }

        List<string> works = db.WorksInformation();

        Changes.AddRange(works);

        if (Changes.Count > 0)
        {
            Git.NewCommit(DateTime.Now.ToString(CultureInfo.InvariantCulture), Changes);
        }
    }

    public void UpdateVersion()
    {
        db.Reset();
        List<string> commands = Git.GetHistoryData();
        foreach (string command in commands)
        {
            string[] item = command.Split(' ');
            if (item[0] == "ADD")
            {
                bool con = item[4] != "0";

                bool cur = item[5] != "0";

                db.AddSubject(item[1], int.Parse(item[2]), int.Parse(item[3]), con, cur);
            }
            else if (item[0] == "UPDATE")
            {
                if (item[1] == "S")
                {
                    db.UpdateSubject(item[2], int.Parse(item[3]), int.Parse(item[4]), int.Parse(item[5]),
                        int.Parse(item[6]));
                }
                else if (item[1] == "C")
                {
                    db.UpdateConCur(int.Parse(item[2]), item[3], item[4]);
                }
                else if (item[1] == "WORK")
                {
                    db.UpdateWork(item[2], item[3], item[4], int.Parse(item[5]));
                }
            }
            else if (item[0] == "DELETE")
            {
                db.DeleteSubject(item[1]);
            }
        }
    }
}