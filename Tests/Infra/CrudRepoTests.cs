using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Data.Party;
using TeamUP.Infra;
using TeamUP.Domain.Party;

namespace TeamUP.Tests.Infra
{
    [TestClass] public class CrudRepoTests : AbstractClassTests<CrudRepo<Student, StudentData>, BaseRepo<Student, StudentData>>
    {
        private class testClass : CrudRepo<Student, StudentData>
        {
            public testClass(DbContext? c, DbSet<StudentData>? s) : base(c, s) { }
            protected internal override Student toDomain(StudentData d) => new(d);
        }
        protected override CrudRepo<Student, StudentData> createObj() => new testClass(null, null);
    }
}
