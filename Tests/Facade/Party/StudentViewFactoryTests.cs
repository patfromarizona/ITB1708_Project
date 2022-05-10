using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using TeamUP.Data.Party;
using TeamUP.Domain.Party;
using TeamUP.Facade.Party;

namespace TeamUP.Tests.Facade.Party
{
    [TestClass]
    public class StudentViewFactoryTests
        : ViewFactoryTests<StudentViewFactory, StudentView, Student, StudentData>
    {
        protected override Student toObject(StudentData d) => new(d);
    }
}
