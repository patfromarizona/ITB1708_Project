using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamUP.Tests
{
    public abstract class SealedClassTests<TClass, TBaseClass>
        : SealedBaseTests<TClass, TBaseClass>
        where TClass : class, new()
        where TBaseClass : class {
        protected override TClass createObj() => new();
    }

    public abstract class SealedBaseTests<TClass, TBaseClass>
        : BaseTests<TClass, TBaseClass>
        where TClass : class
        where TBaseClass : class
    {
        [TestMethod] public void IsSealedTest() => isSealedTest();

        protected virtual void isSealedTest() => isTrue(obj?.GetType()?.IsSealed ?? false);
    }
}
 