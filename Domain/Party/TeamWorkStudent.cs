
using TeamUP.Data.Party;

namespace TeamUP.Domain.Party
{
    public interface ITeamWorkStudentRepo : IRepo<TeamWorkStudent> { }
    public class TeamWorkStudent : Entity<TeamWorkStudentData>
    {
        public TeamWorkStudent() : this(new ()) { }
        public TeamWorkStudent(TeamWorkStudentData d) : base(d) { }
        public string TeamWorkId => getValue(Data?.TeamWorkId);
        public string StudentId => getValue(Data?.StudentId);

        public TeamWork? TeamWork => GetRepo.Instance<ITeamWorksRepo>()?.Get(TeamWorkId);
        public Student? Student => GetRepo.Instance<IStudentsRepo>()?.Get(StudentId);
    }
}
