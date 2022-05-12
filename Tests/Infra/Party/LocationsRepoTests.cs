

using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Infra.Party;
using TeamUP.Infra;
using TeamUP.Domain.Party;
using TeamUP.Data.Party;
using TeamUP.Domain;
using System;
using TeamUP.Data;
using Microsoft.EntityFrameworkCore;
using TeamUP.Aids;

namespace TeamUP.Tests.Infra.Party
{
    public abstract class SealedRepoTests<TClass, TBaseClass, TDomain, TData> : SealedBaseTests<TClass, TBaseClass>
        where TClass : FilteredRepo<TDomain, TData>
        where TBaseClass : class
        where TDomain : Entity<TData>, new()
        where TData : EntityData, new()
    {
        private static Type teamType => typeof(TeamUPDb);
        private static Type setType => typeof(DbSet<TData>);
        private TeamUPDb teamUPDb
        {
            get
            {
                var o = obj.db;
                isNotNull(o);
                var db = o as TeamUPDb;
                isNotNull(db);
                return db;
            }
        }
        protected void instanceTest(object? o, Type t)
        {
            isNotNull(o);
            isInstanceOfType(o, t);
        }
        protected void instanceTest(object? o, Type t, object? e = null)
        {
            instanceTest(o, t);
            instanceTest(e, t);
            areEqual(e, o);
        }
        [TestMethod] public void DbContextTest() => instanceTest(obj.db, teamType);
        [TestMethod] public void DbSetTest() => instanceTest(obj.set, setType, getSet(teamUPDb));
        [TestMethod] public void ToDomainTest()
        {
            var d = GetRandom.Value<TData>(); 
            var o = obj.toDomain(d);
            isNotNull(o);
            isInstanceOfType(o, typeof(TDomain));
            arePropertiesEqual(d, o.Data);
        }
        [TestMethod] public void AddFilterTest()
        {
            string contains(string s) => $"x.{s}.Contains";
            string toStrContains(string s) => $"x.{s}.ToString().Contains";
            obj.CurrentFilter = "abc";
            var q = obj.createSql();
            var s = q.Expression.ToString();
            foreach(var p in typeof(TData).GetProperties())
            {
                if(p.PropertyType == typeof(string))
                {
                    isTrue(s.Contains(contains(p.Name)), $"Nothing found for {p.Name}");
                }
                else
                {
                    isTrue(s.Contains(toStrContains(p.Name)), $"Nothing found for {p.Name}");
                }
            }
            
        }
        protected abstract object? getSet(TeamUPDb db);
    }
    [TestClass] public class LocationsRepoTests : SealedRepoTests<LocationsRepo, Repo<Location, LocationData>, Location, LocationData>
    {
        protected override LocationsRepo createObj() => new(GetRepo.Instance<TeamUPDb>());

        protected override object? getSet(TeamUPDb db) => db.Locations;
    }
}
