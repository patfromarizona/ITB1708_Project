

using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Aids;
using TeamUP.Data.Party;

namespace TeamUP.Tests.Data.Party
{
    [TestClass]
    public class IsoGenderTests : IsTypeTested
    {
        [TestMethod] public void NotKnownTest() => doTest(IsoGender.NotKnown, 0, "Not Known");
        [TestMethod] public void MaleTest() => doTest(IsoGender.Male, 1, "Male");
        [TestMethod] public void FemaleTest() => doTest(IsoGender.Female, 2, "Female");
        [TestMethod] public void NotApplicableTest() => doTest(IsoGender.NotApplicable, 9, "Not Applicable");


        private void doTest(IsoGender isoGender, int value, string description)
        {
            areEqual(value, (int)isoGender);
            areEqual(description, isoGender.Description());
        }
    }








}