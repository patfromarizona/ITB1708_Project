using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TeamUP.Data.Party;

namespace TeamUP.Tests.Data.Party
{
    [TestClass] public class TeamWorkDataTests: BaseTests<TeamWorkData> {
        [TestMethod] public void IdTest() => isProperty<string>();
        [TestMethod] public void NameTest() => isProperty<string?>();
        [TestMethod] public void DescriptionTest() => isProperty<string?>();
        [TestMethod] public void TeamSizeTest() => isProperty<int?>();
        [TestMethod] public void DeadlineTest() => isProperty<DateTime?>();
        [TestMethod] public void DoneTest() => isProperty<bool?>();
    }
}
