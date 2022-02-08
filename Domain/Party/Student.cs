

using TeamUP.Data.Party;

namespace TeamUP.Domain.Party
{
    public class Student
    {
        private const string defaultStr = "Underfined";
        private const bool defaultGender = true;
        private const int defaultAge = 18;
        private const int defalutYear = 1;
        private StudentData data;
        public Student() : this(new StudentData()) { }
        public Student(StudentData d) => data = d;
        public StudentData Data => data;
        public string StudentId => data?.StudentId ?? defaultStr;
        public string FirstName => data?.FirstName ?? defaultStr;
        public string LastName => data?.LastName ?? defaultStr;
        public int Age => data?.Age ?? defaultAge;
        public bool Gender => data?.Gender ?? defaultGender;
        public int YearInUniversity => data?.YearInUniversity ?? defalutYear;
        public override string ToString() => $"{FirstName} {LastName} ({Gender}, {Age} y.o.)";
        
            
        
    }
}
