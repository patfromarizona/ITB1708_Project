using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TeamUP.Facade.Party;
using TeamUP.Tests.Data.Party;

namespace TeamUP.Tests.Facade.Party
{
    [TestClass]
    public class TeamWorkViewTests: BaseTests<TeamWorkView>
    {
         
        [TestMethod] public void TeamWorkIdTest() => isProperty<string>();
        [TestMethod] public void NameTest() => isProperty<string?>();
        [TestMethod] public void DescriptionTest() => isProperty<string?>();
        [TestMethod] public void TeamSizeTest() => isProperty<int?>();
        [TestMethod] public void DeadlineTest() => isProperty<DateTime?>();
        [TestMethod] public void DoneTest() => isProperty < bool?>();
        [TestMethod] public void OverviewTest() => isProperty<string? >();
    }
}
