using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using SubjectTracker.Models;

namespace SubjectTracker.DataBase;

public class DataBase
{
    readonly string pathDB;

    public DataBase()
    {
        const string nameDb = "SubjectTracker.db";
        pathDB = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\" + nameDb;
    }

    public void Initialize()
    {
        if (!File.Exists(pathDB))
        {
            SQLiteConnection.CreateFile(pathDB);
            using SQLiteConnection connection = new("Data Source = " + pathDB);
            connection.Open();
            SQLiteCommand command = new()
            {
                Connection = connection,

                CommandText = "CREATE TABLE IF NOT EXISTS Type(" +
                              "id_type INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT," +
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
                              "file BLOB NULL," +
                              "id_stage INTEGER NOT NULL," +
                              "id_type INTEGER NOT NULL," +
                              "id_subject INTEGER NOT NULL," +
                              "FOREIGN KEY(id_stage) REFERENCES Stage(id_stage) ON DELETE CASCADE," +
                              "FOREIGN KEY(id_subject) REFERENCES Subject(id_subject) ON DELETE CASCADE," +
                              "FOREIGN KEY(id_type) REFERENCES Type(id_type) ON DELETE CASCADE);"
            };
            command.ExecuteNonQuery();
            Insert(connection, "Type", "name", "'Лабораторная'", "'Практическая'");
            Insert(connection, "Stage", "name", "'—'", "'Не сделано'", "'Сделано'", "'Сдано'");
        }
    }

    public bool AddSubject(string name, int countLab, int countPra, bool con, bool cur)
    {
        using SQLiteConnection connection = new("Data Source = " + pathDB);
        connection.Open();
        if (Query(connection, "SELECT * FROM Subject WHERE name='" + name + "'").Count == 0)
        {
            string conStage = con ? ",1" : ",0";
            string curStage = cur ? ",1" : ",0";
            Insert(connection, "Subject", "name,con_stage,cur_stage", "'" + name + "'" + conStage + curStage);
            InsertWorks(connection, "Лабораторная", name, countLab);
            InsertWorks(connection, "Практическая", name, countPra);
            return true;
        }

        return false;
    }

    public void DeleteSubject(string name)
    {
        using SQLiteConnection connection = new("Data Source = " + pathDB);
        connection.Open();
        string idSubject = Query(connection, "SELECT id_subject FROM Subject WHERE name='" + name + "'")[0]
            .ItemArray[0].ToString();
        SQLiteCommand command = new()
        {
            Connection = connection,
            CommandText = "DELETE FROM Subject WHERE name='" + name + "'"
        };
        command.ExecuteNonQuery();
        command.CommandText = "DELETE FROM Works WHERE id_subject=" + idSubject;
        command.ExecuteNonQuery();
    }

    static void InsertWorks(SQLiteConnection connection, string view, string name, int count)
    {
        InsertWorks(connection, view, name, 1, count + 1);
    }

    static void InsertWorks(SQLiteConnection connection, string view, string name, int from, int to)
    {
        string idView = Query(connection, "SELECT * FROM Type WHERE name='" + view + "'")[0].ItemArray[0].ToString();
        string idSubject = Query(connection, "SELECT * FROM Subject WHERE name='" + name + "'")[0].ItemArray[0]
            .ToString();
        string[] values = new string[to - from];
        int i = 0;
        for (int number = from; number < to; number++)
        {
            values[i] = number + ",2," + idView + "," + idSubject;
            i++;
        }

        Insert(connection, "Works", "number,id_stage,id_type,id_subject", values);
    }

    static void Insert(SQLiteConnection connection, string table, string name, params string[] values)
    {
        if (values.Length > 0)
        {
            StringBuilder insert = new("INSERT INTO " + table + " (" + name + ")VALUES");
            foreach (string value in values)
            {
                insert.Append("(" + value + "),");
            }

            int last = insert.Length - 1;
            if (insert[last] == ',')
            {
                insert.Remove(last, 1);
            }

            SQLiteCommand command = new()
            {
                Connection = connection,
                CommandText = insert.ToString()
            };
            command.ExecuteNonQuery();
        }
    }

