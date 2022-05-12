

using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Infra.Party;
using TeamUP.Infra;
using TeamUP.Domain.Party;
using TeamUP.Data.Party;
using TeamUP.Domain;

namespace TeamUP.Tests.Infra.Party
{
    [TestClass] public class TeamWorkStudentRepoTests : SealedRepoTests<TeamWorkStudentRepo, Repo<TeamWorkStudent, TeamWorkStudentData>, TeamWorkStudent, TeamWorkStudentData>
    {
        protected override TeamWorkStudentRepo createObj() => new(GetRepo.Instance<TeamUPDb>());
        protected override object? getSet(TeamUPDb db) => db.TeamWorkStudent;
    }
}
