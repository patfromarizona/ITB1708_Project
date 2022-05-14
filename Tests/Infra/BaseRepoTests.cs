using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Data.Party;
using TeamUP.Infra;
using TeamUP.Domain.Party;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

namespace TeamUP.Tests.Infra
{
    [TestClass] public class BaseRepoTests : AbstractClassTests<BaseRepo<Student, StudentData>, object>
    {
        private class testClass : BaseRepo<Student, StudentData>
        {
            public testClass(DbContext? c, DbSet<StudentData>? s) : base(c, s) { }
            public override bool Add(Student obj) => throw new NotImplementedException();
            public override Task<bool> AddAsync(Student obj) => throw new NotImplementedException();
            public override bool Delete(string id) => throw new NotImplementedException();
            public override Task<bool> DeleteAsync(string id) => throw new NotImplementedException();
            public override List<Student> Get() => throw new NotImplementedException();
            public override Student Get(string id) => throw new NotImplementedException();
            public override List<Student> GetAll(Func<Student, dynamic>? orderBy = null) => throw new NotImplementedException();
            public override Task<Student> GetAsync(string id) => throw new NotImplementedException();
            public override Task<List<Student>> GetAsync() => throw new NotImplementedException();
            public override bool Update(Student obj) => throw new NotImplementedException();
            public override Task<bool> UpdateAsync(Student obj) => throw new NotImplementedException();
        }
        protected override BaseRepo<Student, StudentData> createObj() => new testClass(null, null);

        [TestMethod] public void DbTest() => isInconclusive();
        [TestMethod] public void SetTest() => isInconclusive();
        [TestMethod] public void BaseRepoTest() => isInconclusive();
        [TestMethod] public void ClearTest() => isInconclusive();
        [TestMethod] public void AddTest() => isAbstractMethod(nameof(obj.Add), typeof(Student));
        [TestMethod] public void AddAssyncTest() => isAbstractMethod(nameof(obj.AddAsync), typeof(Student));
        [TestMethod] public void DeleteTest() =>  isAbstractMethod(nameof(obj.Delete), typeof(string));
        [TestMethod] public void DeleteAssyncTest() => isAbstractMethod(nameof(obj.DeleteAsync), typeof(string));
        [TestMethod] public void GetTest() => isAbstractMethod(nameof(obj.Get), typeof(string));
        [TestMethod] public void GetAllTest() => isAbstractMethod(nameof(obj.GetAll), typeof(Func<Student, dynamic>));
        [TestMethod] public void GetListTest() => isAbstractMethod(nameof(obj.Get));
        [TestMethod] public void GetAssyncTest() => isAbstractMethod(nameof(obj.GetAsync), typeof(string));
        [TestMethod] public void GetListAssyncTest() => isAbstractMethod(nameof(obj.GetAsync));
        [TestMethod] public void UpdateTest() => isAbstractMethod(nameof(obj.Update), typeof(Student));
        [TestMethod] public void UpdateAssyncTest() => isAbstractMethod(nameof(obj.UpdateAsync), typeof(Student));
    }
}
