using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Data.Party;
using TeamUP.Domain;
using TeamUP.Domain.Party;

namespace TeamUP.Tests.Domain.Party
{
    [TestClass] public class UniversityTests: SealedClassTests<University, Entity<UniversityData>>
    {
        [TestMethod] public void NameTest() => isReadOnly(obj.Data.Name);
        [TestMethod] public void LocationTest() => isReadOnly(obj.Data.Location);
        [TestMethod] public void StudentsAmountTest() => isReadOnly(obj.Data.StudentsAmount);
        [TestMethod] public void CostOfStudyingTest() => isReadOnly(obj.Data.CostOfStudying);
        [TestMethod] public void CurrencyTest() => isReadOnly(obj.Data.Currency);
        [TestMethod] public void ToStringTest() => isInconclusive();
        [TestMethod] public void UniversityStudentsTest() => testItems<IUniversityStudentRepo, UniversityStudent, UniversityStudentData>(
           d => d.UniversityId = obj.Id, d => new UniversityStudent(d), () => obj.UniversityStudents);
        [TestMethod] public void StudentTest() => isInconclusive();
    }
}
