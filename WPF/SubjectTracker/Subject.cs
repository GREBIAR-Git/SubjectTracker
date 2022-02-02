﻿namespace SubjectTracker
{
    internal class Subject
    {
        public static string[] defaultComboBox { get; set; } = new string[] { "—", "Не сделано", "Сделано", "Сдано" };

        public Subject(string name, string lab, string pra, string con, string cur)
        {
            Name = name;
            Lab = lab;
            Pra = pra;
            Con = con;
            Cur = cur;
        }
        public string Name { get; set; }
        public string Lab { get; set; }
        public string Pra { get; set; }
        public string Con { get; set; }
        public string Cur { get; set; }
    }

    internal class Works
    {
        public static string[] defaultComboBox { get; set; } = new string[] { "Не сделано", "Сделано", "Сдано" };
        public Works(string number, string stage)
        {
            Number = number;
            Stage = stage;
        }
        public string Number { get; set; }
        public string Stage { get; set; }
    }
}