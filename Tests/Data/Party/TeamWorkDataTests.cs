using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using TeamUP.Aids;
using TeamUP.Data.Party;

namespace TeamUP.Tests.Data.Party
{
    [TestClass] public class TeamWorkDataTests: BaseTests<TeamWorkData> {
        [TestMethod] public void TeamWorkIdTest() => isProperty<string>();
        [TestMethod] public void NameTest() => isProperty<string?>();
        [TestMethod] public void DescriptionTest() => isProperty<string?>();
        [TestMethod] public void TeamSizeTest() => isProperty<int?>();
        [TestMethod] public void DeadlineTest() => isProperty<DateTime?>();
        [TestMethod] public void DoneTest() => isProperty<bool?>();
    }

    public class BaseTests<TClass>: AssertTests where TClass : class, new(){
        protected TClass obj;
        protected BaseTests() => obj = new TClass();
        protected void isProperty<T>(T? value = default, bool isReadOnly = false)
            => inconclusive();
        private static bool isNullOrDefault<T>(T? value)
            => value?.Equals(default(T)) ?? true;
        /*private static bool canWrite(PropertyInfo i, bool isReadonly)
        {

        }*/
        private static T random<T>() => Aids.GetRandom.Value<T>();
        /*private string getCallingMember(string memberName)
        {

        }*/
    }
    public abstract class AssertTests {
        protected static void inconclusive() => Assert.Inconclusive();
        protected static void isNotNull([NotNull] object? o = null)
            => Assert.IsNotNull(o);
        protected static void areEqual(object? expected, object? actual) 
            => Assert.AreEqual(expected, actual);
    }
}
