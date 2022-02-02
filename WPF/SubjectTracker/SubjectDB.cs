using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace SubjectTracker
{
    internal class SubjectDB
    {
        string nameDB;
        string pathDB;

        public SubjectDB()
        {
            nameDB = "SubjectTracker.db";
            pathDB = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\" + nameDB;
        }

        public void Initialize()
        {
            if (!File.Exists(pathDB))
            {
                SQLiteConnection.CreateFile(pathDB);
                using (SQLiteConnection connection = new SQLiteConnection("Data Source = " + pathDB))
                {
                    connection.Open();
                    SQLiteCommand command = new SQLiteCommand();
                    command.Connection = connection;

                    command.CommandText = "CREATE TABLE IF NOT EXISTS View(" +
                        "id_view INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                        "name TEXT NOT NULL);" +

                        "CREATE TABLE IF NOT EXISTS Stage(" +
                        "id_stage INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                        "name TEXT NOT NULL);" +

                        "CREATE TABLE IF NOT EXISTS Subject(" +
                        "id_subject INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                        "name TEXT NOT NULL," +
                        "con_stage INTEGER NULL," +
                        "cur_stage INTEGER NULL," +
                        "FOREIGN KEY(con_stage) REFERENCES Stage(id_stage) ON DELETE CASCADE," +
                        "FOREIGN KEY(cur_stage) REFERENCES Stage(id_stage) ON DELETE CASCADE);" +

                        "CREATE TABLE IF NOT EXISTS Works(" +
                        "id_works INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
                        "number INTEGER NOT NULL," +
                        "id_stage INTEGER NOT NULL," +
                        "id_view INTEGER NOT NULL," +
                        "id_subject INTEGER NOT NULL," +
                        "FOREIGN KEY(id_stage) REFERENCES Stage(id_stage) ON DELETE CASCADE," +
                        "FOREIGN KEY(id_subject) REFERENCES Subject(id_subject) ON DELETE CASCADE," +
                        "FOREIGN KEY(id_view) REFERENCES View(id_view) ON DELETE CASCADE);";
                    command.ExecuteNonQuery();
                    Insert(connection, "View", "name", "'Лабораторная'", "'Практическая'");
                    Insert(connection, "Stage", "name", "'—'", "'Не сделано'", "'Сделано'", "'Сдано'");
                }
            }
        }

        public bool AddSubject(string name, int countLab, int countPra, bool con, bool cur)
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source = " + pathDB))
            {
                connection.Open();
                if (Query(connection, "SELECT * FROM Subject WHERE name='" + name + "'").Count == 0)
                {
                    string conStage = con ? ",2" : ",1";
                    string curStage = cur ? ",2" : ",1";
                    Insert(connection, "Subject", "name,con_stage,cur_stage", "'" + name + "'" + conStage + curStage);
                    InsertWorks(connection, "Лабораторная", name, countLab);
                    InsertWorks(connection, "Практическая", name, countPra);
                    return true;
                }
            }
            return false;
        }

        void InsertWorks(SQLiteConnection connection, string view, string name, int count)
        {
            InsertWorks(connection, view, name, 1, count + 1);
        }

        void InsertWorks(SQLiteConnection connection, string view, string name, int from, int to)
        {
            string idView = Query(connection, "SELECT * FROM View WHERE name='" + view + "'")[0].ItemArray[0].ToString();
            string idSubject = Query(connection, "SELECT * FROM Subject WHERE name='" + name + "'")[0].ItemArray[0].ToString();
            string[] values = new string[to - from];
            int i = 0;
            for (int number = from; number < to; number++)
            {
                values[i] = number + ",2," + idView + "," + idSubject;
                i++;
            }
            Insert(connection, "Works", "number,id_stage,id_view,id_subject", values);
        }

        void Insert(SQLiteConnection connection, string table, string name, params string[] values)
        {
            SQLiteCommand command = new SQLiteCommand();
            command.Connection = connection;
            command.CommandText = "INSERT INTO " + table + " (" + name + ")VALUES";
            foreach (string value in values)
            {
                command.CommandText += "(" + value + "),";
            }
            int last = command.CommandText.Length - 1;
            if (command.CommandText[last] == ',')
            {
                command.CommandText = command.CommandText.Remove(last);

            }
            command.ExecuteNonQuery();
        }

        DataRowCollection Query(SQLiteConnection connection, string query)
        {
            SQLiteCommand command = new SQLiteCommand();
            command.Connection = connection;
            DataTable dTable = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);
            adapter.Fill(dTable);
            return dTable.Rows;
        }

        public List<string[]> GeneralInformation()
        {
            List<string[]> info = new List<string[]>();
            info.Add(new string[] { });
            using (SQLiteConnection connection = new SQLiteConnection("Data Source = " + pathDB))
            {
                connection.Open();
                DataRowCollection allName = Query(connection, "SELECT id_subject,name,con_stage,cur_stage FROM Subject");
                foreach (DataRow row in allName)
                {
                    string name = row[1].ToString();
                    string con = Query(connection, "SELECT name FROM Stage WHERE id_stage=" + row[2].ToString())[0].ItemArray[0].ToString();
                    string cur = Query(connection, "SELECT name FROM Stage WHERE id_stage=" + row[3].ToString())[0].ItemArray[0].ToString();
                    int donel = CountDoneSubject(connection, out int countL, name, "Лабораторная");
                    int donep = CountDoneSubject(connection, out int countP, name, "Практическая");
                    info.Add(new string[] { name, donel.ToString(), countL.ToString(), donep.ToString(), countP.ToString(), con, cur });
                }
            }
            return info;
        }

        int CountDoneSubject(SQLiteConnection connection, out int countAll, string name, string type)
        {
            DataRowCollection all = AllWorks(connection, name, type);
            int done = 0;
            countAll = all.Count;
            foreach (DataRow rowl in all)
            {
                if (rowl[0].ToString() == "Сдано")
                {
                    done++;
                }
            }
            return done;
        }

        DataRowCollection AllWorks(SQLiteConnection connection, string name, string type)
        {
            return Query(connection, "SELECT st.name FROM Works w JOIN View v USING(id_view) JOIN Subject su USING(id_subject) JOIN Stage st USING(id_stage) WHERE v.name='" + type + "' AND su.name='" + name + "'");
        }

        public void UpdateConCur(string value, string name, string type)
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source = " + pathDB))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand();
                command.Connection = connection;
                string id = Query(connection, "SELECT id_stage FROM Stage WHERE name='" + value + "'")[0].ItemArray[0].ToString();
                command.CommandText = "UPDATE Subject SET " + type + "=" + id + " WHERE name='" + name + "'";
                command.ExecuteNonQuery();
            }
        }

        public void UpdateConCur(string value, int id, string type)
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source = " + pathDB))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand();
                command.Connection = connection;
                command.CommandText = "UPDATE Subject SET " + type + "=" + value + " WHERE id_subject=" + id;
                command.ExecuteNonQuery();
            }
        }


        public void UpdateSubject(string name, string lab, string pra, bool con, bool cur)
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source = " + pathDB))
            {
                connection.Open();
                string idSubject = Query(connection, "SELECT * FROM Subject WHERE name='" + name + "'")[0].ItemArray[0].ToString();
                ChangeCountWorks(connection, idSubject, name, lab, "Лабораторная");
                ChangeCountWorks(connection, idSubject, name, pra, "Практическая");
                ChangeConCur(connection, idSubject, con, cur);
            }
        }

        void ChangeCountWorks(SQLiteConnection connection, string idSubject, string nameSubject, string newCountWork, string nameType)
        {
            string idView = Query(connection, "SELECT id_view FROM View WHERE name='" + nameType + "'")[0].ItemArray[0].ToString();

            int count = Query(connection, "SELECT * FROM Works WHERE id_subject=" + idSubject + " AND id_view='" + idView + "'").Count;
            SQLiteCommand command = new SQLiteCommand();
            command.Connection = connection;
            int newCount = 0;
            Int32.TryParse(newCountWork, out newCount);
            if (newCount != count)
            {
                if (newCount < count)
                {
                    command.CommandText = "DELETE FROM Works WHERE id_subject=" + idSubject + " AND number>" + newCount + " AND id_view=" + idView;
                    command.ExecuteNonQuery();
                }
                else
                {
                    InsertWorks(connection, nameType, nameSubject, count + 1, newCount + 1);
                }
            }
        }

        void ChangeConCur(SQLiteConnection connection, string idSubject, bool con, bool cur)
        {
            SQLiteCommand command = new SQLiteCommand();
            command.Connection = connection;
            DataRow row = Query(connection, "SELECT con_stage,cur_stage FROM Subject WHERE id_subject=" + idSubject)[0];
            ChangeOneMainWork(con, idSubject, row[0].ToString(), "con");
            ChangeOneMainWork(cur, idSubject, row[1].ToString(), "cur");
        }

        void ChangeOneMainWork(bool work, string idSubject, string current, string type)
        {
            string newValue = work ? "2" : "1";
            int currentInt = int.Parse(current);
            string currentValue = (currentInt) > 2 ? "2" : currentInt.ToString();
            if (currentValue != newValue)
            {
                string value;
                if (currentValue == "1")
                {
                    value = "2";
                }
                else
                {
                    value = "1";
                }
                UpdateConCur(value, int.Parse(idSubject), type + "_stage");
            }
        }

        public void DeleteSubject(string name)
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source = " + pathDB))
            {
                connection.Open();
                string idSubject = Query(connection, "SELECT id_subject FROM Subject WHERE name='" + name + "'")[0].ItemArray[0].ToString();
                SQLiteCommand command = new SQLiteCommand();
                command.Connection = connection;
                command.CommandText = "DELETE FROM Subject WHERE name='" + name + "'";
                command.ExecuteNonQuery();
                command.CommandText = "DELETE FROM Works WHERE id_subject=" + idSubject;
                command.ExecuteNonQuery();
            }
        }

        public DataRowCollection InfoWork(string name, string type)
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source = " + pathDB))
            {
                connection.Open();
                return AllWorks(connection, name, type);
            }
        }

        public void UpdateWork(string name, string number, string type, string newStage)
        {
            using (SQLiteConnection connection = new SQLiteConnection("Data Source = " + pathDB))
            {
                connection.Open();
                SQLiteCommand command = new SQLiteCommand();
                command.Connection = connection;

                string idStage = "(SELECT id_stage FROM Stage WHERE name='" + newStage + "')";
                string idSubject = "(SELECT id_subject FROM Subject WHERE name='" + name + "')";
                string idView = "(SELECT id_view FROM View WHERE name='" + type + "')";

                command.CommandText = "UPDATE Works SET id_stage=" + idStage + " WHERE id_subject=" + idSubject + " AND number=" + number + " AND id_view=" + idView;
                command.ExecuteNonQuery();
            }
        }
    }
}
