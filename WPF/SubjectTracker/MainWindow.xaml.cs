using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace SubjectTracker
{

    public partial class MainWindow : Window
    {
        readonly SubjectDB db = new();
        readonly List<Subject> tableInfo;
        readonly List<Works> worksInfo;

        public MainWindow()
        {
            InitializeComponent();
            tableInfo = new List<Subject>();
            worksInfo = new List<Works>();
            data.ItemsSource = tableInfo;
            db.Initialize();
            ReadingDB();
            SubjectPanelHide();
            WorkPanelHide();
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
                if (db.AddSubject(name, countLab, countPra, con, cur))
                {
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
            db.UpdateSubject(changeName.Text, changeLab.Text, changePra.Text, changeCon.IsChecked.Value, changeCur.IsChecked.Value);
            if (table.ColumnDefinitions[1].Width.IsStar && changeName.Text == NameWork.Text.Remove(0, 19))
            {
                WorkReading(changeName.Text, TypeWork.Text.Remove(0, 14));
            }
            SubjectPanelHide();
            ReadingDB();
        }

        void Delete_Click(object sender, RoutedEventArgs e)
        {
            db.DeleteSubject(changeName.Text);
            if (table.ColumnDefinitions[1].Width.IsStar && changeName.Text == NameWork.Text.Remove(0, 19))
            {
                WorkPanelHide();
            }
            SubjectPanelHide();
            ReadingDB();

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
                ComboboxChange(item.Cur, "cur_stage", item);
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
                ComboboxChange(item.Con, "con_stage", item);
            }
        }

        void ComboboxChange(string cell, string type, Subject item)
        {
            db.UpdateConCur(cell, item.Name, type);
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
                ReadingDB();
            }
        }

        void SubjectPanelHide(object sender, RoutedEventArgs e)
        {
            WorkPanelHide();
            RightPanelMI.Visibility = Visibility.Collapsed;
        }
    }
}

