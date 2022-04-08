using System;
using System.Diagnostics;
using System.Reflection;
using TeamUP.Aids;

namespace TeamUP.Tests
{
    public abstract class BaseTests : IsTypeTested
    {
        protected object obj;
        protected BaseTests() => obj = createObj();
        protected abstract object createObj();
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
            var canWrite = i?.CanWrite ?? false;
            areEqual(canWrite, !isReadonly);
            return canWrite;
        }
        private static T? random<T>() => GetRandom.Value<T>();
        private static string getCallingMember(string memberName)
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
        internal protected static void arePropertiesEqual(object x, object y)
        {
            var e = Array.Empty<PropertyInfo>();
            var px = x?.GetType()?.GetProperties() ?? e;
            var hasProperties = false;
            foreach (var p in px)
            {
                var a = p.GetValue(x, null);
                var py = y?.GetType()?.GetProperty(p.Name);
                if (py is null) continue;
                var b = py?.GetValue(y, null);
                areEqual(a, b);
                hasProperties = true;
            }
            isTrue(hasProperties, $"No properties found for {x}");
        }
    }
}
