using System;
using System.Windows;

namespace SubjectTracker.Models;

public class Works
{
    public Works(long id, string number, string stage, long isLoadFile)
    {
        Id = id;
        Number = number;
        Stage = stage;
        if (isLoadFile == 0)
        {
            IsLoadFile = Visibility.Collapsed;
            IsLoadFileColumnSpan = 2;
        }
        else
        {
            IsLoadFile = Visibility.Visible;
            IsLoadFileColumnSpan = 1;
        }
    }

    public long Id { get; set; }

    public static string[] DefaultComboBox { get; set; } = ["Не сделано", "Сделано", "Сдано"];
    public string Number { get; set; }

    public int IndexStage { get; set; }

    public Visibility IsLoadFile { get; set; }

    public int IsLoadFileColumnSpan { get; set; }

    public string Stage
    {
        get => TableSubject.DefaultComboBox[IndexStage - 1];
        set => IndexStage = Array.IndexOf(TableSubject.DefaultComboBox, value) + 1;
    }
}