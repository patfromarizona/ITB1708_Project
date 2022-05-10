

using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Facade;
using TeamUP.Facade.Party;

namespace TeamUP.Tests.Facade.Party
{
    [TestClass]
    public class LocationViewTests : SealedClassTests<LocationView, BaseView>
    {

        [TestMethod] public void CountryTest() => isDisplayNamed<string?>("Country");
        [TestMethod] public void CurrencyTest() => isDisplayNamed<string?>("Currency");

    }
}
