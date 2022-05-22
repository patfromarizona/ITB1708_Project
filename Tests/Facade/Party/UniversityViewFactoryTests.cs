using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Data.Party;
using TeamUP.Domain.Party;
using TeamUP.Facade.Party;

namespace TeamUP.Tests.Facade.Party
{
    [TestClass]
    public class UniversityViewFactoryTests
        : ViewFactoryTests<UniversityViewFactory, UniversityView, University, UniversityData>
    {
        protected override University toObject(UniversityData d) => new(d);
    }
}
