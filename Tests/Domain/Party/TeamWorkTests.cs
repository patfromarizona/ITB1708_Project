using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Data.Party;
using TeamUP.Domain;
using TeamUP.Domain.Party;

namespace TeamUP.Tests.Domain.Party
{
    [TestClass] public class TeamWorkTests : SealedClassTests<TeamWork, Entity<TeamWorkData>> {
        [TestMethod] public void NameTest() => isReadOnly(obj.Data.Name);
        [TestMethod] public void DescriptionTest() => isReadOnly(obj.Data.Description);
        [TestMethod] public void TeamSizeTest() => isReadOnly(obj.Data.TeamSize);
        [TestMethod] public void DoneTest() => isReadOnly(obj.Data.Done);
        [TestMethod] public void DeadlineTest() => isReadOnly(obj.Data.Deadline);
        [TestMethod] public void ToStringTest() => isInconclusive();
        [TestMethod] public void TeamWorkStudentsTest() => testItems<ITeamWorkStudentRepo, TeamWorkStudent, TeamWorkStudentData>(
           d => d.TeamWorkId = obj.Id, d => new TeamWorkStudent(d), () => obj.TeamWorkStudents);
        [TestMethod] public void StudentTest() => isInconclusive();

    }
}
