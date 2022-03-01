
using TeamUP.Data.Party;
using TeamUP.Domain.Party;

namespace TeamUP.Facade.Party {
    public class StudentViewFactory {
        public Student Create(StudentView v) => new(new StudentData {
                Id = v.Id,
                FirstName = v.FirstName,
                LastName = v.LastName,
                Gender = v.Gender,
                Age = v.Age,
                YearInUniversity = v.YearInUniversity               
        });
        
        public StudentView Create(Student o) => new() {
            Id = o.Id,
            FirstName = o.FirstName,
            LastName = o.LastName,
            Gender = o.Gender,
            Age = o.Age,
            YearInUniversity = o.YearInUniversity,
            FullName = o.ToString() 
        };
    }
}
