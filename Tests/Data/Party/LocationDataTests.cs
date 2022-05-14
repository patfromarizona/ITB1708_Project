

using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Data;
using TeamUP.Data.Party;
using TeamUP.Domain;

namespace TeamUP.Tests.Data.Party
{
    [TestClass] public class LocationDataTests : SealedClassTests<LocationData, EntityData> 
    {
        [TestMethod] public void CountryTest() => isProperty<string?>();
        [TestMethod] public void CurrencyTest() => isProperty<string?>();
    }
}