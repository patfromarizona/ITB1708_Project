using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TeamUP.Aids;
using TeamUP.Data.Party;

namespace TeamUP.Tests.Aids
{
    [TestClass] public class GetRandomTests : IsTypeTested
    {
        private void test<T>(T min, T max) where T : IComparable<T>
        {
            var x = GetRandom.Value(min, max);
            var y = GetRandom.Value(min, max);
            isTrue(x >= (min.CompareTo(max) < 0 ? min : max));
            isTrue(y >= (min.CompareTo(max) < 0 ? min : max));
            isTrue(x <= (min.CompareTo(max) < 0 ? max : min));
            isTrue(y <= (min.CompareTo(max) < 0 ? max : min));
            isInstanceOfType(x, typeof(T));
            isInstanceOfType(y, typeof(T));
            areNotEqual(x, y);
        }

        [DataRow(1000, -1000)]
        [DataRow(-1000, 1000)]
        [DataRow(0, 1000)]
        [DataRow(-1000, 0)]
        [DataRow(int.MinValue, int.MinValue + 100)]
        [DataRow(int.MaxValue - 100, int.MaxValue)]
        [TestMethod] public void Int32Test(int min, int max) => test(min, max);


        [DataRow(1000L, -1000L)]
        [DataRow(-1000L, 1000L)]
        [DataRow(0L, 1000L)]
        [DataRow(-1000L, 0L)]
        [DataRow(long.MinValue, long.MinValue + 1000L)]
        [DataRow(long.MaxValue - 1000L, long.MaxValue)]
        [TestMethod]
        public void Int64Test(long min, long max) => test(min, max);


        [DataRow(1000.0, -1000.0)]
        [DataRow(-1000.0, 1000.0)]
        [DataRow(0.0, 1000.0)]
        [DataRow(-1000.0, 0.0)]
        [DataRow(double.MinValue, double.MinValue + 1.0E+308)]
        [DataRow(double.MaxValue - 1.0E+308, double.MaxValue)]
        [TestMethod]
        public void DoubleTest(double min, double max) => test(min, max);


        [DataRow(char.MinValue, char.MaxValue)]
        [DataRow('a', 'z')]
        [DataRow('1', 'P')]
        [DataRow('A', 'z')]
        [TestMethod] public void CharTest(char min, char max) => test(min, max);


        [TestMethod] public void BoolTest()
        {
            var x = GetRandom.Bool();
            var y = GetRandom.Bool();
            var i = 0;
            while (x == y)
            {
                y = GetRandom.Bool();
                if (i == 5) areNotEqual(x, y);
                i++;
            }
        }

        [DynamicData(nameof(DateTimeValues), DynamicDataSourceType.Property)]
        [TestMethod] public void DatetimeTest(DateTime min, DateTime max) => test(min, max);
        private static IEnumerable<object[]> DateTimeValues => new List<object[]>()
        {
            new object[] { DateTime.Now.AddYears(-100), DateTime.Now.AddYears(100) },
            new object[] { DateTime.Now.AddYears(100), DateTime.Now.AddYears(-100) },
            new object[] { DateTime.MaxValue.AddYears(-100), DateTime.MaxValue},
            new object[] { DateTime.MinValue, DateTime.MinValue.AddYears(100)},
        };
        [TestMethod] public void StringTest()
        {
            var x = GetRandom.Value<string>();
            var y = GetRandom.Value<string>();
            isInstanceOfType(x, typeof(string));
            isInstanceOfType(y, typeof(string));
            areNotEqual(x, y);
        }
        [TestMethod] public void ValueTest()
        {
            var x = GetRandom.Value<StudentData>() as StudentData;
            var y = GetRandom.Value<StudentData>() as StudentData;
            areNotEqual(x.Id, y.Id, nameof(x.Id));
            areNotEqual(x.FirstName, y.FirstName, nameof(x.FirstName));
            areNotEqual(x.LastName, y.LastName, nameof(x.LastName));
            areNotEqual(x.Age, y.Age, nameof(x.Age));
            areNotEqual(x.YearInUniversity, y.YearInUniversity, nameof(x.YearInUniversity));
        }

    }
}
