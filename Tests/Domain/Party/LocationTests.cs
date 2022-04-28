using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Data.Party;
using TeamUP.Domain;
using TeamUP.Domain.Party;

namespace TeamUP.Tests.Domain.Party
{
    [TestClass]
    public class LocationTests : SealedClassTests<Location, Entity<LocationData>>
    {
        [TestMethod] public void LocationTest() => isInconclusive();
        [TestMethod] public void CountryTest() => isInconclusive();
        [TestMethod] public void CurrencyTest() => isInconclusive();
    }
}
