

using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Data.Party;

namespace TeamUP.Tests.Data.Party
{
    [TestClass]
    public class StudentDataTests : BaseTests<StudentData>{ 
        [TestMethod] public void IdTest() => isProperty<string>();
        [TestMethod] public void FirstNameTest() => isProperty<string?>(); 
        [TestMethod] public void LastNameTest() => isProperty<string?>();
        [TestMethod] public void GenderTest() => isProperty<bool?>();
        [TestMethod] public void AgeTest() => isProperty<int?>();
        [TestMethod] public void YearInUniversityTest() => isProperty<int?>();
    }

    /*public class StudentBaseTests : AssertTests
    {
        protected void isProperty<T>(T value = default, bool isReadOnly = false) => inconclusive();   
    }*/

    
    




}