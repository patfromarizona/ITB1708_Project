

using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Infra.Party;
using TeamUP.Infra;
using TeamUP.Domain.Party;
using TeamUP.Data.Party;
using TeamUP.Domain;

namespace TeamUP.Tests.Infra.Party
{
    [TestClass] public class UniversitiesRepoTests : SealedRepoTests<UniversitiesRepo, Repo<University, UniversityData>, University, UniversityData>
    {
        protected override UniversitiesRepo createObj() => new(GetRepo.Instance<TeamUPDb>());
        protected override object? getSet(TeamUPDb db) => db.Universities;
    }
}
