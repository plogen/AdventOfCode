﻿using Common;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using aoc2023;

namespace aoc2023.Tests
{

    [TestFixture]
    public class Day01Test
    {
        private const int day = 01;
        private List<string> input = null!;
        private List<string> exampleInput = null!;

        [OneTimeSetUp]
        public void Setup()
        {
            input = ReadInputFile.GetInputDayPadding(01, "input.txt");
            exampleInput = ReadInputFile.GetInputDayPadding(01, "exampleInput.txt");
        }

        [Test]
        public void ExamplePart1()
        {
            var answer = new Day01().Part1(exampleInput);
            Assert.AreEqual(142, answer);
        }

        [Test]
        public void Part1()
        {
            var answer = new Day01().Part1(input);
            Assert.AreEqual(54916, answer);
        }

        [Test]
        public void ExamplePart2()
        {
            var answer = new Day01().Part2(exampleInput);
            Assert.AreEqual(-1, answer);
        }

        [Test]
        public void Part2()
        {
            var answer = new Day01().Part2(input);
            Assert.AreEqual(-1, answer);
        }

    }
}
