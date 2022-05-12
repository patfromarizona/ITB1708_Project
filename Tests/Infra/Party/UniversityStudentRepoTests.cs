

using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Infra.Party;
using TeamUP.Infra;
using TeamUP.Domain.Party;
using TeamUP.Data.Party;
using TeamUP.Domain;

namespace TeamUP.Tests.Infra.Party
{
    [TestClass] public class UniversityStudentRepoTests : SealedRepoTests<UniversityStudentRepo, Repo<UniversityStudent, UniversityStudentData>, UniversityStudent, UniversityStudentData>
    {
        protected override UniversityStudentRepo createObj() => new(GetRepo.Instance<TeamUPDb>());
        protected override object? getSet(TeamUPDb db) => db.UniversityStudent;
    }
}
