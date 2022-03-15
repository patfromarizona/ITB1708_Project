﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TeamUP.Tests
{
    public abstract class AbstractClassTests : BaseTests 
    {
        [TestMethod] public void isAbstractTest() => isTrue(obj?.GetType()?.BaseType?.IsAbstract ?? false);
    }
}
