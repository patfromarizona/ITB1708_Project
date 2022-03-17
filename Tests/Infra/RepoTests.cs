using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Data.Party;
using TeamUP.Domain;
using TeamUP.Domain.Party;

namespace TeamUP.Tests.Infra
{
    [TestClass]
    public class RepoTests : AbstractClassTests
    {

        private class testClass : Repo<Student, StudentData>
        {
            public testClass(DbContext? c, DbSet<StudentData>? s) : base(c, s) { }

            protected override Student toDomain(StudentData d) => new(d);
        }
        protected override object createObj() => new testClass(null, null);

    }
}
