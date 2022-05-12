using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Data.Party;
using TeamUP.Infra;
using TeamUP.Domain.Party;

namespace TeamUP.Tests.Infra
{
    [TestClass] public class OrderedRepoTests : AbstractClassTests<OrderedRepo<Student, StudentData>, FilteredRepo<Student, StudentData>>
    {
        private class testClass : OrderedRepo<Student, StudentData>
        {
            public testClass(DbContext? c, DbSet<StudentData>? s) : base(c, s) { }
            protected internal override Student toDomain(StudentData d) => new(d);
        }
        protected override OrderedRepo<Student, StudentData> createObj() => new testClass(null, null);
    }
}
