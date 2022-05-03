using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Aids;

namespace TeamUP.Tests.Aids
{
    [TestClass] public class MethodsTests : TypeTests 
    {
        [TestMethod] public void HasAttributeTest()
        {
            var m = this.GetType().GetMethod(nameof(HasAttributeTest));
            isTrue(Methods.HasAttribute<TestMethodAttribute>(m));
            isFalse(Methods.HasAttribute<TestInitializeAttribute>(m));
        }
     }
}
