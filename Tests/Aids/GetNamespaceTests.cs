using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Aids;
using TeamUP.Data.Party;

namespace TeamUP.Tests.Aids
{
    [TestClass] public class GetNamespaceTests : TypeTests 
    {
        [TestMethod]
        public void OfTypeTest()
        { 
            var obj = new StudentData();
            var name = obj.GetType().Namespace;
            var n = GetNamespace.OfType(obj);
            areEqual(name, n);
        }

        [TestMethod]
        public void OfTypeNullTest()
        {
            StudentData? obj = null;
            var n = GetNamespace.OfType(obj);
            areEqual(string.Empty, n);
        }
    }
}
