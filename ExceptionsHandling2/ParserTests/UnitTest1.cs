using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringParserLibrary;

namespace ParserTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestEmptyString()
        {
            var testValue = string.Empty;

            var result = StringParser.ParseInt(testValue);
        }

        [TestMethod]
        public void TestPositiveInt()
        {
            var testValue = "25";

            var actual = StringParser.ParseInt(testValue);

            int expected = 25;
            Assert.AreEqual(expected, actual, "String is not parsed correctly");
        }

        [TestMethod]
        public void TestNegativeInt()
        {
            var testValue = "-25";

            var actual = StringParser.ParseInt(testValue);

            int expected = -25;
            Assert.AreEqual(expected, actual, "String is not parsed correctly");
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestFloatingNumber()
        {
            var testValue = "-25.56";

            var actual = StringParser.ParseInt(testValue);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TestIncorrectStringValue()
        {
            var testValue = "25a";

            var actual = StringParser.ParseInt(testValue);
        }
    }
}
