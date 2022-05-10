using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Data.Party;
using TeamUP.Domain.Party;
using TeamUP.Facade.Party;

namespace TeamUP.Tests.Facade.Party
{
    [TestClass] public class TeamWorkStudentViewFactoryTests : ViewFactoryTests<TeamWorkStudentViewFactory, TeamWorkStudentView, TeamWorkStudent, TeamWorkStudentData>
    {
        [TestMethod] public void CreateTest() { }

        protected override TeamWorkStudent toObject(TeamWorkStudentData d) => new(d);
    }

}
