using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TeamUP.Aids;
using TeamUP.Data.Party;
using TeamUP.Domain;
using TeamUP.Domain.Party;
using TeamUP.Infra.Party;

namespace TeamUP.Tests.Domain.Party
{
    [TestClass] public class StudentTests : SealedClassTests<Student, Entity<StudentData>> {

        [TestInitialize] public void TestInitialize() => (GetRepo.Instance<IStudentsRepo>() as StudentsRepo)?.clear();
        
        protected override Student createObj() => new(GetRandom.Value<StudentData>());
        [TestMethod] public void FirstNameTest() => isReadOnly(obj.Data.FirstName);
        [TestMethod] public void LastNameTest() => isReadOnly(obj.Data.LastName);
        [TestMethod] public void AgeTest() => isReadOnly(obj.Data.Age);
        [TestMethod] public void GenderTest() => isReadOnly(obj.Data.Gender);
        [TestMethod] public void YearInUniversityTest() => isReadOnly(obj.Data.YearInUniversity);
        [TestMethod] public void ToStringTest()
        {
            var expected = $"{obj.FirstName} {obj.LastName} ({obj.Gender.Description()}, {obj.Age} y.o.)";
            areEqual(expected, obj.ToString());
        }
        [TestMethod] public void TeamWorkStudentsTest()
            => testItems<ITeamWorkStudentRepo, TeamWorkStudent, TeamWorkStudentData>(
           d => d.StudentId = obj.Id, d => new TeamWorkStudent(d), () => obj.TeamWorkStudents);
        [TestMethod] public void UniversityStudentsTest()
            => testItems<IUniversityStudentRepo, UniversityStudent, UniversityStudentData>(
           d => d.StudentId = obj.Id, d => new UniversityStudent(d), () => obj.UniversityStudents);
        [TestMethod] public void UniversitiesTest() => relatedItemsTest<IUniversitiesRepo, UniversityStudent, University, UniversityData>
            (() => UniversityStudentsTest(),
            () => obj.UniversityStudents,
            () => obj.Universities,
            x => x.UniversityId,
            d => new University(d),
            t => t?.Data,
            x => x?.University?.Data);

        [TestMethod] public void TeamWorksTest() => relatedItemsTest<ITeamWorksRepo, TeamWorkStudent, TeamWork, TeamWorkData>
            (() => TeamWorkStudentsTest(),
            () => obj.TeamWorkStudents,
            () => obj.TeamWorks,
            x => x.TeamWorkId,
            d => new TeamWork(d),
            t => t?.Data,
            x => x?.TeamWork?.Data);

    }
}
