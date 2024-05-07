using System;
using System.Collections.Generic;

namespace SubjectTracker.GitSaves;

internal class Branch : IComparable<Branch>
{
    public Branch(string nameBranch, string nameCommit = "Initial commit", List<string>? dataCommit = null,
        Branch? prev = null, Commit? prevCommit = null)
    {
        dataCommit ??= [];
        Name = nameBranch;
        First = new(nameCommit, dataCommit, prevCommit);
        Prev = prev;
    }

    public string Name { get; }
    public Commit First { get; }
    public Branch? Prev { get; }

    public virtual int CompareTo(Branch other)
    {
        if (CountPrev() == other.CountPrev())
        {
            return 0;
        }

        if (CountPrev() > other.CountPrev())
        {
            return -1;
        }

        return 1;
    }

    public int CountPrev()
    {
        Commit commit = First;
        int count = 0;
        while (commit.Prev != null)
        {
            count += 1;
            commit = commit.Prev;
        }

        return count;
    }
}