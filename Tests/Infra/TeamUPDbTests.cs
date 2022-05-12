using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Infra;

namespace TeamUP.Tests.Infra
{
    [TestClass] public class TeamUPDbTests : SealedBaseTests<TeamUPDb, DbContext>
    {
        protected override TeamUPDb createObj() => null;
        protected override void isSealedTest() => isInconclusive();
    }
}
