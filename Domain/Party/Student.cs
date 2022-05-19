using TeamUP.Aids;
using TeamUP.Data.Party;

namespace TeamUP.Domain.Party
{
    public interface IStudentsRepo : IRepo<Student> { }
    public sealed class Student : Entity<StudentData>, IComparable
    {
        public Student() : this(new ()) { }
        public Student(StudentData d) : base(d) { }
        public string FirstName => getValue(Data?.FirstName);
        public string LastName => getValue(Data?.LastName);
        public int Age => getValue(Data?.Age);
        public IsoGender Gender => getValue(Data?.Gender);
        public int YearInUniversity => getValue(Data?.YearInUniversity);
        public override string ToString() => $"{FirstName} {LastName} ({Gender.Description()}, {Age} y.o.)";

        public int CompareTo(object? x) => compareTo(x as Student);

        private int compareTo(Student? s) => FirstName.CompareTo(s.FirstName);

        public List<TeamWorkStudent> TeamWorkStudents
            => GetRepo.Instance<ITeamWorkStudentRepo>()?
            .GetAll(x => x.StudentId)?
            .Where(x => x.StudentId == Id)?
            .ToList() ?? new List<TeamWorkStudent>();
        public List<TeamWork?> TeamWorks => TeamWorkStudents
            .Select(x => x.TeamWork)
            .ToList() ?? new List<TeamWork?>();

        public List<UniversityStudent> UniversityStudents => GetRepo.Instance<IUniversityStudentRepo>()?
           .GetAll(x => x.StudentId)?
           .Where(x => x.StudentId == Id)?
           .ToList() ?? new List<UniversityStudent>();
        public List<University?> Universities => UniversityStudents
            .Select(x => x.University)
            .ToList() ?? new List<University?>();
    }
}
