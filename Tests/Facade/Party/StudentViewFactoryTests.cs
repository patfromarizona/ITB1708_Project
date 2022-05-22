using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using TeamUP.Aids;
using TeamUP.Data.Party;
using TeamUP.Domain.Party;
using TeamUP.Facade;
using TeamUP.Facade.Party;

namespace TeamUP.Tests.Facade.Party
{
    [TestClass]
    public class StudentViewFactoryTests
        : SealedClassTests<StudentViewFactory, BaseViewFactory<StudentView, Student, StudentData>>
    {
        [TestMethod] public void CreateTest() { }
        [TestMethod] public void CreateViewTest()
        {
            var d = GetRandom.Value<StudentData>();
            var e = new Student(d);
            var v = new StudentViewFactory().Create(e);
            isNotNull(v);
            areEqual(v.Age, e.Age);
            areEqual(v.Id, e.Id);
            areEqual(v.Gender, e.Gender);
            areEqual(v.FirstName, e.FirstName);
            areEqual(v.LastName, e.LastName);
            areEqual(v.YearInUniversity, e.YearInUniversity);
            areEqual(v.FullName, e.ToString());
        }
        [TestMethod] public void CreateEntityTest()
        {
            var v = GetRandom.Value<StudentView>() as StudentView;
            var e = new StudentViewFactory().Create(v);
            isNotNull(e);
            isNotNull(v);
            arePropertiesEqual(e, v);
            areNotEqual(e.ToString(), v.FullName);
        }
    }
}
