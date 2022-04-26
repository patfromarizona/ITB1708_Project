using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Aids;

namespace TeamUP.Tests.Aids
{
    [TestClass] public class StringsTests : IsTypeTested
    {
        private string? testStr;
        [TestInitialize] public void Init() => testStr = "i2l2h2.m2m2ha2";
        [TestMethod] public void RemoveTest() => areEqual("ilh.mmha", Strings.Remove(testStr, "2"));
        [TestMethod] public void IsTypeNameTest() 
        {
            isFalse(Strings.IsTypeName(testStr));
            var s = Strings.Remove(testStr, "2");
            isFalse(Strings.IsTypeName(s));
            s = Strings.RemoveTail(s);
            isTrue(Strings.IsTypeName(s));
        }
        [TestMethod] public void IsTypeFullNameTest()
        {
            isFalse(Strings.IsTypeFullName(testStr));
            isTrue(Strings.IsTypeFullName(Strings.Remove(testStr, "2")));
        }
        [TestMethod] public void RemoveTailTest() => areEqual("i2l2h2", Strings.RemoveTail(testStr));
    }
}
