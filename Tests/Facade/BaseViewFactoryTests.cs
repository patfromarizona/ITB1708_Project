using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Data.Party;
using TeamUP.Domain.Party;
using TeamUP.Facade;
using TeamUP.Facade.Party;

namespace TeamUP.Tests.Facade
{
    [TestClass]
    public class BaseViewFactoryTests : AbstractClassTests
    {
        private class testClass : BaseViewFactory<StudentView, Student, StudentData>
        {
            protected override Student toEntity(StudentData d) => new(d);  
        }
        protected override object createObj() => new testClass();
    }
}
