using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Data.Party;
using TeamUP.Domain;
using TeamUP.Infra;
using TeamUP.Infra.Initializers;

namespace TeamUP.Tests.Infra.Initializers
{
    [TestClass]
    public class LocationsInitializerTests
        : SealedBaseTests<LocationsInitializer, BaseInitializer<LocationData>>
    {
        protected override LocationsInitializer createObj()
        {
            var db = GetRepo.Instance<TeamUPDb>();
            return new LocationsInitializer(db);
        }
    }
}
