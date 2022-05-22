using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Aids;
using TeamUP.Data.Party;
using TeamUP.Domain.Party;
using TeamUP.Facade;
using TeamUP.Facade.Party;

namespace TeamUP.Tests.Facade.Party
{
    [TestClass]
    public class LocationViewFactoryTests : ViewFactoryTests<LocationViewFactory, LocationView, Location, LocationData>
    {
        protected override Location toObject(LocationData d) => new(d);
    }
}
