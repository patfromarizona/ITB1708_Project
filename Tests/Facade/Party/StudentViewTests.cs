

using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Data.Party;
using TeamUP.Facade;
using TeamUP.Facade.Party;

namespace TeamUP.Tests.Facade.Party
{
    [TestClass]
    public class StudentViewTests : SealedClassTests<StudentView, BaseView>
    {
        [TestMethod] public void IdTest() => isProperty<string>();
        [TestMethod] public void FirstNameTest() => isProperty<string?>();
        [TestMethod] public void LastNameTest() => isProperty<string?>();
        [TestMethod] public void GenderTest() => isProperty<IsoGender?>();
        [TestMethod] public void AgeTest() => isProperty<int?>();
        [TestMethod] public void YearInUniversityTest() => isProperty<int?>();
        [TestMethod] public void FullNameTest() => isProperty<string>();
    }
}
