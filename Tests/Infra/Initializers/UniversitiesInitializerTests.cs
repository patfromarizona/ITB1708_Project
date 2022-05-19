using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Data.Party;
using TeamUP.Domain;
using TeamUP.Infra;
using TeamUP.Infra.Initializers;

namespace TeamUP.Tests.Infra.Initializers
{
    [TestClass]
    public class UniversitiesInitializerTests
        : SealedBaseTests<UniversitiesInitializer, BaseInitializer<UniversityData>>
    {
        protected override UniversitiesInitializer createObj()
        {
            var db = GetRepo.Instance<TeamUPDb>();
            return new UniversitiesInitializer(db);
        }
    }
}
