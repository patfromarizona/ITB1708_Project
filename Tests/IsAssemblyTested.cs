using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TeamUP.Aids;

namespace TeamUP.Tests
{
    [TestClass]
    public abstract class IsAssemblyTested : TestAsserts
    {
        private static string testsStr => "Tests";
        private static string testsProjectStr => $"{testsStr}.";
        private string notTestedMsg => $"Class \"{fullNameOfFirstNotTested()}\" is not tested";
        
        private Assembly? testingAssembly;
        private Assembly? assemblyToBeTested;
        private List<Type>? testingTypes;
        private List<Type>? typesToBeTested;
        private string? namespaceOfTest;
        private string? namespaceOfType;              

        [TestMethod] public void IsAllTested() => isAllTested();

        protected virtual void isAllTested()
        {
            testingAssembly = getAssembly(this);
            testingTypes = getTypes(testingAssembly);
            namespaceOfTest = getNamespace(this);
            removeNotInNamespace(testingTypes, namespaceOfTest);
            removeNotClassTests();
            removeNotCorrectTests();
            namespaceOfType = removeTestsTagFrom(namespaceOfTest);
            assemblyToBeTested = getAssembly(namespaceOfType);
            typesToBeTested = getTypes(assemblyToBeTested);
            removeNotInNamespace(typesToBeTested, namespaceOfType);
            removeNotNeededTesting();
            removeInterfaces();
            removeTested();
            removeDuplications();
            if (allAreTested()) return;
            reportNotAllIsTested();
        }

        private void removeInterfaces() => typesToBeTested?.Remove(t => t.IsInterface);
        private void removeNotClassTests() => testingTypes.Remove(x => !Types.NameEnds(x, testsStr));
        private void removeNotInNamespace(List<Type> t, string nameSpace) => t?.Remove(x => !Types.NameStarts(x, nameSpace));
        private void removeNotCorrectTests() => testingTypes.Remove(x => !isCorrectTest(x));
        private static Assembly? getAssembly(object o) => GetAssembly.OfType(o);
        private static Assembly? getAssembly(string? name) => GetAssembly.ByName(name);
        private static string? removeTestsTagFrom(string? s) => s?.Remove(testsProjectStr);
        private static string? getNamespace(object o) => GetNamespace.OfType(o);
        private static List<Type>? getTypes(Assembly? a) => GetAssembly.Types(a);
        private void reportNotAllIsTested() => isInconclusive(notTestedMsg);
        private string fullNameOfFirstNotTested() => firstNotTestedType(typesToBeTested)?.FullName ?? string.Empty;
        public static Type? firstNotTestedType(List<Type>? l) => l.GetFirst();
        private void removeTested() => typesToBeTested?.RemoveAll(x => isItTested(x));
        private void removeDuplications() => typesToBeTested?.RemoveAll(x => isItDuplicated(x));
        private bool isItTested(Type x)
        {
            var t = testingTypes?.Find(y => isTestFor(y, x));
            if (t is null) return false;
            _ = testingTypes?.Remove(t);
            return t is not null;
        }
        private bool isItDuplicated(Type x)
        {
            var t = typesToBeTested?.Find(y => isDuplicated(y, x));
            if (t is null) return false;
            _ = typesToBeTested?.Remove(t);
            return t is not null;
        }
        private static bool isCorrectTest(Type x) => isCorrectlyInherited(x) && isTestClass(x);
        private static bool isTestClass(Type x) => x?.HasAttribute<TestClassAttribute>() ?? false;
        private static bool isCorrectlyInherited(Type x) => x.IsInherited(typeof(IsTypeTested));
        private static bool isTestFor(Type testingType, Type typeToBeTested)
        {
            var testName = typeToBeTested.FullName?? string.Empty;
            testName = testName.RemoveHead();
            var lenght = testName.IndexOf('`');
            if(lenght >= 0) testName = testName[..lenght];
            testName += testsStr;
            return testingType.NameEnds($".{testName}");
        }
        private static bool isDuplicated(Type x, Type y)
        {
            if (x == y) return false;
            var nameX = x.Name;
            var nameY = y.Name;
            var lenghtX = nameX.IndexOf('`');
            var lenghtY = nameY.IndexOf('`');
            if (lenghtX >= 0) nameX = nameX[..lenghtX];
            if (lenghtY >= 0) nameY = nameY[..lenghtY];
            return nameX == nameY;
        }
        private void removeNotNeededTesting() => typesToBeTested?.Remove(x => !isTypeToBeTested(x));
        private bool isTypeToBeTested(Type x) => x?.BelongsTo(namespaceOfType) ?? false;
        private bool allAreTested() => typesToBeTested.IsEmpty();
    }
}
