using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubjectTracker
{
    internal class CommitIdentifier
    {
        public int HashCode { get; private set; }
        public string Name { get; private set; }
        public CommitIdentifier(int hashCode,string name) 
        {
            HashCode = hashCode;
            Name = name;
        }
    }
}
