

using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Data.Party;
using TeamUP.Facade;
using TeamUP.Facade.Party;

namespace TeamUP.Tests.Facade.Party
{
    [TestClass]
    public class StudentViewTests : SealedClassTests<StudentView, BaseView>
    {

        [TestMethod] public void IdTest() => isRequired<string>();
        [TestMethod] public void FirstNameTest() => isDisplayNamed<string?>("First Name");
        [TestMethod] public void LastNameTest() => isDisplayNamed<string?>("Last Name");
        [TestMethod] public void GenderTest() => isProperty<IsoGender?>();
        [TestMethod] public void AgeTest() => isDisplayNamed<int?>("Age");
        [TestMethod] public void YearInUniversityTest() => isDisplayNamed<int?>("Year in University");
        [TestMethod] public void FullNameTest() => isDisplayNamed<string?>("Full Name");
    }
}
