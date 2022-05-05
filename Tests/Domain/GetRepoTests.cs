using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TeamUP.Domain;
using TeamUP.Domain.Party;
using TeamUP.Infra.Party;

namespace TeamUP.Tests.Domain
{
    [TestClass] public class GetRepoTests : TypeTests
    {
        private class testClass : IServiceProvider
        {
            public object? GetService(Type serviceType)
            {
                throw new NotImplementedException();
            }
        }
        [TestMethod] public void InstanceTest()
            => Assert.IsInstanceOfType(GetRepo.Instance<IStudentsRepo>(), typeof(StudentsRepo));
        [TestMethod] public void SetServiceTest() 
        {
            var s = GetRepo.service;
            var x = new testClass();
            GetRepo.SetService(x);
            areEqual(x, GetRepo.service);
            GetRepo.service = s;
        }
    }
}
