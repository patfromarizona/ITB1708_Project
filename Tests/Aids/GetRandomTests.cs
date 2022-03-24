using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TeamUP.Aids;

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
        [TestMethod] public void Int32Test(int min, int max) 
        {
            test(min, max);
        }

        [DataRow(1000.0, -1000.0)]
        [DataRow(-1000.0, 1000.0)]
        [DataRow(0.0, 1000.0)]
        [DataRow(-1000.0, 0.0)]
        [DataRow(double.MinValue, double.MinValue + 1.0E+308)]
        [DataRow(double.MaxValue - 1.0E+308, double.MaxValue)]
        [TestMethod]
        public void DoubleTest(double min, double max)
        {
            test(min, max);
        }
        [TestMethod] public void CharTest() => isInconclusive();
        [TestMethod] public void BoolTest() => isInconclusive();
        [TestMethod] public void DatetimeTest() => isInconclusive();
        [TestMethod] public void StringTest() => isInconclusive();
        [TestMethod] public void ValueTest() => isInconclusive();

    }
}
