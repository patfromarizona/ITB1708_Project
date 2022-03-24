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
            namespaceOfType = removeTestsTagFrom(namespaceOfTest);
            assemblyToBeTested = getAssembly(namespaceOfType);
            typesToBeTested = getTypes(assemblyToBeTested);
            removeNotNeededTesting();
            removeTested();
            if (allAreTested()) return;
            reportNotAllIsTested();
        }

        private static Assembly? getAssembly(object o) => GetAssembly.OfType(o);
        private static Assembly? getAssembly(string? name) => GetAssembly.ByName(name);
        private static string? removeTestsTagFrom(string? s) => s?.Remove("Tests.");
        private static string? getNamespace(object o) => GetNamespace.OfType(o);
        private static List<Type>? getTypes(Assembly? a) => GetAssembly.Types(a);
        private void reportNotAllIsTested() => isInconclusive($"Class \"{fullNameOfFirstNotTested()}\" is not tested");
        private string fullNameOfFirstNotTested() => firstNotTestedType(typesToBeTested)?.FullName ?? string.Empty;
        public static Type? firstNotTestedType(List<Type>? l) => l.GetFirst();
        private void removeTested() => typesToBeTested?.Remove(x => isItTested(x));

        private bool isItTested(Type x) => testingTypes?.ContainsItem(y => isTestFor(y, x) && isCorrectTest(y)) ?? false;
        private static bool isCorrectTest(Type x) => isCorrectlyInherited(x) && isTestClass(x);

        private static bool isTestClass(Type x) => x?.HasAttribute<TestClassAttribute>() ?? false;

        private static bool isCorrectlyInherited(Type x) => x.IsInherited(typeof(IsTypeTested));

        private static bool isTestFor(Type testingType, Type typeToBeTested)
        {
            var testName = typeToBeTested.Name;
            var lenght = testName.IndexOf('`');
            if(lenght >= 0) testName = testName[..lenght];
            testName += "Tests";
            return testingType.NameEnds(testName);
        }

        private void removeNotNeededTesting() => typesToBeTested?.Remove(x => !isTypeToBeTested(x));
        private bool isTypeToBeTested(Type x) => x?.BelongsTo(namespaceOfType) ?? false;
        private bool allAreTested() => typesToBeTested.IsEmpty();
    }
}
