using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamUP.Data.Party;

namespace TeamUP.Domain.Party
{
    public class TeamWork
    {
        private const string defaultString = "Undefined";
        private const bool defaultDone = false;
        private const int defaultTeamSize = 1;
        private DateTime defaultDate = DateTime.MinValue;
        private TeamWorkData data;

        public TeamWork() : this(new TeamWorkData()) { }

        public TeamWork(TeamWorkData d) => data = d;
        public TeamWorkData Data => data;

        public string TeamWorkId => data?.TeamWorkId ?? defaultString;
        public string Name => data?.Name ?? defaultString;
        public string Description => data?.Description ?? defaultString;
        public int TeamSize => data?.TeamSize ?? defaultTeamSize;
        public bool Done => data?.Done ?? defaultDone;
        public DateTime Deadline => data?.Deadline ?? defaultDate;
        public override string ToString() => $"{Name} {Description} ({TeamSize} student(s), {Done}) {Deadline}";

    }
}
