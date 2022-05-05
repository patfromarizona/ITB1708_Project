using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TeamUP.Aids;
using TeamUP.Data.Party;
using TeamUP.Domain;
using TeamUP.Domain.Party;
using TeamUP.Infra.Party;

namespace TeamUP.Tests.Domain.Party
{
    [TestClass]
    public class LocationTests : SealedClassTests<Location, Entity<LocationData>>
    {
        protected override Location createObj() => new(GetRandom.Value<LocationData>());
        [TestMethod] public void CountryTest() => isReadOnly(obj.Data.Country);
        [TestMethod] public void CurrencyTest() => isReadOnly(obj.Data.Currency);
        [TestMethod] public void LocaTest() => testItem<ILocationsRepo, Location, LocationData>(
            obj.Id, d => new Location(d), () => obj.Loca);        
    }
}
