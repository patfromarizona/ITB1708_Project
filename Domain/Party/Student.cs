

using TeamUP.Data.Party;

namespace TeamUP.Domain.Party
{
    public class Student : Entity<StudentData>
    {
        private const string defaultStr = "Underfined";
        private const bool defaultGender = true;
        private const int defaultAge = 18;
        private const int defalutYear = 1;
       
        public Student() : this(new StudentData()) { }
        public Student(StudentData d) : base(d) { }
        
        public string StudentId => Data?.StudentId ?? defaultStr;
        public string FirstName => Data?.FirstName ?? defaultStr;
        public string LastName => Data?.LastName ?? defaultStr;
        public int Age => Data?.Age ?? defaultAge;
        public bool Gender => Data?.Gender ?? defaultGender;
        public int YearInUniversity => Data?.YearInUniversity ?? defalutYear;
        public override string ToString() => $"{FirstName} {LastName} ({Gender}, {Age} y.o.)";
        
            
        
    }
}
