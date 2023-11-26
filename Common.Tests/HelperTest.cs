using aoc2021;
using NUnit.Framework;
using System.Collections.Generic;

namespace Common.Tests
{

    [TestFixture]
    public class HelperTest
    {
        [Test]
        public void OperatorAddTest()
        {
            Assert.AreEqual(3, Helper.Operators["+"](1, 2));
            Assert.AreEqual(5, Helper.Operators["+"](3, 2));
        }

        [Test]
        public void OperatorSubtractTest()
        {
            Assert.AreEqual(-1, Helper.Operators["-"](1, 2));
            Assert.AreEqual(1, Helper.Operators["-"](3, 2));
        }

        [Test]
        public void OperatorDevideTest()
        {
            Assert.AreEqual(1, Helper.Operators["/"](2, 2));
            Assert.AreEqual(3, Helper.Operators["/"](6, 2));
        }

        [Test]
        public void OperatorMultiplyTest()
        {
            Assert.AreEqual(4, Helper.Operators["*"](2, 2));
            Assert.AreEqual(12, Helper.Operators["*"](6, 2));
        }
    }
}