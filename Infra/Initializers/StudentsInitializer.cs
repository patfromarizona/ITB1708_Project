using TeamUP.Data.Party;

namespace TeamUP.Infra.Initializers {
    public sealed class StudentsInitializer : BaseInitializer<StudentData> {
        public StudentsInitializer(TeamUPDb? db) : base(db, db?.Students) { }

        private static StudentData createStudent(string firstName, string lastName, IsoGender gender, int age, int yearInUniversity) {
            var student = new StudentData {
                Id = firstName + lastName,
                FirstName = firstName,
                LastName = lastName,
                Gender = gender,
                Age = age,
                YearInUniversity = yearInUniversity
            };
            return student;
        }

        protected override IEnumerable<StudentData> getEntities => new[]
        {

            createStudent("Greg", "Homie", IsoGender.Male, 19, 1),
            createStudent("Tom", "Brown", IsoGender.Female, 21, 2),
            createStudent("Mark", "Frankfurt", IsoGender.NotApplicable, 22, 3),
        };
    }
}
