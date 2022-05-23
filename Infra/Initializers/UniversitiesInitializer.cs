using System.Globalization;
using TeamUP.Data.Party;

namespace TeamUP.Infra.Initializers {
    public sealed class UniversitiesInitializer : BaseInitializer<UniversityData> {
        public UniversitiesInitializer(TeamUPDb? db) : base(db, db?.Universities) { }

        private static UniversityData createUniversity(string universityName, string universityLocation, int amountOfStudents, int costOfEducation, string currency) => new() {
            Id = universityName.Replace(" ", "") + "Id",
            Name = universityName,
            Location = universityLocation,
            StudentsAmount = amountOfStudents,
            CostOfStudying = costOfEducation,
            Currency = currency

        };

        protected override IEnumerable<UniversityData> getEntities {
            get {
                // Currently random data
                //TODO find real data
                var l = new List<UniversityData>();
                foreach (CultureInfo cul in CultureInfo.GetCultures(CultureTypes.SpecificCultures)) {
                    Random r = new();
                    var country = new RegionInfo(new CultureInfo(cul.Name, false).LCID);
                    var d = createUniversity("University of " + country.EnglishName, country.EnglishName, r.Next(500, 5000), r.Next(0, 10000), country.CurrencySymbol);
                    if (l.FirstOrDefault(x => x.Id == d.Id) is not null) continue;
                    l.Add(d);
                }
                return l;
            }
        }
    }
}
