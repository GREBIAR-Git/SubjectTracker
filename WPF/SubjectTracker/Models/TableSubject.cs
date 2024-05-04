using System;

namespace SubjectTracker.Models;

public class TableSubject : Subject
{
    public TableSubject(string name, int lab, int pra, int con, int cur) : base(name, con, cur)
    {
        CountLab = lab;
        CountPra = pra;
    }

    public TableSubject()
    {
        CountLab = 0;
        CountPra = 0;
    }

    public TableSubject(string name, int doneLab, int donePra, int lab, int pra, int con, int cur) : base(name, con,
        cur)
    {
        DoneLab = doneLab;
        DonePra = donePra;
        CountLab = lab;
        CountPra = pra;
    }

    public static string[] DefaultComboBox { get; set; } = { "—", "Не сделано", "Сделано", "Сдано" };

    int DoneLab { get; }

    public int CountLab { get; set; }

    int DonePra { get; }

    public int CountPra { get; set; }

    public string Lab => CountLab != 0 ? DoneLab + "/" + CountLab : "—";
    public string Pra => CountPra != 0 ? DonePra + "/" + CountPra : "—";

    public string Con
    {
        get => DefaultComboBox[IndexCon];
        set => IndexCon = Array.IndexOf(DefaultComboBox, value);
    }

    public string Cur
    {
        get => DefaultComboBox[IndexCur];
        set => IndexCur = Array.IndexOf(DefaultComboBox, value);
    }

    public object Clone()
    {
        return MemberwiseClone();
    }
}