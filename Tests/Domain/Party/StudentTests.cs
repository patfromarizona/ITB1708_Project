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
        [TestMethod] public void ToStringTest() => isInconclusive();
        [TestMethod] public void TeamWorkStudentsTest() => testItems<ITeamWorkStudentRepo, TeamWorkStudent, TeamWorkStudentData>(
           d => d.StudentId = obj.Id, d => new TeamWorkStudent(d), () => obj.TeamWorkStudents);
        [TestMethod] public void TeamWorkTest() => isInconclusive();
        [TestMethod] public void UniversityStudentsTest() => testItems<IUniversityStudentRepo, UniversityStudent, UniversityStudentData>(
           d => d.StudentId = obj.Id, d => new UniversityStudent(d), () => obj.UniversityStudents);
        [TestMethod] public void UniversityTest() => isInconclusive();

    }
}
