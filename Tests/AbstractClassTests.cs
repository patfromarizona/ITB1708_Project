using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamUP.Tests
{
    public abstract class AbstractClassTests<TClass, TBaseClass> : BaseTests<TClass, TBaseClass>
        where TClass : class
        where TBaseClass : class {
        [TestMethod] public void isAbstractTest() => isTrue(obj?.GetType()?.BaseType?.IsAbstract ?? false);
    }
}
