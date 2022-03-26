using System;
using System.Reflection;

namespace TeamUP.Aids
{
    public class GetRandom
    {
        private static void minFirst<T>(ref T min, ref T max) where T : IComparable<T>
        {
            if (min.CompareTo(max) < 0) return;
            var v = max;
            max = min;
            min = v;
        }
        public static int Int32(int? min = null, int? max = null)
        {
            var minVal = min ?? -1000;
            var maxVal = max ?? 1000;
            minFirst(ref minVal, ref maxVal);
            return Random.Shared.Next(minVal, maxVal);
        }
        public static long Int64(long? min = null, long? max = null)
        {
           var minVal =  min?? - 1000L;
           var maxVal = max ?? 1000L;
           minFirst(ref minVal, ref maxVal);
           return Random.Shared.NextInt64(minVal, maxVal);
        }
        public static double Double(double? min = null, double? max = null)
        {
            var minVal = min ?? -1000.0;
            var maxVal = max ?? 1000.0;
            minFirst(ref minVal, ref maxVal);
            return minVal + Random.Shared.NextDouble() * (maxVal - minVal);
        } 
        public static char Char(char min = char.MinValue, char max = char.MaxValue) => (char)Int64(min, max);
        public static bool Bool() => Int32() % 2 == 0;
        public static DateTime Datetime(DateTime? min = null, DateTime? max = null)
        {
            var minVal = (min ?? DateTime.MinValue).Ticks;
            var maxVal = (max ?? DateTime.MaxValue).Ticks;
            minFirst(ref minVal, ref maxVal);
            var v = Int64(minVal, maxVal);
            return DateTime.MinValue.AddTicks(v);
        }
        public static string String(ushort minLenght = 5, ushort maxLenght = 30)
        {
            var s = string.Empty;
            var lenght = Int32(minLenght, maxLenght);
            for (var i = 0; i < lenght; i++) s += Char('a', 'z');
            return s;
        }
        public static dynamic Value<T>(T? min=default, T? max=default)
        {
            if (typeof(T) == typeof(bool)) return Bool();
            else if (typeof(T) == typeof(bool?)) return Bool();
            else if (typeof(T) == typeof(DateTime)) return Datetime(Convert.ToDateTime(min), Convert.ToDateTime(max));
            else if (typeof(T) == typeof(DateTime?)) return Datetime(Convert.ToDateTime(min), Convert.ToDateTime(max));
            else if (typeof(T) == typeof(int)) return Int32(Convert.ToInt32(min), Convert.ToInt32(max));
            else if (typeof(T) == typeof(int?)) return Int32(Convert.ToInt32(min), Convert.ToInt32(max));
            else if (typeof(T) == typeof(long)) return Int64(Convert.ToInt64(min), Convert.ToInt64(max));
            else if (typeof(T) == typeof(long?)) return Int64(Convert.ToInt64(min), Convert.ToInt64(max));
            else if (typeof(T) == typeof(double)) return Double(Convert.ToDouble(min), Convert.ToDouble(max));
            else if (typeof(T) == typeof(double?)) return Double(Convert.ToDouble(min), Convert.ToDouble(max));
            else if (typeof(T) == typeof(char)) return Char(Convert.ToChar(min), Convert.ToChar(max));
            else if (typeof(T) == typeof(char?)) return Char(Convert.ToChar(min), Convert.ToChar(max));
            else if (typeof(T) == typeof(string)) return String();
            return tryGetObject<T>();
        }

        public static dynamic Value(Type t)
        {
            if (t == typeof(bool)) return Bool();
            else if (t == typeof(bool?)) return Bool();
            else if (t == typeof(DateTime)) return Datetime();
            else if (t == typeof(DateTime?)) return Datetime();
            else if (t == typeof(int)) return Int32();
            else if (t == typeof(int?)) return Int32();
            else if (t == typeof(long)) return Int64();
            else if (t == typeof(long?)) return Int64();
            else if (t == typeof(double)) return Double();
            else if (t == typeof(double?)) return Double();
            else if (t == typeof(char)) return Char();
            else if (t == typeof(char?)) return Char();
            else if (t == typeof(string)) return String();
            return null;
        }

        private static T tryGetObject<T>()
        {
            var o = tryCreate<T>();
            foreach(var pi in o?.GetType()?.GetProperties() ?? Array.Empty<PropertyInfo>())
            {
                if(!pi.CanWrite) continue;
                var v = Value(pi.PropertyType);
                pi.SetValue(o, v, null);

            }
            return o;
        }

        private static T tryCreate<T>()
        {
            var c = typeof(T).GetConstructor(Array.Empty<Type>());
            return (T) c?.Invoke(null);
        }
    }
}
