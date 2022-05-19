using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Data.Party;
using TeamUP.Domain;
using TeamUP.Infra;
using TeamUP.Infra.Initializers;

namespace TeamUP.Tests.Infra.Initializers
{
    [TestClass]
    public class TeamWorksInitializerTests
        : SealedBaseTests<TeamWorksInitializer, BaseInitializer<TeamWorkData>>
    {
        protected override TeamWorksInitializer createObj()
        {
            var db = GetRepo.Instance<TeamUPDb>();
            return new TeamWorksInitializer(db);
        }
    }
}
