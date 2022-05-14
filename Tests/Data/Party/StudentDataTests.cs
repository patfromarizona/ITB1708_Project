

using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Data;
using TeamUP.Data.Party;
using TeamUP.Domain;

namespace TeamUP.Tests.Data.Party
{
    [TestClass] public class StudentDataTests : SealedClassTests<StudentData, EntityData>{ 
        [TestMethod] public void IdTest() => isProperty<string>();
        [TestMethod] public void FirstNameTest() => isProperty<string?>(); 
        [TestMethod] public void LastNameTest() => isProperty<string?>();
        [TestMethod] public void GenderTest() => isProperty<IsoGender?>();
        [TestMethod] public void AgeTest() => isProperty<int?>();
        [TestMethod] public void YearInUniversityTest() => isProperty<int?>();
    }
}