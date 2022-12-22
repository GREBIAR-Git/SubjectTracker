using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml.Linq;
using TestGit;

namespace SubjectTracker
{

    public partial class MainWindow : Window
    {
        readonly SubjectDB db = new();
        readonly List<Subject> tableInfo;
        readonly List<Works> worksInfo;

        readonly ViewModel viewModel;

        List<string> changes;

        Git git;
        public MainWindow()
        {
            changes = new();
            git = new();
            viewModel = new ViewModel()
            {
                DateComboBox = new List<string>(),
            };
            InitializeComponent();
            DataContext = viewModel;
            tableInfo = new List<Subject>();
            worksInfo = new List<Works>();
            data.ItemsSource = tableInfo;
            db.Initialize();
            ReadingDB();
            SubjectPanelHide();
            WorkPanelHide();
            /*
            int code1 = git.NewCommit("fix bug", new List<string>());
            int code = git.NewCommit("fix bug", new List<string>());
            git.NewCommit("fix bug", new List<string>());

            git.Checkout(code);

            git.NewCommit("full update", new List<string>());
            code = git.NewCommit("fix", new List<string>());

            git.Checkout(code);

            git.NewCommit("restart", new List<string>());

            git.Checkout(code);

            git.NewCommit("restart v2", new List<string>());

            git.Checkout(code);

            git.NewCommit("restart v3", new List<string>());

            git.Checkout(code1);

            git.NewCommit("test1", new List<string>());
            git.NewCommit("test2", new List<string>());*/
        }
        void AddPanelHide()
        {
            table.RowDefinitions[1].Height = new GridLength(0, GridUnitType.Pixel);
        }

        void AddPanelShow()
        {
            table.RowDefinitions[1].Height = new GridLength(0, GridUnitType.Auto);
        }

        void SubjectPanelHide()
        {
            table.RowDefinitions[3].Height = new GridLength(0, GridUnitType.Pixel);
            DownPanelMI.Visibility = Visibility.Collapsed;
        }

        void SubjectPanelShow()
        {
            table.RowDefinitions[3].Height = new GridLength(0, GridUnitType.Auto);
            DownPanelMI.Visibility = Visibility.Visible;
        }

        void WorkPanelHide()
        {
            table.ColumnDefinitions[1].Width = new GridLength(0, GridUnitType.Pixel);
            RightPanelMI.Visibility = Visibility.Collapsed;
        }

        void WorkPanelShow()
        {
            table.ColumnDefinitions[1].Width = new GridLength(30, GridUnitType.Star);
            RightPanelMI.Visibility = Visibility.Visible;
        }

        void ReadingDB()
        {
            tableInfo.Clear();
            List<string[]> infoAll = db.GeneralInformation();
            foreach (string[] infoRow in infoAll)
            {
                if (infoRow.Length >= 6)
                {
                    tableInfo.Add(new Subject(infoRow[0], infoRow[1] + "/" + infoRow[2], infoRow[3] + "/" + infoRow[4], infoRow[5], infoRow[6]));
                }
            }
            data.Items.Refresh();
        }

        void AddSubjectInTable(string name, string countLab, string countPra, bool isCon, bool isCur)
        {
            string con = isCon ? "Не сделано" : "—";
            string cur = isCur ? "Не сделано" : "—";
            tableInfo.Add(new Subject(name, "0/" + countLab, "0/" + countPra, con, cur));
            data.ItemsSource = tableInfo;
            data.Items.Refresh();
        }

        void AddSubject_Click(object sender, RoutedEventArgs e)
        {
            string name = addName.Text.Replace("'", "");
            if (name != String.Empty)
            {
                if (!Int32.TryParse(addLab.Text, out int countLab))
                {
                    countLab = 0;
                }
                if (!Int32.TryParse(addPra.Text, out int countPra))
                {
                    countPra = 0;
                }
                bool con = addCon.IsChecked.Value;
                bool cur = addCur.IsChecked.Value;
                if (AddSubject(name, countLab, countPra, con, cur))
                {
                    changes.Add("ADD " + name + " " + countLab + " " + countPra + " " + con + " " + cur);
                    AddSubjectInTable(name, countLab.ToString(), countPra.ToString(), con, cur);
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
        }

        void Button_Click(object sender, RoutedEventArgs e)
        {
            Subject item = (Subject)data.SelectedItem;
            SubjectPanelShow();
            changeName.Text = item.Name;
            changeLab.Text = item.Lab.Split('/').Last();
            changePra.Text = item.Pra.Split('/').Last();
            changeCon.IsChecked = item.Con != "—";
            changeCur.IsChecked = item.Cur != "—";
        }

        void Change_Click(object sender, RoutedEventArgs e)
        {
            UpdateSubject(changeName.Text, changeLab.Text, changePra.Text, changeCon.IsChecked.Value, changeCur.IsChecked.Value);
            if (table.ColumnDefinitions[1].Width.IsStar && changeName.Text == NameWork.Text.Remove(0, 19))
            {
                WorkReading(changeName.Text, TypeWork.Text.Remove(0, 14));
            }
            SubjectPanelHide();
            ReadingDB();
        }

        void Delete_Click(object sender, RoutedEventArgs e)
        {
            DeleteSubject(changeName.Text);
            changes.Add("DELETE " + changeName.Text);
            if (table.ColumnDefinitions[1].Width.IsStar && changeName.Text == NameWork.Text.Remove(0, 19))
            {
                WorkPanelHide();
            }
            SubjectPanelHide();
            ReadingDB();
        }

        bool AddSubject(string name, int lab, int pra, bool con, bool cur)
        {
            return db.AddSubject(name, lab, pra, con, cur);
        }

        void UpdateSubject(string name, string lab, string pra, bool con, bool cur)
        {
            changes.Add("UPDATE S " + name + " " + lab + " " + pra + " " + con + " " + cur);
            db.UpdateSubject(name, lab, pra, con, cur);
        }

        void DeleteSubject(string name)
        {
            db.DeleteSubject(name);
        }

        void UpdateConCur(string cell, string type, string item)
        {
            db.UpdateConCur(cell, item, type);
        }

        void DownPanelMI_Click(object sender, RoutedEventArgs e)
        {
            SubjectPanelHide();
        }

        void RightPanelMI_Click(object sender, RoutedEventArgs e)
        {
            WorkPanelHide();
            RightPanelMI.Visibility = Visibility.Collapsed;
        }

        void UpPanelMI_Click(object sender, RoutedEventArgs e)
        {
            if (UpPanelMI.IsChecked)
            {
                AddPanelHide();
            }
            else
            {
                AddPanelShow();
            }
            UpPanelMI.IsChecked = !UpPanelMI.IsChecked;
        }


        void ComboBox_DropDownOpened(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if (comboBox.Text == "—")
            {
                comboBox.IsDropDownOpen = false;
            }
        }

        void ComboBoxCur_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Subject item = (Subject)data.SelectedItem;
            if (item != null)
            {
                if (table.RowDefinitions[3].Height.IsAuto == true)
                {
                    changeCur.IsChecked = item.Cur != "—";
                }
                UpdateConCur(item.Cur, "cur_stage", item.Name);
                changes.Add("UPDATE C " + item.Cur + " " + "cur_stage" + " " + item.Name);
            }
        }

        void ComboBoxCon_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Subject item = (Subject)data.SelectedItem;
            if (item != null)
            {
                if (table.RowDefinitions[3].Height.IsAuto == true)
                {
                    changeCon.IsChecked = item.Con != "—";
                }
                UpdateConCur(item.Con, "con_stage", item.Name);
                changes.Add("UPDATE C " + item.Con + " " + "con_stage" + " " + item.Name);
            }
        }

