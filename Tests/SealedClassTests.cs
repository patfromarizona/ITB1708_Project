using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamUP.Tests
{
    public abstract class SealedClassTests<TClass, TBaseClass>
        : BaseTests<TClass, TBaseClass>
        where TClass : class, new()
        where TBaseClass : class {
        protected override TClass createObj() => new();
        [TestMethod] public void isSealedTest() => isTrue(obj?.GetType()?.IsSealed ?? false);

        
    }
}
