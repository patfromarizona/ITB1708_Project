using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Data.Party;
using TeamUP.Infra;
using TeamUP.Domain.Party;
using TeamUP.Domain;
using TeamUP.Aids;
using System.Threading.Tasks;
using System;

namespace TeamUP.Tests.Infra
{
    [TestClass] public class CrudRepoTests : AbstractClassTests<CrudRepo<Student, StudentData>, BaseRepo<Student, StudentData>>
    {
        private TeamUPDb? db;
        private DbSet<StudentData>? set;
        private StudentData? d;
        private Student? s;
        private int cnt;
        private class testClass : CrudRepo<Student, StudentData>
        {
            public testClass(DbContext? c, DbSet<StudentData>? s) : base(c, s) { }
            protected internal override Student toDomain(StudentData d) => new(d);
        }
        protected override CrudRepo<Student, StudentData> createObj()
        {
            db = GetRepo.Instance<TeamUPDb>();
            set = db?.Students;
            isNotNull(set);
            return new testClass(db, set);
        }
        [TestInitialize] public override void TestInitialize()
        {
            base.TestInitialize();
            initSet();
            initStud();
        }

        private void initSet() {
            cnt = GetRandom.Int32(5, 15);
            for (var i = 0; i < cnt; i++) set?.Add(GetRandom.Value<StudentData>());
            db?.SaveChanges();
        }
        private void initStud() {
            d = GetRandom.Value<StudentData>();
            isNotNull(d);
            s = new Student(d);
            var x = obj.Get(d.Id);
            isNotNull(x);
            areNotEqual(d.Id, x.Id);
        }
        [TestMethod] public async Task AddTest() {
            isNotNull(s);
            isNotNull(set);
            _ = obj.Add(s);
            areEqual(cnt + 1, await set.CountAsync());
        }
        [TestMethod] public async Task AddAsyncTest() {
            isNotNull(s);
            isNotNull(set);
            await obj.AddAsync(s);
            areEqual(cnt + 1, await set.CountAsync());
        }
        [TestMethod] public async Task DeleteTest() {
            await GetTest();
            isNotNull(d);
            _ = obj.Delete(d.Id);
            var x = obj.Get(d.Id);
            isNotNull(x);
            areNotEqual(d.Id, x.Id);
        }
        [TestMethod] public async Task DeleteAsyncTest()
        {
            await GetTest();
            await obj.DeleteAsync(d.Id);
            var x = obj.Get(d.Id);
            isNotNull(x);
            areNotEqual(d.Id, x.Id);
        }
        [TestMethod] public async Task GetTest() {
            await AddTest();
            var x = obj.Get(d.Id);
            arePropertiesEqual(d, x.Data);
        }

        [DataRow(nameof(Student.Id))]
        [DataRow(nameof(Student.FirstName))]
        [DataRow(nameof(Student.LastName))]
        [DataRow(nameof(Student.Gender))]
        [DataRow(nameof(Student.Age))]
        [DataRow(nameof(Student.YearInUniversity))]
        [DataRow(nameof(Student.ToString))]
        [DataRow(null)]
        [TestMethod]
        public void GetAllTest(string s)
        {
            Func<Student, dynamic>? orderBy = null;
            if (s is nameof(Student.Id)) orderBy = x => x.Id;
            else if (s is nameof(Student.Id)) orderBy = x => x.Id;
            else if (s is nameof(Student.FirstName)) orderBy = x => x.FirstName;
            else if (s is nameof(Student.LastName)) orderBy = x => x.LastName;
            else if (s is nameof(Student.Gender)) orderBy = x => x.Gender;
            else if (s is nameof(Student.Age)) orderBy = x => x.Age;
            else if (s is nameof(Student.YearInUniversity)) orderBy = x => x.YearInUniversity;
            else if (s is nameof(Student.ToString)) orderBy = x => x.ToString();
            var l = obj.GetAll(orderBy);
            areEqual(cnt, l.Count);

            if (orderBy is null) return;
            for (var i = 0; i < l.Count - 1; i++)
            {
                var a = l[i];
                var b = l[i + 1];
                var aX = orderBy(a) as IComparable;
                var bX = orderBy(b) as IComparable;
                isNotNull(aX);
                isNotNull(bX);
                var r = aX.CompareTo(bX);
                isTrue(r <= 0);
            }
        }
        [TestMethod] public void GetListTest() {
            var l = obj.Get();
            isNotNull(l);
            areEqual(cnt, l.Count);
        }
        [TestMethod] public async Task GetAsyncTest() {
            await AddTest();
            isNotNull(d);
            var x = await obj.GetAsync(d.Id);
            arePropertiesEqual(d, x.Data);
        }
        [TestMethod] public async Task GetListAsyncTest() {
            var l = await obj.GetAsync();
            isNotNull(l);
            areEqual(cnt, l.Count);
        }
        [TestMethod] public async Task UpdateTest()
        {
            isNotNull(d);
            await GetTest();
            var dX = GetRandom.Value<StudentData>() as StudentData;
            isNotNull(dX);
            dX.Id = d.Id;
            var aX = new Student(dX); 
            obj.Update(aX);
            var x = obj.Get(d.Id);
            arePropertiesEqual(dX, x.Data);
        }
        [TestMethod] public async Task UpdateAsyncTest() {
            await GetTest();
            isNotNull(d);
            var dX = GetRandom.Value<StudentData>() as StudentData;
            isNotNull(dX);
            dX.Id = d.Id;
            var aX = new Student(dX);
            await obj.UpdateAsync(aX);
            var x = obj.Get(d.Id);
            arePropertiesEqual(dX, x.Data);
        }
    }
}
