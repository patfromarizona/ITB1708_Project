﻿

using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Facade.Party;

namespace TeamUP.Tests.Facade.Party
{
    [TestClass]
    public class StudentViewTests : SealedClassTests<StudentView>
    {
        [TestMethod] public void IdTest() => isProperty<string>();
        [TestMethod] public void FirstNameTest() => isProperty<string?>();
        [TestMethod] public void LastNameTest() => isProperty<string?>();
        [TestMethod] public void GenderTest() => isProperty<bool?>();
        [TestMethod] public void AgeTest() => isProperty<int?>();
        [TestMethod] public void YearInUniversityTest() => isProperty<int?>();
        [TestMethod] public void FullNameTest() => isProperty<string>();
    }
}
