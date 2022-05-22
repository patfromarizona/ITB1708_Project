using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using TeamUP.Data.Party;
using TeamUP.Domain.Party;

namespace TeamUP.Facade.Party
{
    public sealed class LocationView : BaseView
    {
        [DisplayName("Country")] public string? Country { get; set; }
        [DisplayName("Currency")] public string? Currency { get; set; }
    }

    public sealed class LocationViewFactory : BaseViewFactory<LocationView, Location, LocationData>
    {
        protected override Location toEntity(LocationData d) => new(d);
    }
}
