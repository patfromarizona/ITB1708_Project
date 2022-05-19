using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamUP.Data.Party;
using TeamUP.Domain;
using TeamUP.Infra;
using TeamUP.Infra.Initializers;

namespace TeamUP.Tests.Infra.Initializers
{
    [TestClass]
    public class StudentsInitializerTests
        : SealedBaseTests<StudentsInitializer, BaseInitializer<StudentData>>
    {
        protected override StudentsInitializer createObj()
        {
            var db = GetRepo.Instance<TeamUPDb>();
            return new StudentsInitializer(db);
        }
    }
}
