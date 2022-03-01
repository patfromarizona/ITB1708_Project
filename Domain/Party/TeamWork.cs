using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamUP.Data.Party;

namespace TeamUP.Domain.Party
{
    public class TeamWork : Entity<TeamWorkData>
    {
        private const string defaultString = "Undefined";
        private const bool defaultDone = false;
        private const int defaultTeamSize = 1;
        private DateTime defaultDate = DateTime.MinValue;


        public TeamWork() : this(new TeamWorkData()) { }
        public TeamWork(TeamWorkData d) : base(d) { }      
        public string Id => Data?.Id ?? defaultString;
        public string Name => Data?.Name ?? defaultString;
        public string Description => Data?.Description ?? defaultString;
        public int TeamSize => Data?.TeamSize ?? defaultTeamSize;
        public bool Done => Data?.Done ?? defaultDone;
        public DateTime Deadline => Data?.Deadline ?? defaultDate;
        public override string ToString() => $"{Name} {Description} ({TeamSize} student(s), {Done}) {Deadline}";

    }
}
