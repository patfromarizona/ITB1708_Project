

using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Facade;
using TeamUP.Facade.Party;

namespace TeamUP.Tests.Facade.Party
{
    [TestClass]
    public class LocationViewTests : SealedClassTests<LocationView, BaseView>
    {
        [TestMethod] public void CountryTest() => isInconclusive();
        [TestMethod] public void CurrencyTest() => isInconclusive();

    }
}
