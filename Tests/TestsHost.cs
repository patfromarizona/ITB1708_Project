using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net.Http;
using TeamUP.Aids;
using TeamUP.Data;
using TeamUP.Domain;
using TeamUP.Domain.Party;
using TeamUP.Infra.Party;

namespace TeamUP.Tests
{
    public abstract class TestsHost : AssertsTests
    {
        internal static readonly TestHost<Program> host;
        internal static readonly HttpClient client;
        [TestInitialize]
        public virtual void TestInitialize()
        {
            (GetRepo.Instance<IStudentsRepo>() as StudentsRepo)?.clear();
            (GetRepo.Instance<ITeamWorksRepo>() as TeamWorksRepo)?.clear();
            (GetRepo.Instance<ITeamWorkStudentRepo>() as TeamWorkStudentRepo)?.clear();
            (GetRepo.Instance<IUniversitiesRepo>() as UniversitiesRepo)?.clear();
            (GetRepo.Instance<IUniversityStudentRepo>() as UniversityStudentRepo)?.clear();
            (GetRepo.Instance<ILocationsRepo>() as LocationsRepo)?.clear();
        }
        static TestsHost()
        {
            host = new TestHost<Program>();
            client = host.CreateClient();
        }

        protected virtual object? isReadOnly<T>(string? callingMethod = null) => null;
        protected virtual void arePropertiesEqual(object? x, object? y) { isInconclusive(); }

        protected void testItem<TRepo, TObj, TData>(string id, Func<TData, TObj> toObj, Func<TObj?> getObj)
           where TRepo : class, IRepo<TObj> where TObj : Entity
        {
            var c = isReadOnly<TObj>(nameof(testItem));
            isNotNull(c);
            isInstanceOfType(c, typeof(TObj));
            var r = GetRepo.Instance<TRepo>();
            var d = GetRandom.Value<TData>();
            d.Id = id;
            var cnt = GetRandom.Int32(5, 30);
            var idx = GetRandom.Int32(0, cnt);
            for (var i = 0; i < cnt; i++)
            {
                var x = (i == idx) ? d : GetRandom.Value<TData>();
                isNotNull(x);
                r?.Add(toObj(x));
            }
            equalProperties(d, getObj());
        }
        protected void testItems<TRepo, TObj, TData>(Action<TData> setId, Func<TData, TObj> toObj, Func<List<TObj>> getList)
           where TRepo : class, IRepo<TObj>
           where TObj : Entity<TData>
           where TData : EntityData, new()
        {
            var o = isReadOnly<List<TObj>>(nameof(testItems));
            isNotNull(o);
            isInstanceOfType(o, typeof(List<TObj>));

            var r = GetRepo.Instance<TRepo>();
            isNotNull(r);

            var list = new List<TData>();
            var cnt = GetRandom.Int32(0, 30);
            for (var i = 0; i < cnt; i++)
            {
                var x = GetRandom.Value<TData>();
                if (GetRandom.Bool())
                {
                    setId(x);
                    list.Add(x);
                }
                r.Add(toObj(x));
            }

            var l = getList();
            areEqual(list.Count, l.Count);
            foreach (var d in list)
            {
                var y = l.Find(z => z.Id == d.Id);
                isNotNull(y);
                equalProperties(d, y);
            }
        }
    }
}
