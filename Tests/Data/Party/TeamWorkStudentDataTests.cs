

using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Data.Party;

namespace TeamUP.Tests.Data.Party
{
    [TestClass] public class TeamWorkStudentDataTests : SealedClassTests<TeamWorkStudentData>
    {
        [TestMethod] public void StudentIdTest() => isProperty<string>();
        [TestMethod] public void TeamWorkIdTest() => isProperty<string>();
    }







}