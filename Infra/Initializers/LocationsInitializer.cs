using System.Globalization;
using TeamUP.Data.Party;

namespace TeamUP.Infra.Initializers
{
    internal class LocationsInitializer : BaseInitializer<LocationData>
    {
        public LocationsInitializer(TeamUPDb? db) : base(db, db?.Locations) { }

        private static LocationData createLocation(string country, string currency) => new()
        {
            Id = country,
            Country = country,
            Currency = currency,

        };
        protected override IEnumerable<LocationData> getEntities
        {
            get
            {
                // Currently random data
                //TODO find real data
                var l = new List<LocationData>();
                foreach (CultureInfo cul in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
                {
                    Random r = new();
                    var country = new RegionInfo(new CultureInfo(cul.Name, false).LCID);
                    var d = createLocation(country.EnglishName, country.CurrencySymbol);
                    if (l.FirstOrDefault(x => x.Id == d.Id) is not null) continue;
                    l.Add(d);
                }
                return l;
            }
        }
    }
}
