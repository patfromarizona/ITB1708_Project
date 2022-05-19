using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Data.Party;
using TeamUP.Infra;
using TeamUP.Domain.Party;
using TeamUP.Aids;
using TeamUP.Domain;

namespace TeamUP.Tests.Infra
{
    [TestClass] public class FilteredRepoTests : AbstractClassTests<FilteredRepo<Student, StudentData>, CrudRepo<Student, StudentData>>
    {
        private class testClass : FilteredRepo<Student, StudentData>
        {
            public testClass(DbContext? c, DbSet<StudentData>? s) : base(c, s) { }
            protected internal override Student toDomain(StudentData d) => new(d);
        }
        protected override FilteredRepo<Student, StudentData> createObj()
        {
            var db = GetRepo.Instance<TeamUPDb>();
            var set = db.Students;
            return new testClass(db, set);        
        }
        [TestMethod] public void CurrentFilterTest() => isProperty<string>();
        [DataRow(true)]
        [DataRow(false)]
        [TestMethod] public void createSqlTest(bool hasCurrentFilter) {
            obj.CurrentFilter = hasCurrentFilter ? GetRandom.String(): null;
            var q1 = obj.createSql();
            var q2 = obj.addFilter(q1);
            areEqual(q1, q2);
            var s = q1.Expression.ToString();
            isTrue(s.EndsWith(".Select(s => s)"));
        }
    }

}
