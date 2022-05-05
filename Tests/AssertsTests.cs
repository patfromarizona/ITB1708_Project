using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace TeamUP.Tests
{
    public abstract class AssertsTests
    {
        protected static void isTrue(bool? b, string? msg = null) => Assert.IsTrue(b ?? false, msg ?? string.Empty);
        protected static void isFalse(bool? b, string? msg = null) => Assert.IsFalse(b ?? true, msg ?? string.Empty);
        protected static void isInconclusive(string? s = null) => Assert.Inconclusive(s ?? string.Empty);
        protected static void isNotNull([NotNull] object? o = null) => Assert.IsNotNull(o);
        protected static void isNull(object? o = null) => Assert.IsNull(o);
        protected static void areEqual(object? expected, object? actual, string? msg = null) => Assert.AreEqual(expected, actual, msg ?? string.Empty);
        protected static void areNotEqual(object? expected, object? actual, string? msg = null) => Assert.AreNotEqual(expected, actual, msg ?? string.Empty);
        protected static void isInstanceOfType(object o, Type expectedType, string? msg = null) => Assert.IsInstanceOfType(o, expectedType, msg ?? string.Empty);
        protected virtual void equalProperties(object? a, object? b)
        {
            isNotNull(a);
            isNotNull(b);
            var tA = a.GetType();
            var tB = b.GetType();
            foreach(var piA in tA?.GetProperties() ?? Array.Empty<PropertyInfo>())
            {
                var vA = piA.GetValue(a, null);
                var piB = tB?.GetProperty(piA.Name);
                var vB = piB?.GetValue(b, null);
                areEqual(vA, vB, $"For property {piA.Name}.");

            }
        }
       
    }
}
