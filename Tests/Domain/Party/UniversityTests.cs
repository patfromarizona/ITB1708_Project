using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Aids;
using TeamUP.Data.Party;
using TeamUP.Domain;
using TeamUP.Domain.Party;
using TeamUP.Infra.Party;

namespace TeamUP.Tests.Domain.Party
{
    [TestClass] public class UniversityTests: SealedClassTests<University, Entity<UniversityData>>
    {
        [TestInitialize] public void TestInitialize() => (GetRepo.Instance<IStudentsRepo>() as StudentsRepo)?.clear();
        protected override University createObj() => new(GetRandom.Value<UniversityData>());
        [TestMethod] public void NameTest() => isReadOnly(obj.Data.Name);
        [TestMethod] public void LocationTest() => isReadOnly(obj.Data.Location);
        [TestMethod] public void StudentsAmountTest() => isReadOnly(obj.Data.StudentsAmount);
        [TestMethod] public void CostOfStudyingTest() => isReadOnly(obj.Data.CostOfStudying);
        [TestMethod] public void CurrencyTest() => isReadOnly(obj.Data.Currency);
        [TestMethod] public void ToStringTest()
        {
            var expected = $"{obj.Name}, {obj.Location}, {obj.StudentsAmount} students (average price: {obj.CostOfStudying} {obj.Currency} / year)";
            areEqual(expected, obj.ToString());
        }
        [TestMethod] public void UniversityStudentsTest()
            => testItems<IUniversityStudentRepo, UniversityStudent, UniversityStudentData>(
           d => d.UniversityId = obj.Id, d => new UniversityStudent(d), () => obj.UniversityStudents);
        [TestMethod] public void StudentsTest() => relatedItemsTest<IStudentsRepo, UniversityStudent, Student, StudentData>
            (() => UniversityStudentsTest(),
            () => obj.UniversityStudents,
            () => obj.Students,
            x => x.StudentId,
            d => new Student(d),
            s => s?.Data,
            x => x?.Student?.Data);
    }
}
