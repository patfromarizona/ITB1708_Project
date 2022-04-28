using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Data.Party;
using TeamUP.Domain;
using TeamUP.Domain.Party;

namespace TeamUP.Tests.Domain.Party
{
    [TestClass] public class UniversityTests: SealedClassTests<University, Entity<UniversityData>>
    {
        [TestMethod] public void UniversityTest() => isInconclusive();
        [TestMethod] public void NameTest() => isInconclusive();
        [TestMethod] public void LocationTest() => isInconclusive();
        [TestMethod] public void StudentsAmountTest() => isInconclusive();
        [TestMethod] public void CostOfStudyingTest() => isInconclusive();
        [TestMethod] public void CurrencyTest() => isInconclusive();
        [TestMethod] public void ToStringTest() => isInconclusive();
    }
}
