using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Aids;
using TeamUP.Data.Party;
using TeamUP.Domain;
using TeamUP.Domain.Party;

namespace TeamUP.Tests.Domain.Party
{
    [TestClass]
    public class StudentTests : SealedClassTests<Student, Entity<StudentData>>
    {

        protected override Student createObj() => new(GetRandom.Value<StudentData>());
        [TestMethod] public void FirstNameTest() => isReadOnly(obj.Data.FirstName);
        [TestMethod] public void LastNameTest() => isReadOnly(obj.Data.LastName);
        [TestMethod] public void AgeTest() => isReadOnly(obj.Data.Age);
        [TestMethod] public void GenderTest() => isReadOnly(obj.Data.Gender);
        [TestMethod] public void YearInUniversityTest() => isReadOnly(obj.Data.YearInUniversity);
        [TestMethod] public void ToStringTest() => isInconclusive();
        [TestMethod]
        public void StudentTest()
        {
            var c = isReadOnly<Student>();
            isNotNull(c);
            isInstanceOfType(c, typeof(Student));  
        }
    }
}
