using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using System.Linq;
using TeamUP.Aids;
using System;
using TeamUP.Data.Party;

namespace TeamUP.Tests.Aids
{
    [TestClass] public class GetAssemblyTests : IsTypeTested
    {
        private string? assemblyName;
        private Assembly? assembly;
        private string[] typenames = Array.Empty<string>();

        [TestInitialize] public void Init()
        {
            assemblyName = $"{nameof(TeamUP)}.{nameof(TeamUP.Aids)}";
            assembly = GetAssembly.ByName(assemblyName);
            typenames = new string[] { nameof(Chars), nameof(Enums), nameof(Lists), nameof(Strings), nameof(Safe), nameof(Types) };
        }
        [TestCleanup] public void Clean()
        {
            isNotNull(assembly);
            areEqual(assemblyName, assembly?.GetName().Name);
        }
        [TestMethod] public void ByNameTest() { }
        [TestMethod] public void TypesTest()
        {
            var l = GetAssembly.Types(assembly);
            isTrue(typenames.Length <= (l?.Count ?? -1));
            foreach (var n in typenames)
                areEqual(l?.FirstOrDefault(x => x.Name == n)?.Name, n);
            isNull(l?.FirstOrDefault(x => x.Name == GetRandom.String())); 
        }
        [TestMethod]
        public void OfTypeTest()
        {
            assemblyName = $"{nameof(TeamUP)}.{nameof(TeamUP.Data)}";
            var obj = new StudentData();
            assembly = GetAssembly.OfType(obj);
        }
        [TestMethod] public void TypeTest()
        {
            var n = randomTypeName;
            var obj = GetAssembly.Type(assembly, n);
            isNotNull(obj);
            areEqual(n, obj.Name);
        }

        private string randomTypeName => typenames[GetRandom.Int32(0, typenames.Length)];
        
    }
}
