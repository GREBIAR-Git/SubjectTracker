using System;
using System.Collections.Generic;

namespace SubjectTracker.GitSaves;

internal class CommitData
{
    public CommitData(string name, List<string> changes, DateTime date)
    {
        Name = name;
        Changes = changes;
        Date = date;
    }

    public string Name { get; }
    public List<string> Changes { get; }
    public DateTime Date { get; }
}