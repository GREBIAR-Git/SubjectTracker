using System;
using System.Collections.Generic;

namespace SubjectTracker.GitSaves;

internal class Commit(string name, List<string> changes, Commit? prev = null)
{
    public CommitData Data { get; } = new(name, changes, DateTime.Now);
    public Commit? Next { get; private set; }
    public Commit? Prev { get; } = prev;

    public Commit NewCommit(string name, List<string> data)
    {
        return Next = new(name, data, this);
    }
}