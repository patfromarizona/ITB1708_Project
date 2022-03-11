using TeamUP.Data.Party;

namespace TeamUP.Domain.Party
{
    public interface IStudentsRepo : IRepo<Student> { }
    public class Student : Entity<StudentData>
    {
        public Student() : this(new StudentData()) { }
        public Student(StudentData d) : base(d) { }
        public string FirstName => Data?.FirstName ?? defaultStr;
        public string LastName => Data?.LastName ?? defaultStr;
        public int Age => Data?.Age ?? defaultAge;
        public bool Gender => Data?.Gender ?? defaultGender;
        public int YearInUniversity => Data?.YearInUniversity ?? defalutYear;
        public override string ToString() => $"{FirstName} {LastName} ({Gender}, {Age} y.o.)";     
    }
}
