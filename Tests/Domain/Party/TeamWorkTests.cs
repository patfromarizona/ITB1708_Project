using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Aids;
using TeamUP.Data.Party;
using TeamUP.Domain;
using TeamUP.Domain.Party;
using TeamUP.Infra.Party;

namespace TeamUP.Tests.Domain.Party
{
    [TestClass] public class TeamWorkTests : SealedClassTests<TeamWork, Entity<TeamWorkData>> {
        [TestInitialize] public void TestInitialize() => (GetRepo.Instance<IStudentsRepo>() as StudentsRepo)?.clear();
        protected override TeamWork createObj() => new(GetRandom.Value<TeamWorkData>());
        [TestMethod] public void NameTest() => isReadOnly(obj.Data.Name);
        [TestMethod] public void DescriptionTest() => isReadOnly(obj.Data.Description);
        [TestMethod] public void TeamSizeTest() => isReadOnly(obj.Data.TeamSize);
        [TestMethod] public void DoneTest() => isReadOnly(obj.Data.Done);
        [TestMethod] public void DeadlineTest() => isReadOnly(obj.Data.Deadline);
        [TestMethod] public void ToStringTest()
        {
            var expected = $"{obj.Name} {obj.Description} ({obj.TeamSize} student(s), {obj.Done}) {obj.Deadline}";
            areEqual(expected, obj.ToString());
        }
        [TestMethod] public void TeamWorkStudentsTest() => testItems<ITeamWorkStudentRepo, TeamWorkStudent, TeamWorkStudentData>(
           d => d.TeamWorkId = obj.Id, d => new TeamWorkStudent(d), () => obj.TeamWorkStudents);
        [TestMethod] public void StudentsTest() => relatedItemsTest<IStudentsRepo, TeamWorkStudent, Student, StudentData>
            (() => TeamWorkStudentsTest(),
            () => obj.TeamWorkStudents,
            () => obj.Students,
            x => x.TeamWorkId,
            d => new Student(d),
            s => s?.Data,
            x => x?.Student?.Data);
        

    }
}
