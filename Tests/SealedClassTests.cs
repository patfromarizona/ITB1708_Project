using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamUP.Tests
{
    public abstract class SealedClassTests<TClass> : BaseTests where TClass : class, new() 
    {
        protected override object createObj() => new TClass();
        [TestMethod] public void isSealedTest() => isTrue(obj?.GetType()?.IsSealed ?? false);
        
    }
}
