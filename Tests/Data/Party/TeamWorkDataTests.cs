using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
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

    public abstract class BaseTests<TClass>: AssertTests where TClass : class, new(){
        protected TClass obj;
        protected BaseTests() => obj = new TClass();
        protected void isProperty<T>(T? value = default, bool isReadOnly = false)
        {
            var memberName = getCallingMember(nameof(isProperty)).Replace("Test", string.Empty);
            var propertyInfo = obj.GetType().GetProperty(memberName);
            isNotNull(propertyInfo);
            if (isNullOrDefault(value)) value = random<T>();
            if (canWrite(propertyInfo, isReadOnly)) propertyInfo.SetValue(obj, value);
            areEqual(value, propertyInfo.GetValue(obj));
        }
        private static bool isNullOrDefault<T>(T? value)
            => value?.Equals(default(T)) ?? true;
        private static bool canWrite(PropertyInfo i, bool isReadonly)
        {
            var canWrite = i?.CanWrite?? false;
            areEqual (canWrite, !isReadonly);
            return canWrite;
        }
        private static T random<T>() => GetRandom.Value<T>();
        private string getCallingMember(string memberName)
        {
            var s = new StackTrace();
            var isNext = false;
            for (var i = 0; i < s.FrameCount - 1; i++)
            {
                var n = s.GetFrame(i)?.GetMethod()?.Name ?? string.Empty;
                if (n is "MoveNext" or "Start") continue;
                if (isNext) return n;
                if (n == memberName) isNext = true;
            }
            return string.Empty;
        }
    }
    public abstract class AssertTests {
        protected static void inconclusive() => Assert.Inconclusive();
        protected static void isNotNull([NotNull] object? o = null)
            => Assert.IsNotNull(o);
        protected static void areEqual(object? expected, object? actual) 
            => Assert.AreEqual(expected, actual);
    }
}
