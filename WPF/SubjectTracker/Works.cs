namespace SubjectTracker
{
    internal class Works
    {
        public static string[] DefaultComboBox { get; set; } = new string[] { "Не сделано", "Сделано", "Сдано" };
        public Works(string number, string stage)
        {
            Number = number;
            Stage = stage;
        }
        public string Number { get; set; }
        public string Stage { get; set; }
    }
}
