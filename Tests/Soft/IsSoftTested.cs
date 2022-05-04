using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamUP.Tests.Soft
{
    [TestClass]
    public class IsSoftTested : AssemblyTests
    {
        protected override void isAllTested() => isInconclusive("Namespace has to be changed to \"TeamUP.Soft\" ");
    }
}
