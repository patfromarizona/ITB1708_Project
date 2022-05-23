using TeamUP.Domain.Party;
using TeamUP.Facade.Party;

namespace TeamUP.Pages.Party {
    public class LocationsPage : PagedPage<LocationView, Location, ILocationsRepo> {
        public LocationsPage(ILocationsRepo r) : base(r) { }
        protected override Location toObject(LocationView? item) => new LocationViewFactory().Create(item);
        protected override LocationView toView(Location? entity) => new LocationViewFactory().Create(entity);
    }
}
