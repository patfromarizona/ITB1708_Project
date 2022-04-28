using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Data.Party;
using TeamUP.Domain;
using TeamUP.Domain.Party;

namespace TeamUP.Tests.Domain.Party
{
    [TestClass] public class TeamWorkTests : SealedClassTests<TeamWork, Entity<TeamWorkData>> {
        [TestMethod] public void TeamWorkTest() => isInconclusive();
        [TestMethod] public void NameTest() => isInconclusive();
        [TestMethod] public void DescriptionTest() => isInconclusive();
        [TestMethod] public void TeamSizeTest() => isInconclusive();
        [TestMethod] public void DoneTest() => isInconclusive();
        [TestMethod] public void DeadlineTest() => isInconclusive();
        [TestMethod] public void ToStringTest() => isInconclusive();
        [TestMethod] public void TeamWorkStudentsTest() => isInconclusive();
        [TestMethod] public void StudentsTest() => isInconclusive();

    }
}
