

using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Facade;
using TeamUP.Facade.Party;

namespace TeamUP.Tests.Facade.Party
{
    [TestClass]
    public class UniversityViewTests : SealedClassTests<UniversityView, BaseView>
    {

        [TestMethod] public void NameTest() => isDisplayNamed<string>("University Name");
        [TestMethod] public void LocationTest() => isDisplayNamed<string?>("Location");
        [TestMethod] public void StudentsAmountTest() => isDisplayNamed<int?>("Amount of students");
        [TestMethod] public void CostOfStudyingTest() => isDisplayNamed<int?>("Cost of education");
        [TestMethod] public void CurrencyTest() => isDisplayNamed<string?>("Currency");
    }
}
