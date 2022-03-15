using TeamUP.Data.Party;

namespace TeamUP.Domain.Party
{
    public interface ITeamWorksRepo : IRepo<TeamWork>{ }
    public class TeamWork : Entity<TeamWorkData>
    {
        public TeamWork() : this(new TeamWorkData()) { }
        public TeamWork(TeamWorkData d) : base(d) { }      
        public string Name => getValue(Data?.Name);
        public string Description => getValue(Data?.Description);
        public int TeamSize => getValue(Data?.TeamSize);
        public bool Done => getValue(Data?.Done);
        public DateTime Deadline => getValue(Data?.Deadline);
        public override string ToString() => $"{Name} {Description} ({TeamSize} student(s), {Done}) {Deadline}";

    }
}
