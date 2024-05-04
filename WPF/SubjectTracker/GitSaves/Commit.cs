using System;
using System.Collections.Generic;

namespace SubjectTracker.GitSaves;

internal class Commit
{
    public Commit(string name, List<string> changes, Commit? prev = null)
    {
        Data = new(name, changes, DateTime.Now);
        Prev = prev;
    }

    public CommitData Data { get; }
    public Commit? Next { get; private set; }
    public Commit? Prev { get; }

    public Commit NewCommit(string name, List<string> data)
    {
        return Next = new(name, data, this);
    }
}