using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Data.Party;
using TeamUP.Domain;
using TeamUP.Domain.Party;

namespace TeamUP.Tests.Domain.Party
{
    [TestClass] public class TeamWorkStudentTests : SealedClassTests<TeamWorkStudent, Entity<TeamWorkStudentData>>
    {
        [TestMethod] public void TeamWorkIdTest() => isReadOnly(obj.Data.TeamWorkId);
        [TestMethod] public void StudentIdTest() => isReadOnly(obj.Data.StudentId);
        [TestMethod] public void TeamWorkTest() => testItem<ITeamWorksRepo, TeamWork, TeamWorkData>(
            obj.TeamWorkId, d => new TeamWork(d), () => obj.TeamWork);
        [TestMethod] public void StudentTest() => testItem<IStudentsRepo, Student, StudentData>(
            obj.StudentId, d => new Student(d), () => obj.Student);
    }
}
