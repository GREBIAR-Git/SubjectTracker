using SubjectTracker;
using System;
using System.Collections.Generic;

namespace TestGit;

class Commit
{
    public CommitData Data { get; private set; }
    public Commit? Next { get; private set; }
    public Commit? Prev { get; private set; }

    public Commit NewCommit(string name, List<string> data)
    {
        return Next = new Commit(name, data, this);
    }

    public Commit(string name, List<string> changes, Commit? prev = null)
    {
        Data = new CommitData(name, changes, DateTime.Now);
        Prev = prev;
    }
}
