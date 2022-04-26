

using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Data.Party;

namespace TeamUP.Tests.Data.Party
{
    [TestClass] public class LocationDataTests : SealedClassTests<LocationData> 
    {
        [TestMethod] public void CountryTest() => isProperty<string?>();
        [TestMethod] public void CurrencyTest() => isProperty<string?>();
    }







}