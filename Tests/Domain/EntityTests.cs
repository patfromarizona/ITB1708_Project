using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Aids;
using TeamUP.Data;
using TeamUP.Data.Party;
using TeamUP.Domain;

namespace TeamUP.Tests.Domain
{
    [TestClass]
    public class EntityTests : AbstractClassTests<Entity<StudentData>, Entity>
    {
        private StudentData? d;

        private class testClass : Entity<StudentData> 
        {
            public testClass() : this(new StudentData()) { }
            public testClass(StudentData d) : base(d) { }   
        }
        protected override Entity<StudentData> createObj()
        {
            d = GetRandom.Value<StudentData>();
            return new testClass(d);
        } 

        [TestMethod] public void IdTest() => isReadOnly(obj.Data.Id);
        [TestMethod] public void DataTest() => isReadOnly(d);
        [TestMethod] public void DefaultStrTest() => areEqual("Underfined", Entity.DefaultStr);
    }
}
