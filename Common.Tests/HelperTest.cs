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
        public void OperatorDivideTest()
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


        [Test]
        public void IsAllIncreasingTest()
        {
            Assert.That(new[] { 1, 2, 3, 8, 9 }.IsAllIncreasing(), Is.True, "Array shall count as AllIncreasing");
            Assert.That(new[] { 0, 2, 9, 11, 20 }.IsAllIncreasing(), Is.True, "Array shall count as AllIncreasing");
            Assert.That(new[] { -3, -2, -1, 0, 1 }.IsAllIncreasing(), Is.True, "Array shall count as AllIncreasing");
            Assert.That(new[] { 1, 2, 2, 8, 9 }.IsAllIncreasing(), Is.False, "Array shall not count as AllIncreasing");
            Assert.That(new[] { 1, 2, 3, 4, 2 }.IsAllIncreasing(), Is.False, "Array shall not count as AllIncreasing");
            Assert.That(new[] { 1, 2, 3, 4, -2 }.IsAllIncreasing(), Is.False, "Array shall not count as AllIncreasing");
        }

        [Test]
        public void IsAllDecreasingTest()
        {
            Assert.That(new[] { 9, 8, 5, 4, 1 }.IsAllDecreasing(), Is.True, "Array shall count as IsAllDecreasing");
            Assert.That(new[] { 20, 11, 9, 2, 1 }.IsAllDecreasing(), Is.True, "Array shall count as IsAllDecreasing");
            Assert.That(new[] { 1, 0, -1, -2, -3 }.IsAllDecreasing(), Is.True, "Array shall count as IsAllDecreasing");
            Assert.That(new[] { 9, 8, 2, 2, 1 }.IsAllDecreasing(), Is.False, "Array shall not count as IsAllDecreasing");
            Assert.That(new[] { 4, 3, 2, 1, 2 }.IsAllDecreasing(), Is.False, "Array shall not count as IsAllDecreasing");
            Assert.That(new[] { 1, 0, -1, -2, -1 }.IsAllDecreasing(), Is.False, "Array shall not count as IsAllDecreasing");
        }


        [Test]
        public void IsToLargeStepsTest()
        {
            Assert.That(new[] { 9, 8, 5, 2, 0 }.IsWithinSteps(3), Is.True, "Array shall count as IsWithinSteps");
            Assert.That(new[] { 4, 3, 2, 1, 2 }.IsWithinSteps(3), Is.True, "Array shall count as IsWithinSteps");
            Assert.That(new[] { 1, 0, -1, -2, 1 }.IsWithinSteps(3), Is.True, "Array shall count as IsWithinSteps");
            Assert.That(new[] { 9, 8, 4, 3, 2 }.IsWithinSteps(3), Is.False, "Array shall not count as IsWithinSteps");
            Assert.That(new[] { 20, 11, 9, 2, 1 }.IsWithinSteps(3), Is.False, "Array shall not count as IsWithinSteps");
            Assert.That(new[] { 1, -3, -1, -2, -3 }.IsWithinSteps(3), Is.False, "Array shall not count as IsWithinSteps");
        }

    }
}