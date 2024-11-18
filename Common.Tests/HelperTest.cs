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
            Assert.That(3 == Helper.Operators['+'](1, 2));
            Assert.That(5 == Helper.Operators['+'](3, 2));
        }

        [Test]
        public void OperatorSubtractTest()
        {
            Assert.That(-1 == Helper.Operators['-'](1, 2));
            Assert.That(1 == Helper.Operators['-'](3, 2));
        }

        [Test]
        public void OperatorDevideTest()
        {
            Assert.That(1 == Helper.Operators['/'](2, 2));
            Assert.That(3 == Helper.Operators['/'](6, 2));
        }

        [Test]
        public void OperatorMultiplyTest()
        {
            Assert.That(4 == Helper.Operators['*'](2, 2));
            Assert.That(12 == Helper.Operators['*'](6, 2));
        }
    }
}