
using TeamUP.Data.Party;

namespace TeamUP.Domain.Party
{
    public interface IUniversityStudentRepo : IRepo<UniversityStudent> { }
    public class UniversityStudent : Entity<UniversityStudentData>
    {
        public UniversityStudent() : this(new()) { }
        public UniversityStudent(UniversityStudentData d) : base(d) { }
        public string UniversityId => getValue(Data?.UniversityId);
        public string StudentId => getValue(Data?.StudentId);
    }
}
