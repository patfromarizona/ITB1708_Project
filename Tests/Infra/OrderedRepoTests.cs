using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Data.Party;
using TeamUP.Infra;
using TeamUP.Domain.Party;
using TeamUP.Aids;
using TeamUP.Domain;

namespace TeamUP.Tests.Infra
{
    [TestClass] public class OrderedRepoTests : AbstractClassTests<OrderedRepo<Student, StudentData>, FilteredRepo<Student, StudentData>>
    {
        private class testClass : OrderedRepo<Student, StudentData>
        {
            public testClass(DbContext? c, DbSet<StudentData>? s) : base(c, s) { }
            protected internal override Student toDomain(StudentData d) => new(d);
        }
        protected override OrderedRepo<Student, StudentData> createObj() { 
        var db = GetRepo.Instance<TeamUPDb>();
            var set = db.Students;
            return new testClass(db, set);
        }
            
        [TestMethod] public void CurrentOrderTest() => isProperty<string>();
        [TestMethod] public void DescendingStringTest() => areEqual("_desc", testClass.DescendingString);
        
        [DataRow(null, true)]
        [DataRow(null, false)]
        [DataRow(nameof(Student.Id), true)]
        [DataRow(nameof(Student.Id), false)]
        [DataRow(nameof(Student.FirstName), true)]
        [DataRow(nameof(Student.FirstName), false)]
        [DataRow(nameof(Student.LastName), true)]
        [DataRow(nameof(Student.LastName), false)]
        [DataRow(nameof(Student.Age), true)]
        [DataRow(nameof(Student.Age), false)]
        [DataRow(nameof(Student.YearInUniversity), true)]
        [DataRow(nameof(Student.YearInUniversity), false)]

        [TestMethod] public void createSqlTest(string s, bool isDescending)
        {
            obj.CurrentOrder = (s is null) ? s : isDescending ? s + testClass.DescendingString: s;
            var q = obj.createSql();
            var actual = q.Expression.ToString();
            if (s is null) isTrue(actual.EndsWith(".Select(s => s)"));
            else if (isDescending) isTrue(actual.EndsWith(
                 $".Select(s => s).OrderByDescending(x => Convert(x.{s}, Object))"));
            else isTrue(actual.EndsWith(
                 $".Select(s => s).OrderBy(x => Convert(x.{s}, Object))"));
        }
        [DataRow(true, true)]
        [DataRow(false, false)]
        [DataRow(true, false)]
        [DataRow(false, true)]
        [TestMethod] public void SortOrderTest(bool isDescending, bool isSame) {
            var s = GetRandom.String();
            var c = isSame ? s : GetRandom.String();
            obj.CurrentOrder = isDescending ? c + testClass.DescendingString : c;
            var actual = obj.SortOrder(s);
            var sDes = s + testClass.DescendingString;
            var expected = isSame ? (isDescending ? s : sDes) : sDes;
            areEqual(expected, actual);
        }
    }

}
