using TeamUP.Data.Party;

namespace TeamUP.Domain.Party
{
    public interface ITeamWorksRepo : IRepo<TeamWork>{ }
    public sealed class TeamWork : Entity<TeamWorkData>
    {
        public TeamWork() : this(new TeamWorkData()) { }
        public TeamWork(TeamWorkData d) : base(d) { }      
        public string Name => getValue(Data?.Name);
        public string Description => getValue(Data?.Description);
        public int TeamSize => getValue(Data?.TeamSize);
        public bool Done => getValue(Data?.Done);
        public DateTime Deadline => getValue(Data?.Deadline);
        public override string ToString() => $"{Name} {Description} ({TeamSize} student(s), {Done}) {Deadline}";

        public List<TeamWorkStudent> TeamWorkStudents => GetRepo.Instance<ITeamWorkStudentRepo>()?
            .GetAll(x => x.TeamWorkId)?
            .Where(x => x.TeamWorkId == Id)?
            .ToList()?? new List<TeamWorkStudent>();
        public List<Student?> Students => TeamWorkStudents
            .Select(x => x.Student)
            .ToList()?? new List<Student?>();

    }
}
