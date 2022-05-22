
using TeamUP.Data.Party;
using TeamUP.Domain.Party;

namespace TeamUP.Infra.Party
{
    public sealed class LocationsRepo : Repo<Location, LocationData>, ILocationsRepo
    {
        public LocationsRepo(TeamUPDb? db) : base(db, db?.Locations) { }
        protected internal override Location toDomain(LocationData d) => new(d);
        internal override IQueryable<LocationData> addFilter(IQueryable<LocationData> q)
        {
            var y = CurrentFilter;
            if (string.IsNullOrWhiteSpace(y)) return q;
            return q.Where(
            x => x.Id.Contains(y)
            || x.Country.Contains(y)
            || x.Currency.Contains(y));
        }

    }
}