    public void Reset()
    {
        using SQLiteConnection connection = new("Data Source = " + pathDB);
        connection.Open();
        StringBuilder insert = new("delete from Subject");

        SQLiteCommand command1 = new()
        {
            Connection = connection,
            CommandText = insert.ToString()
        };
        command1.ExecuteNonQuery();
        insert = new("delete from Works");

        SQLiteCommand command2 = new()
        {
            Connection = connection,
            CommandText = insert.ToString()
        };
        command2.ExecuteNonQuery();
    }

    static DataRowCollection Query(SQLiteConnection connection, string query)
    {
        DataTable dTable = new();
        SQLiteDataAdapter adapter = new(query, connection);
        adapter.Fill(dTable);
        return dTable.Rows;
    }

    public List<TableSubject> GeneralInformation()
    {
        List<TableSubject> info = [];
        using SQLiteConnection connection = new("Data Source = " + pathDB);
        connection.Open();
        DataRowCollection allName = Query(connection, "SELECT id_subject,name,con_stage,cur_stage FROM Subject");
        foreach (DataRow row in allName)
        {
            string name = row.Field<string>("name");
            int donel = CountDoneSubject(connection, out int countL, name, "Лабораторная");
            int donep = CountDoneSubject(connection, out int countP, name, "Практическая");
            info.Add(new(name,
                donel,
                donep,
                countL,
                countP,
                (int)row.Field<long>("con_stage"),
                (int)row.Field<long>("cur_stage")
            ));
        }

        return info;
    }

    public List<string> WorksInformation()
    {
        List<string> info = [];
        using SQLiteConnection connection = new("Data Source = " + pathDB);
        connection.Open();
        DataRowCollection rows = Query(connection,
            "SELECT s.name as sn, w.number, w.id_stage, t.name as tn FROM Works w JOIN Subject s JOIN Type t");

        foreach (DataRow row in rows)
        {
            long idStage = row.Field<long>("id_stage");
            if (idStage > 2)
            {
                string subjectName = row.Field<string>("sn");

                long number = row.Field<long>("number");

                string typeName = row.Field<string>("tn");

                info.Add("UPDATE WORK " + subjectName + " " + number + " " + typeName + " " + idStage);
            }
        }

        return info;
    }

    static int CountDoneSubject(SQLiteConnection connection, out int countAll, string name, string type)
    {
        DataRowCollection all = AllWorks(connection, name, type);
        countAll = all.Count;

        return all.Cast<DataRow>().Count(row => row[1].ToString() == "Сдано");
    }

    static DataRowCollection AllWorks(SQLiteConnection connection, string name, string type)
    {
        return Query(connection,
            "SELECT w.id_works, st.name, w.file IS NOT NULL FROM Works w JOIN Type v USING(id_type) JOIN Subject su USING(id_subject) JOIN Stage st USING(id_stage) WHERE v.name='" +
            type + "' AND su.name='" + name + "'");
    }

    public void UpdateConCur(int value, string name, string type)
    {
        using SQLiteConnection connection = new("Data Source = " + pathDB);
        connection.Open();
        SQLiteCommand command = new()
        {
            Connection = connection,
            CommandText = "UPDATE Subject SET " + type + "=" + value + " WHERE name='" + name + "'"
        };
        command.ExecuteNonQuery();
    }

    public void UpdateConCur(int value, int id, string type)
    {
        using SQLiteConnection connection = new("Data Source = " + pathDB);
        connection.Open();
        SQLiteCommand command = new()
        {
            Connection = connection,
            CommandText = "UPDATE Subject SET " + type + "=" + value + " WHERE id_subject=" + id
        };
        command.ExecuteNonQuery();
    }


