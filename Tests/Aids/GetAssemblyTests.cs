using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using TeamUP.Aids;

namespace TeamUP.Tests.Aids
{
    [TestClass] public class GetAssemblyTests : IsTypeTested
    {
        [TestMethod] public void ByNameTest()
        {
            Assert.AreNotEqual(AssemblyName.GetAssemblyName(@".\TeamUp.Aids.dll"), GetAssembly.ByName("TeamUP.Aids"));
            Assert.AreEqual(Assembly.Load("TeamUp.Aids"), GetAssembly.ByName("TeamUP.Aids"));
            Assert.AreNotEqual("WhoIsThere", GetAssembly.ByName("TeamUP.Aids"));
            Assert.AreEqual(Assembly.Load("TeamUp.Data"), GetAssembly.ByName("TeamUP.Data"));
        }
        [TestMethod] public void OfTypeTest() => isInconclusive();
        [TestMethod] public void TypesTest() => isInconclusive();
        [TestMethod] public void TypeTest() => isInconclusive();
    }
}
