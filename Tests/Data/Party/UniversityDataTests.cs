

using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Data;
using TeamUP.Data.Party;

namespace TeamUP.Tests.Data.Party
{
    [TestClass] public class UniversityDataTests : SealedClassTests<UniversityData, EntityData> 
    {
        [TestMethod] public void NameTest() => isProperty<string>();
        [TestMethod] public void LocationTest() => isProperty<string?>();
        [TestMethod] public void StudentsAmountTest() => isProperty<int?>();
        [TestMethod] public void CostOfStudyingTest() => isProperty<int?>();
        [TestMethod] public void CurrencyTest() => isProperty<string?>();
    }
}