    public void UpdateSubject(string name, int lab, int pra, int con, int cur)
    {
        using SQLiteConnection connection = new("Data Source = " + pathDB);
        connection.Open();
        string idSubject = Query(connection, "SELECT * FROM Subject WHERE name='" + name + "'")[0].ItemArray[0]
            .ToString();
        ChangeCountWorks(connection, idSubject, name, lab, "Лабораторная");
        ChangeCountWorks(connection, idSubject, name, pra, "Практическая");
        ChangeConCur(connection, idSubject, con, cur);
    }

    static void ChangeCountWorks(SQLiteConnection connection, string idSubject, string nameSubject, int newCount,
        string nameType)
    {
        string idView = Query(connection, "SELECT id_type FROM Type WHERE name='" + nameType + "'")[0].ItemArray[0]
            .ToString();

        int count = Query(connection,
            "SELECT * FROM Works WHERE id_subject=" + idSubject + " AND id_type='" + idView + "'").Count;
        SQLiteCommand command = new()
        {
            Connection = connection
        };

        if (newCount != count)
        {
            if (newCount < count)
            {
                command.CommandText = "DELETE FROM Works WHERE id_subject=" + idSubject + " AND number>" + newCount +
                                      " AND id_type=" + idView;
                command.ExecuteNonQuery();
            }
            else
            {
                InsertWorks(connection, nameType, nameSubject, count + 1, newCount + 1);
            }
        }
    }

    void ChangeConCur(SQLiteConnection connection, string idSubject, int con, int cur)
    {
        DataRow row = Query(connection, "SELECT con_stage,cur_stage FROM Subject WHERE id_subject=" + idSubject)[0];


        ChangeOneMainWork(con, idSubject, row.Field<long>("con_stage"), "con");
        ChangeOneMainWork(cur, idSubject, row.Field<long>("cur_stage"), "cur");
    }

    void ChangeOneMainWork(int work, string idSubject, long current, string type)
    {
        if (current != work)
        {
            int value = current == 0 ? 1 : 0;

            UpdateConCur(value, int.Parse(idSubject), type + "_stage");
        }
    }

    public DataRowCollection InfoWork(string name, string type)
    {
        using SQLiteConnection connection = new("Data Source = " + pathDB);
        connection.Open();
        return AllWorks(connection, name, type);
    }

    public byte[] UploadFile(long id)
    {
        using SQLiteConnection connection = new("Data Source = " + pathDB);
        connection.Open();
        DataRowCollection dataRow = Query(connection, "SELECT file FROM Works WHERE id_works = " + id);
        byte[] file;
        if (dataRow.Count == 1)
        {
            file = dataRow[0].Field<byte[]>("file");
        }
        else
        {
            file = [];
        }

        return file;
    }

    public void UpdateWork(string name, string number, string type, int idStage)
    {
        using SQLiteConnection connection = new("Data Source = " + pathDB);
        connection.Open();
        SQLiteCommand command = new()
        {
            Connection = connection
        };

        string idSubject = "(SELECT id_subject FROM Subject WHERE name='" + name + "')";
        string idView = "(SELECT id_type FROM Type WHERE name='" + type + "')";

        command.CommandText = "UPDATE Works SET id_stage=" + idStage + " WHERE id_subject=" + idSubject +
                              " AND number=" + number + " AND id_type=" + idView;
        command.ExecuteNonQuery();
    }

    public void LoadFile(string name, string number, string type, byte[] file)
    {
        using SQLiteConnection connection = new("Data Source = " + pathDB);
        connection.Open();
        string idSubject = "(SELECT id_subject FROM Subject WHERE name='" + name + "')";
        string idView = "(SELECT id_type FROM Type WHERE name='" + type + "')";
        SQLiteCommand command = new()
        {
            Connection = connection,
            CommandText = "UPDATE Works SET file=@File WHERE id_subject=" + idSubject +
                          " AND number=" + number + " AND id_type=" + idView
        };
        command.Parameters.Add("@File", DbType.Binary, file.Length).Value = file;

        command.ExecuteNonQuery();
    }
}