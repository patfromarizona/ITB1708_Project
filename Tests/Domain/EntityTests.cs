using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Data;
using TeamUP.Data.Party;
using TeamUP.Domain;

namespace TeamUP.Tests.Domain
{
    [TestClass]
    public class EntityTests : AbstractClassTests<Entity<StudentData>, Entity>
    {
        private class testClass : Entity<StudentData> { }
        protected override Entity<StudentData> createObj() => new testClass();
        [TestMethod] public void getValueTest() => isInconclusive();
    }
}
