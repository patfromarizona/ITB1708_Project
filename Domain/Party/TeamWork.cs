using TeamUP.Data.Party;

namespace TeamUP.Domain.Party
{
    public interface ITeamWorksRepo : IRepo<TeamWork>{ }
    public class TeamWork : Entity<TeamWorkData>
    {
        public TeamWork() : this(new TeamWorkData()) { }
        public TeamWork(TeamWorkData d) : base(d) { }      
        public string Name => Data?.Name ?? defaultStr;
        public string Description => Data?.Description ?? defaultStr;
        public int TeamSize => Data?.TeamSize ?? defaultTeamSize;
        public bool Done => Data?.Done ?? defaultDone;
        public DateTime Deadline => Data?.Deadline ?? defaultDate;
        public override string ToString() => $"{Name} {Description} ({TeamSize} student(s), {Done}) {Deadline}";

    }
}
