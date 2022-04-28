using TeamUP.Data.Party;

namespace TeamUP.Domain.Party
{
    public interface ILocationsRepo : IRepo<Location> { }
    public sealed class Location : Entity<LocationData>
    {
        public Location() : this(new LocationData()) { }
        public Location(LocationData d) : base(d) { }
        public string Country => getValue(Data?.Country);
        public string Currency => getValue(Data?.Currency);
    }
}