        void ButtonLab_Click(object sender, RoutedEventArgs e)
        {
            Subject item = (Subject)data.SelectedItem;
            WorkReading(item.Name, "Лабораторная");
        }

        void ButtonPra_Click(object sender, RoutedEventArgs e)
        {
            Subject item = (Subject)data.SelectedItem;
            WorkReading(item.Name, "Практическая");
        }

        void WorkReading(string name, string type)
        {
            worksInfo.Clear();
            WorkPanelShow();
            NameWork.Text = "Название предмета: " + name;
            TypeWork.Text = "Тип предмета: " + type;
            DataRowCollection dataRowCollection = db.InfoWork(name, type);
            if (dataRowCollection.Count > 0)
            {
                for (int i = 0; i < dataRowCollection.Count; i++)
                {
                    worksInfo.Add(new Works((i + 1).ToString(), dataRowCollection[i].ItemArray[0].ToString()));
                }
                dataWork.ItemsSource = worksInfo;
                dataWork.Items.Refresh();
            }
        }

        void ComboBoxWork_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Works item = (Works)dataWork.SelectedItem;
            if (item != null)
            {
                db.UpdateWork(NameWork.Text.Remove(0, 19), item.Number, TypeWork.Text.Remove(0, 14), item.Stage);
                changes.Add("UPDATE WORK " + NameWork.Text.Remove(0, 19) + " " + item.Number + " " + TypeWork.Text.Remove(0, 14) + " " + item.Stage);
                ReadingDB();
            }
        }

        void SubjectPanelHide(object sender, RoutedEventArgs e)
        {
            WorkPanelHide();
            RightPanelMI.Visibility = Visibility.Collapsed;
        }

        private void win_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.LeftCtrl) && e.Key == Key.S)
            {
                git.NewCommit(DateTime.Now.ToString(), changes);
                changes.Clear();
            }
        }

        void UpdateVersion()
        {
            db.Reset();
            List<string> commands = git.GetHistoryData();
            foreach (string command in commands)
            {
                string[] item = command.Split(' ');
                if (item[0] == "ADD")
                {
                    AddSubject(item[1], int.Parse(item[2]), int.Parse(item[3]), bool.Parse(item[4]), bool.Parse(item[5]));
                }
                else if (item[0] == "UPDATE")
                {
                    if (item[1] == "S")
                    {
                        UpdateSubject(item[2], item[3], item[4], bool.Parse(item[5]), bool.Parse(item[6]));
                    }
                    else if (item[1] == "C")
                    {
                        UpdateConCur(item[2], item[3], item[4]);
                    }
                    else if (item[1] == "WORK")
                    {
                        db.UpdateWork(item[2], item[3], item[4], item[5]);
                    }
                }
                else if (item[0] == "DELETE")
                {
                    DeleteSubject(item[1]);
                }
            }
        }

        void OpenSettings_Click(object sender, RoutedEventArgs e)
        {
            if(settings.Visibility == Visibility.Collapsed)
            {
                table.Visibility = Visibility.Collapsed;
                settings.Visibility = Visibility.Visible;
                lines.Visibility = Visibility.Visible;
                UpdateVersionGrid();
            }
            else
            {
                table.Visibility = Visibility.Visible;
                settings.Visibility = Visibility.Collapsed;
                lines.Visibility = Visibility.Collapsed;
                ReadingDB();
            }
        }

        void UpdateVersionGrid()
        {
            git.GitToGrids(settings, lines, ClickGitVersion);
        }

        void ClickGitVersion(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            git.Checkout((int)button.Tag);
            UpdateVersion();
            git.GitToGrids(settings, lines, ClickGitVersion);
        }

        private void Win_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if(settings.Visibility== Visibility.Visible)
            {
                git.UpdateLines(lines);
            }
        }
    }
}

