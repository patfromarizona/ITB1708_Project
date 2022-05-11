using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Facade;
using TeamUP.Facade.Party;

namespace TeamUP.Tests.Facade.Party
{
    [TestClass] public class TeamWorkStudentViewTests : SealedClassTests<TeamWorkStudentView, BaseView>
    {
        [TestMethod] public void StudentIdTest() => isDisplayNamed<string>("Student");
        [TestMethod] public void TeamWorkIdTest() => isDisplayNamed<string?>("TeamWork");
    }

}
