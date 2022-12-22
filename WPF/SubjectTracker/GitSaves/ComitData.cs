using System;
using System.Collections.Generic;

namespace SubjectTracker
{
    internal class CommitData
    {
        public string Name { get; private set; }
        public List<string> Changes { get; private set; }
        public DateTime Date { get; private set; }

        public CommitData(string name, List<string> changes, DateTime date)
        {
            Name = name;
            Changes = changes;
            Date = date;
        }
    }
}
