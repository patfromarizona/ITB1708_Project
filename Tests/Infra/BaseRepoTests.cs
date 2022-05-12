using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Data.Party;
using TeamUP.Infra;
using TeamUP.Domain.Party;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TeamUP.Tests.Infra
{
    [TestClass] public class BaseRepoTests : AbstractClassTests<BaseRepo<Student, StudentData>, object>
    {
        private class testClass : BaseRepo<Student, StudentData>
        {
            public testClass(DbContext? c, DbSet<StudentData>? s) : base(c, s) { }
            public override bool Add(Student obj) => throw new System.NotImplementedException();
            public override Task<bool> AddAsync(Student obj) => throw new System.NotImplementedException();
            public override bool Delete(string id) => throw new System.NotImplementedException();
            public override Task<bool> DeleteAsync(string id) => throw new System.NotImplementedException();
            public override List<Student> Get() => throw new System.NotImplementedException();
            public override Student Get(string id) => throw new System.NotImplementedException();
            public override List<Student> GetAll<TKey>(System.Func<Student, TKey>? orderBy = null) => throw new System.NotImplementedException();
            public override Task<Student> GetAsync(string id) => throw new System.NotImplementedException();
            public override Task<List<Student>> GetAsync() => throw new System.NotImplementedException();
            public override bool Update(Student obj) => throw new System.NotImplementedException();
            public override Task<bool> UpdateAsync(Student obj) => throw new System.NotImplementedException();
        }
        protected override BaseRepo<Student, StudentData> createObj() => new testClass(null, null);
    }
}
