using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Data.Party;
using TeamUP.Infra;
using TeamUP.Domain.Party;

namespace TeamUP.Tests.Infra
{
    [TestClass]
    public class RepoTests : AbstractClassTests<Repo<Student, StudentData>, PagedRepo<Student, StudentData>>
    {

        private class testClass : Repo<Student, StudentData>
        {
            public testClass(DbContext? c, DbSet<StudentData>? s) : base(c, s) { }

            protected override Student toDomain(StudentData d) => new(d);
        }
        protected override Repo<Student, StudentData> createObj() => new testClass(null, null);

    }
}
