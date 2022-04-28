using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Data.Party;
using TeamUP.Domain;
using TeamUP.Domain.Party;

namespace TeamUP.Tests.Domain.Party
{
    [TestClass] public class TeamWorkStudentTests : SealedClassTests<TeamWorkStudent, Entity<TeamWorkStudentData>>
    {
        [TestMethod] public void TeamWorkStudentTest() => isInconclusive();
        [TestMethod] public void TeamWorkIdTest() => isInconclusive();
        [TestMethod] public void StudentIdTest() => isInconclusive();
        [TestMethod] public void TeamWorkTest() => isInconclusive();
        [TestMethod] public void StudentTest() => isInconclusive();
    }
}
