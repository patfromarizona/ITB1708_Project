using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Data.Party;
using TeamUP.Domain.Party;
using TeamUP.Facade;
using TeamUP.Facade.Party;

namespace TeamUP.Tests.Facade
{
    [TestClass]
    public class BaseViewTests : AbstractClassTests<BaseView, object>
    {
        private class testClass : BaseView { }
        protected override BaseView createObj() => new testClass();

        [TestMethod] public void IdTest() => isProperty<string>();
    }
}
