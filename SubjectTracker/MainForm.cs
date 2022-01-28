using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SubjectTracker
{
    public partial class MainForm : Form
    {
        SubjectDB db = new SubjectDB();

        public MainForm()
        {
            InitializeComponent();
            db.Initialize();
            RubberTable();
            ReadingDB();
            subjectPanel.Visible = false;
            workPanel.Visible = false;
            leftWorkPanel.Visible = false;
        }

        void ReadingDB()
        {
            data.Rows.Clear();
            List<string[]> infoAll = db.GeneralInformation();
            foreach (string[] infoRow in infoAll)
            {
                if (infoRow.Length >= 6)
                {
                    data.Rows.Add(infoRow[0], infoRow[1] + "/" + infoRow[2], infoRow[3] + "/" + infoRow[4], infoRow[5], infoRow[6]);
                }
            }
        }

        void RubberTable()
        {
            RubbleColums(0, 0.244);
            RubbleColums(1, 0.164);
            RubbleColums(2, 0.164);
            RubbleColums(3, 0.214);
            RubbleColums(4, 0.214);
        }

        void RubbleColums(int number, double percent)
        {
            data.Columns[number].Width = (int)(percent * data.Width);
        }

        void Form1_SizeChanged(object sender, EventArgs e)
        {
            RubberTable();
        }

        void AddSubject_Click(object sender, EventArgs e)
        {
            string name = nameTextBox.Text.Replace("'", "");
            if (name != String.Empty)
            {
                int countLab, countPra;
                if (!Int32.TryParse(labTextBox.Text, out countLab))
                {
                    countLab = 0;
                }
                if (!Int32.TryParse(praTextBox.Text, out countPra))
                {
                    countPra = 0;
                }
                bool con = conCheckBox.Checked;
                bool cur = curCheckBox.Checked;
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

        void AddSubjectInTable(string name, string countLab, string countPra, bool isCon, bool isCur)
        {
            string con = isCon ? "Не сделано" : "—";
            string cur = isCur ? "Не сделано" : "—";
            data.Rows.Add(name, "0/" + countLab, "0/" + countPra, con, cur);
        }

        void data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex > -1)
            {
                if (e.ColumnIndex == 0)
                {
                    nameChangeL.Text = senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString();
                    labChangeTB.Text = senderGrid.Rows[e.RowIndex].Cells[1].Value.ToString().Split('/').Last();
                    praChangeTB.Text = senderGrid.Rows[e.RowIndex].Cells[2].Value.ToString().Split('/').Last();
                    conChangeCB.Checked = senderGrid.Rows[e.RowIndex].Cells[3].Value.ToString() == "—" ? false : true;
                    curChangeCB.Checked = senderGrid.Rows[e.RowIndex].Cells[4].Value.ToString() == "—" ? false : true;
                    subjectPanel.Visible = true;
                    workPanel.Visible = false;
                    leftWorkPanel.Visible = false;
                }
                else if (e.ColumnIndex == 1)
                {
                    subjectName.Text = senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString();
                    typeWork.Text = "Лабораторная";
                    WorkReading(senderGrid, e, "Лабораторная");
                }
                else if (e.ColumnIndex == 2)
                {
                    subjectName.Text = senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString();
                    typeWork.Text = "Практическая";
                    WorkReading(senderGrid, e, "Практическая");
                }
                DownPanelMenuItem.Visible = true;
            }
        }

        void WorkReading(DataGridView sender, DataGridViewCellEventArgs e, string type)
        {
            DataRowCollection dataRowCollection = db.InfoWork(sender.Rows[e.RowIndex].Cells[0].Value.ToString(), type);
            if (dataRowCollection.Count > 0)
            {
                workPanel.Visible = true;
                leftWorkPanel.Visible = true;
                subjectPanel.Visible = false;
                workPanel.Columns.Clear();
                DataGridViewComboBoxColumn[] column = new DataGridViewComboBoxColumn[dataRowCollection.Count];
                string[] row = new string[dataRowCollection.Count];
                for (int i = 0; i < dataRowCollection.Count; i++)
                {
                    column[i] = new DataGridViewComboBoxColumn();
                    column[i].HeaderText = "№" + (i + 1);
                    column[i].Items.Add("Не сделано");
                    column[i].Items.Add("Сделано");
                    column[i].Items.Add("Сдано");
                    row[i] = dataRowCollection[i].ItemArray[0].ToString();
                }
                workPanel.Columns.AddRange(column);
                workPanel.Rows.Add(row);
            }
        }

        void data_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn)
            {
                if (senderGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "—")
                {
                    e.Cancel = true;
                }
            }
        }

        void data_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn)
            {
                DataGridViewRow row = senderGrid.Rows[e.RowIndex];

                string cell = row.Cells[e.ColumnIndex].Value.ToString();

                string type = e.ColumnIndex == 3 ? "con_stage" : "cur_stage";

                db.UpdateConCur(cell, row.Cells[0].Value.ToString(), type);
            }
        }

        void ChangeB_Click(object sender, EventArgs e)
        {
            db.UpdateSubject(nameChangeL.Text, labChangeTB.Text, praChangeTB.Text, conChangeCB.Checked, curChangeCB.Checked);
            subjectPanel.Visible = false;
            ReadingDB();
            DownPanelMenuItem.Visible = false;
        }

        void DeleteB_Click(object sender, EventArgs e)
        {
            db.DeleteSubject(nameChangeL.Text);
            subjectPanel.Visible = false;
            ReadingDB();
            DownPanelMenuItem.Visible = false;
        }

        void UpPanelMenuItem_Click(object sender, EventArgs e)
        {
            UpPanelMenuItem.Checked = !UpPanelMenuItem.Checked;
            AddPanel.Visible = UpPanelMenuItem.Checked;
        }

        void DownPanelMenuItem_Click_1(object sender, EventArgs e)
        {
            DownPanelMenuItem.Visible = false;
            subjectPanel.Visible = false;
            workPanel.Visible = false;
            leftWorkPanel.Visible = false;
        }

        void workPanel_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView senderGrid = (DataGridView)sender;
            string newStage = senderGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            db.UpdateWork(subjectName.Text, (e.ColumnIndex + 1).ToString(), typeWork.Text, newStage);
            ReadingDB();
        }
    }
}
