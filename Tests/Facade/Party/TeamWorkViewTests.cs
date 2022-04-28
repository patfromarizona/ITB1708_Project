using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TeamUP.Facade;
using TeamUP.Facade.Party;

namespace TeamUP.Tests.Facade.Party
{
    [TestClass]
    public class TeamWorkViewTests: SealedClassTests<TeamWorkView, BaseView>
    {
         
        [TestMethod] public void IdTest() => isProperty<string>();
        [TestMethod] public void NameTest() => isProperty<string?>();
        [TestMethod] public void DescriptionTest() => isProperty<string?>();
        [TestMethod] public void TeamSizeTest() => isProperty<int?>();
        [TestMethod] public void DeadlineTest() => isProperty<DateTime?>();
        [TestMethod] public void DoneTest() => isProperty < bool?>();
        [TestMethod] public void OverviewTest() => isProperty<string? >();
    }
}
