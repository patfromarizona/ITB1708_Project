using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using TeamUP.Aids;
using TeamUP.Data.Party;
using TeamUP.Domain.Party;
using TeamUP.Facade;
using TeamUP.Facade.Party;

namespace TeamUP.Tests.Facade.Party
{
    [TestClass] public class TeamWorkViewFactoryTests : SealedClassTests<TeamWorkViewFactory, BaseViewFactory<TeamWorkView, TeamWork, TeamWorkData>>
    {
        [TestMethod] public void CreateTest() { }
        [TestMethod] public void CreateViewTest()
        {
            var d = GetRandom.Value<TeamWorkData>();
            var e = new TeamWork(d);
            var v = new TeamWorkViewFactory().Create(e);
            isNotNull(v);
            areEqual(v.Name, e.Name);
            areEqual(v.Id, e.Id);
            areEqual(v.Description, e.Description);
            areEqual(v.Deadline, e.Deadline);
            areEqual(v.TeamSize, e.TeamSize);
            areEqual(v.Done, e.Done);
            areEqual(v.Overview, e.ToString());
        }
        [TestMethod]
        public void CreateEntityTest()
        {
            var v = GetRandom.Value<TeamWorkView>() as TeamWorkView;
            var e = new TeamWorkViewFactory().Create(v);
            isNotNull(e);
            isNotNull(v);
            arePropertiesEqual(e, v);
            areNotEqual(e.ToString(), v.Overview);
        }
    }

}
