

using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Data;
using TeamUP.Data.Party;

namespace TeamUP.Tests.Data.Party
{
    [TestClass] public class UniversityStudentDataTests : SealedClassTests<UniversityStudentData, EntityData> 
    {
        [TestMethod] public void StudentIdTest() => isProperty<string>();
        [TestMethod] public void UniversityIdTest() => isProperty<string>();
    }
}