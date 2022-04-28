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
    public class StudentViewFactoryTests : SealedClassTests<StudentViewFactory, BaseViewFactory<StudentView, Student, StudentData>>
    {
        [TestMethod] public void CreateTest() { }
        [TestMethod] public void CreateViewTest() 
        {
            var d = GetRandom.Value<StudentData>();
            var e = new Student(d);
            var v = new StudentViewFactory().Create(e);
            isNotNull(v);
            areEqual(v.Id, e.Id);
            areEqual(v.FirstName, e.FirstName);
            areEqual(v.LastName, e.LastName);
            areEqual(v.Gender, e.Gender);
            areEqual(v.Age, e.Age); 
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
            areEqual(e.Id, v.Id);
            areEqual(e.FirstName, v.FirstName);
            areEqual(e.LastName, v.LastName);
            areEqual(e.Gender, v.Gender);
            areEqual(e.Age, v.Age);
            areEqual(e.YearInUniversity, v.YearInUniversity);
            areNotEqual(e.ToString(), v.ToString());
        }
    }
}
