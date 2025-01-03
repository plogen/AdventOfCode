﻿using Common;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using aoc2023;

namespace aoc2023.Tests
{

    [TestFixture]
    public class Day11Test
    {
        private const int day = 11;
        private List<string> input = null!;
        private List<string> exampleInput = null!;

        [OneTimeSetUp]
        public void Setup()
        {
            input = ReadInputFile.GetInputDayPadding(11, "input.txt");
            exampleInput = ReadInputFile.GetInputDayPadding(11, "exampleInput.txt");
        }

        [Test]
        public void ExamplePart1()
        {
            var answer = new Day11().Part1(exampleInput);
            Assert.AreEqual(374, answer);
        }

        [Test]
        public void Part1()
        {
            var answer = new Day11().Part1(input);
            Assert.AreEqual(9769724, answer);
        }

        [Test]
        public void ExamplePart2()
        {
            var answer = new Day11().Part2(exampleInput);
            Assert.AreEqual(82000210, answer);
        }

        [Test]
        public void Part2()
        {
            var answer = new Day11().Part2(input);
            Assert.AreEqual(603020563700, answer);
        }

    }
}
