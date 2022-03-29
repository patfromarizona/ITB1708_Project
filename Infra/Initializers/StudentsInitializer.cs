using System.Globalization;
using TeamUP.Data.Party;

namespace TeamUP.Infra.Initializers
{
    public sealed class StudentsInitializer : BaseInitializer<StudentData>
    {
        public StudentsInitializer(TeamUPDb? db) : base(db, db?.Students) { }

        internal StudentData CreateStudent(string firstName, string lastName, bool gender, int age, int yearInUniversity)
        {
            var student = new StudentData
            {
                Id = firstName+lastName,
                FirstName = firstName,
                LastName = lastName,
                Gender = gender,
                Age = age,
                YearInUniversity = yearInUniversity
            };
            return student;
        }

        protected override IEnumerable<StudentData> getEntities => new[] {
            CreateStudent("Gym", "Slavevovich", true, 19, 3),
            CreateStudent("Boss", "Volta", false, 20, 1),
            CreateStudent("Gachi", "Ron", false, 25, 4),
        };
    }

    public sealed class UniversitiesInitializer : BaseInitializer<UniversityData>
    {
        public UniversitiesInitializer(TeamUPDb? db) : base(db, db?.Universities) { }
        protected override IEnumerable<UniversityData> getEntities {
            get
            {
                var l = new List<UniversityData>();
                foreach(CultureInfo cul in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
                {
                    var c = new RegionInfo(new CultureInfo(cul.Name, false).LCID);
                    var d = createUniversity("UniversityOf" + c.EnglishName, c.EnglishName, c.ThreeLetterISORegionName, new Random().Next(100, 5000));
                    l.Add(d);
                }
                return l;
            } 
        }

        internal static UniversityData createUniversity(string universityName, string location, string countryCode, int amountOfStudents) => new ()
        {
            Id = universityName + "Idts",
            UniversityName = universityName,
            Location = location,
            CountryCode = countryCode,
            AmountOfStudents = amountOfStudents

        }; 
    }
}
