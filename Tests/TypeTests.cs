using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Soft.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using TeamUP.Aids;
using TeamUP.Infra;

namespace TeamUP.Tests
{
    public class TestHost<TProgram> : WebApplicationFactory<TProgram> where TProgram : class 
    {
        protected override void ConfigureWebHost(IWebHostBuilder b)
        {
            base.ConfigureWebHost(b);
            b.ConfigureTestServices(s =>
               {
                   removeDb<ApplicationDbContext>(s);
                   removeDb<TeamUPDb>(s);
                   s.AddEntityFrameworkInMemoryDatabase();
                   addDb<ApplicationDbContext>(s);
                   addDb<TeamUPDb>(s);
                   ensureCreated(s, typeof(ApplicationDbContext), typeof(TeamUPDb));
               }
            );
        }

        private static void ensureCreated(IServiceCollection s, params Type[] types)
        {
            var sp = s.BuildServiceProvider();
            using var scope = sp.CreateScope();
            var scopedServices = scope.ServiceProvider;
            foreach (var type in types) ensureCreated(scopedServices, type);
        }

        private static void ensureCreated(IServiceProvider s, Type t)
        {
            if (s?.GetRequiredService(t) is not DbContext c)
                throw new ApplicationException($"DBContext {t} not found");
            c?.Database?.EnsureCreated();
            if (!c?.Database?.IsInMemory() ?? false)
                throw new ApplicationException($"DBContext {t} is not in memory");
        }

        private static void addDb<T>(IServiceCollection s) where T : DbContext
            => s.AddDbContext<T>(o => { o.UseInMemoryDatabase("Tests"); }); 

        private static void removeDb<T>(IServiceCollection s) where T : DbContext
        {
            var descriptor = s?.SingleOrDefault( d => d.ServiceType == typeof(DbContextOptions<T>));
            if(descriptor is not null) {s?.Remove(descriptor);}
        }
    }
    public class TestsHost : AssertsTests
    {
        internal static readonly TestHost<Program> host;
        internal static readonly HttpClient client;
        static TestsHost()
        {
            host = new TestHost<Program>();
            client = host.CreateClient();
        }
    }
    public class TypeTests : TestsHost
    {
        private string? nameOfTest;
        private string? nameOfType;
        private string? namespaceOfTest;
        private string? namespaceOfType;
        private Assembly? assemblyToBeTested;
        private Type? typeToBeTested;
        private List<string>? membersOfType;
        private List<string>? membersOfTest;

        [TestMethod] public void IsAllTested() => isAllTested();

        protected virtual void isAllTested()
        {
            nameOfTest = getName(this);
            nameOfType = removeTestsTagFrom(nameOfTest);
            namespaceOfTest = getNamespace(this);
            namespaceOfType = removeTestsTagFrom(namespaceOfTest);
            assemblyToBeTested = getAssembly(namespaceOfType);
            typeToBeTested = getType(assemblyToBeTested, nameOfType);
            membersOfType = getMembers(typeToBeTested);
            membersOfTest = getMembers(GetType());
            removeNotTests(GetType());
            removeNotNeedTesting();
            removeTested();
            if (allAreTested()) return;
            reportNotAllIsTested();

            
        }

        private void reportNotAllIsTested() => isInconclusive($"Member \"{nameOfFirstNotTested()}\" is not tested");
        private string nameOfFirstNotTested() => membersOfType?.GetFirst() ?? string.Empty;
        private bool allAreTested() => membersOfType.IsEmpty();
        private void removeTested() => membersOfType?.Remove(x => isItTested(x));
        private bool isItTested(string x) => membersOfTest?.ContainsItem(y => isTestFor(y, x)) ?? false;
        private static bool isTestFor(string testingMember, string memberToBeTested) 
            => testingMember.Equals(memberToBeTested + "Test");
        private void removeNotNeedTesting() => membersOfType?.Remove(x => !isTypeToBeTested(x));
        private static bool isTypeToBeTested(string x) => x?.IsTypeName() ?? false;

        private void removeNotTests(Type t) => membersOfTest?.Remove(x => !isCorrectTestMethod(x, t));

        private static bool isCorrectTestMethod(string x, Type t) => isCorrectlyInherited(t) && isTestClass(t) && isTestMethod(x, t);

        private static bool isTestMethod(string methodName, Type t) => t?.Method(methodName).HasAttribute<TestMethodAttribute>() ?? false;

        private static bool isCorrectlyInherited(Type x) => x.IsInherited(typeof(TypeTests));

        private static bool isTestClass(Type x) => x?.HasAttribute<TestClassAttribute>() ?? false;

        private static List<string>? getMembers(Type? t) => t?.DeclaredMembers();

        private static Type? getType(Assembly? a, string? name)
        {
            if (string.IsNullOrWhiteSpace(name)) return null; 
            foreach(var t in a?.DefinedTypes ?? Array.Empty<TypeInfo>())
            {
                if(t.Name.StartsWith(name)) return t.AsType(); 
            }
            return null;
        }

        private static Assembly? getAssembly(string? name)
        {
            while (!string.IsNullOrWhiteSpace(name))
            {
                var a = GetAssembly.ByName(name);
                if(a is not null) return a;
                name = name.RemoveTail();
            }
            return null;
        }

        private static string? getNamespace(object o) => GetNamespace.OfType(o);

        private static string? removeTestsTagFrom(string? s) 
            => s?.Remove("Tests")?.Remove("Test")?.Replace("..", ".");

        private static string? getName(object o) => Types.GetName(o?.GetType());


    }
}
