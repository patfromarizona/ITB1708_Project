using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Data.Party;
using TeamUP.Domain;
using TeamUP.Domain.Party;

namespace TeamUP.Tests.Domain.Party
{
    [TestClass] public class UniversityStudentTests : SealedClassTests<UniversityStudent, Entity<UniversityStudentData>>
    {
        [TestMethod] public void UniversityStudentTest() => isInconclusive();
        [TestMethod] public void UniversityIdTest() => isInconclusive();
        [TestMethod] public void StudentIdTest() => isInconclusive();
    }
}
