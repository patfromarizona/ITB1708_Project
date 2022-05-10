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
    [TestClass] public class TeamWorkViewFactoryTests : ViewFactoryTests<TeamWorkViewFactory, TeamWorkView, TeamWork, TeamWorkData>
    {
        protected override TeamWork toObject(TeamWorkData d) => new(d);
        [TestMethod] public void CreateTest() { }
    }

}
