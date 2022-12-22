using System;
using System.Collections.Generic;

namespace TestGit;

class Branch : IComparable<Branch>
{
    public string Name { get; private set; }
    public Commit First { get; private set; }
    public Branch? Prev { get; private set; }

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


    public Branch(string nameBranch, string nameCommit = "Initial commit", List<string>? dataCommit = null, Branch? prev = null, Commit? prevCommit = null)
    {
        dataCommit ??= new List<string>();
        Name = nameBranch;
        First = new Commit(nameCommit, dataCommit, prevCommit);
        Prev = prev;
    }
    public virtual int CompareTo(Branch other)
    {
        if (CountPrev() == other.CountPrev())
        {
            return 0;
        }
        else if (CountPrev() > other.CountPrev())
        {
            return -1;
        }
        else
        {
            return 1;
        }
    }
}
