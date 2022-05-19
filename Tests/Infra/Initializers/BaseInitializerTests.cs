using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TeamUP.Data.Party;
using TeamUP.Domain;
using TeamUP.Infra;
using TeamUP.Infra.Initializers;

namespace TeamUP.Tests.Infra.Initializers
{
    [TestClass]
    public class BaseInitializerTests
        : AbstractClassTests<BaseInitializer<StudentData>, object>
    {
        private class testClass : BaseInitializer<StudentData>
        {
            public testClass(DbContext? c, DbSet<StudentData>? s) : base(c, s) { }

            protected override IEnumerable<StudentData> getEntities => throw new NotImplementedException();
        }
        protected override BaseInitializer<StudentData> createObj()
        {
            var db = GetRepo.Instance<TeamUPDb>();
            return new StudentsInitializer(db);
        }
    }
}
