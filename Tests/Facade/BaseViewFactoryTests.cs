using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Aids;
using TeamUP.Data.Party;
using TeamUP.Domain.Party;
using TeamUP.Facade;
using TeamUP.Facade.Party;

namespace TeamUP.Tests.Facade
{
    [TestClass]
    public class BaseViewFactoryTests : AbstractClassTests<BaseViewFactory<StudentView, Student, StudentData>, object>
    {
        private class testClass : BaseViewFactory<StudentView, Student, StudentData>
        {
            protected override Student toEntity(StudentData d) => new(d);  
        }
        protected override BaseViewFactory<StudentView, Student, StudentData> createObj() => new testClass();

        [TestMethod] public void CreateTest() { }
        [TestMethod] public void CreateViewTest()
        {
            var v = GetRandom.Value<StudentView>();
            var o = obj.Create(v);
            arePropertiesEqual(v, o.Data);
        }
        [TestMethod] public void CreateObjectTest() {
            var d = GetRandom.Value<StudentData>();
            var v = obj.Create(new Student(d));
            arePropertiesEqual(v, d);
        }
    }
}
