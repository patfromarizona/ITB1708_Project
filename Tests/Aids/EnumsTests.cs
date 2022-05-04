﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using TeamUP.Aids;
using TeamUP.Data.Party;

namespace TeamUP.Tests.Aids
{
    [TestClass] public class EnumsTests : TypeTests
    {
        [TestMethod] public void DescriptionTest()
            => areEqual("Not Applicable", Enums.Description(IsoGender.NotApplicable));
        [TestMethod] public void ToStringTest()
            => areEqual("NotApplicable", IsoGender.NotApplicable.ToString());

    }
}
