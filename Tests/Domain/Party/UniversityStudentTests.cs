using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Data.Party;
using TeamUP.Domain;
using TeamUP.Domain.Party;

namespace TeamUP.Tests.Domain.Party
{
    [TestClass] public class UniversityStudentTests : SealedClassTests<UniversityStudent, Entity<UniversityStudentData>>
    {
        [TestMethod] public void UniversityIdTest() => isReadOnly(obj.Data.UniversityId);
        [TestMethod] public void StudentIdTest() => isReadOnly(obj.Data.StudentId);
        [TestMethod] public void UniversityTest() => testItem<IUniversitiesRepo, University, UniversityData>(
            obj.UniversityId, d => new University(d), () => obj.University);
        [TestMethod] public void StudentTest() => testItem<IStudentsRepo, Student, StudentData>(
            obj.StudentId, d => new Student(d), () => obj.Student);
    }
}
