using TeamUP.Aids;
using TeamUP.Data.Party;

namespace TeamUP.Domain.Party
{
    public interface IStudentsRepo : IRepo<Student> { }
    public class Student : Entity<StudentData>
    {
        public Student() : this(new StudentData()) { }
        public Student(StudentData d) : base(d) { }
        public string FirstName => getValue(Data?.FirstName);
        public string LastName => getValue(Data?.LastName);
        public int Age => getValue(Data?.Age);
        public IsoGender Gender => getValue(Data?.Gender);
        public int YearInUniversity => getValue(Data?.YearInUniversity);
        public override string ToString() => $"{FirstName} {LastName} ({Gender.Description()}, {Age} y.o.)";     
    }
}
