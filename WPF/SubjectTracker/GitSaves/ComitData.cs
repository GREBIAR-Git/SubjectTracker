using System;
using System.Collections.Generic;

namespace SubjectTracker.GitSaves;

internal class CommitData(string name, List<string> changes, DateTime date)
{
    public string Name { get; } = name;
    public List<string> Changes { get; } = changes;
    public DateTime Date { get; } = date;
}