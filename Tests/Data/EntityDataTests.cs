

using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Data;


namespace TeamUP.Tests.Data
{
    [TestClass] public class EntityDataTests : AbstractClassTests<EntityData, EntityData>
    {
        private class testClass : EntityData { }
        protected override EntityData createObj() => new testClass();
        [TestMethod] public void NewIdTest()
        {
            isNotNull(EntityData.NewId);
            areNotEqual(EntityData.NewId, EntityData.NewId);
            var pi = typeof(EntityData).GetProperty(nameof(EntityData.NewId));
            isFalse(pi?.CanWrite);
        }
        [TestMethod] public void IdTest() => isProperty<string>();

    }







}