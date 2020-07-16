using System;

using jcly.lib.Helpers;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace jcly.unittests.Helpers
{
    [TestClass]
    public class KeyGeneratorTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NegativeTest()
        {
            KeyGenerator.Generate(-1);
        }
    }
}