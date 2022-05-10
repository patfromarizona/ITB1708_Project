using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TeamUP.Facade;
using TeamUP.Facade.Party;

namespace TeamUP.Tests.Facade.Party
{
    [TestClass]
    public class TeamWorkViewTests: SealedClassTests<TeamWorkView, BaseView>
    {
         
        [TestMethod] public void IdTest() => isRequired<string>();
        [TestMethod] public void NameTest() => isDisplayNamed<string?>("Name");
        [TestMethod] public void DescriptionTest() => isDisplayNamed<string?>("Description");
        [TestMethod] public void TeamSizeTest() => isDisplayNamed<int?>("Team Size");
        [TestMethod] public void DeadlineTest() => isDisplayNamed<DateTime?>("Deadline");
        [TestMethod] public void DoneTest() => isDisplayNamed<bool?>("Done");
        [TestMethod] public void OverviewTest() => isDisplayNamed<string?>("Overview");
    }

}
