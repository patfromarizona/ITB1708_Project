using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Data.Party;
using TeamUP.Domain.Party;
using TeamUP.Facade.Party;

namespace TeamUP.Tests.Facade.Party
{
    [TestClass]
    public class UniversityStudentViewFactoryTests : ViewFactoryTests<UniversityStudentViewFactory, UniversityStudentView, UniversityStudent, UniversityStudentData>
    {
        [TestMethod] public void CreateTest() { }

        protected override UniversityStudent toObject(UniversityStudentData d) => new(d);
    }

}
