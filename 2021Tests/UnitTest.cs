using aoc2021;
using Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace aoc2021Tests
{
    [TestFixture]
    public class TestDay1
    {
        private readonly int day = 1;
        private List<int> input = null!;
        private List<int> exampleInput = null!;

        [OneTimeSetUp]
        public void Setup()
        {
            input = ReadInputFile.GetInput(day, "input.txt").Select(int.Parse).ToList();
            exampleInput = ReadInputFile.GetInput(day, "exampleInput.txt").Select(int.Parse).ToList();
        }

        [Test]
        public void ExamplePart1()
        {
            var answer = Day1.Part1(exampleInput.ToArray());
            Assert.AreEqual(7, answer);
        }

        [Test]
        public void Part1()
        {
            var answer = Day1.Part1(input.ToArray());
            Assert.AreEqual(1559, answer);
        }

        [Test]
        public void Part2()
        {
            var answer = Day1.Part2(input.ToArray());
            Assert.AreEqual(1600, answer);
        }
    }

    [TestFixture]
    public class TestDay2
    {
        private readonly int day = 2;
        private List<string> input = null!;
        private List<string> exampleInput = null!;

        [OneTimeSetUp]
        public void Setup()
        {
            input = ReadInputFile.GetInput(day, "input.txt");
            exampleInput = ReadInputFile.GetInput(day, "exampleInput.txt");
        }

        [Test]
        public void ExamplePart1()
        {
            var answer = Day2.Part1(exampleInput);
            Assert.AreEqual(150, answer);
        }

        [Test]
        public void Part1()
        {
            var answer = Day2.Part1(input);
            Assert.AreEqual(1690020, answer);
        }

        [Test]
        public void Part2()
        {
            var answer = Day2.Part2(input);
            Assert.AreEqual(1408487760, answer);
        }
    }

    [TestFixture]
    public class TestDay3
    {
        private readonly int day = 3;
        private List<string> input = null!;
        private List<string> exampleInput = null!;

        [OneTimeSetUp]
        public void Setup()
        {
            input = ReadInputFile.GetInput(day, "input.txt");
            exampleInput = ReadInputFile.GetInput(day, "exampleInput.txt");
        }

        [Test]
        public void ExamplePart1()
        {
            var answer = Day3.Part1(exampleInput);
            Assert.AreEqual(198, answer);
        }

        [Test]
        public void ExamplePart2()
        {
            var answer = Day3.Part2(exampleInput);
            Assert.AreEqual(230, answer);
        }

        [Test]
        public void Part1()
        {
            var answer = Day3.Part1(input);
            Assert.AreEqual(845186, answer);
        }

        [Test]
        public void Part2()
        {
            var answer = Day3.Part2(input);
            Assert.AreEqual(4636702, answer);
        }
    }

    [TestFixture]
    public class TestDay4
    {
        private readonly int day = 4;
        private List<string> input = null!;
        private List<string> exampleInput = null!;

        [OneTimeSetUp]
        public void Setup()
        {
            input = ReadInputFile.GetInput(day, "input.txt").ToList();
            exampleInput = ReadInputFile.GetInput(day, "exampleInput.txt").ToList();
        }

        [Test]
        public void ExamplePart1()
        {
            var answer = Day4.Part1(exampleInput);
            Assert.AreEqual(4512, answer);
        }

        [Test]
        public void Part1()
        {
            var answer = Day4.Part1(input);
            Assert.AreEqual(58838, answer);
        }

        [Test]
        public void Part2()
        {
            var answer = Day4.Part2(input);
            Assert.AreEqual(6256, answer);
        }
    }


    [TestFixture]
    public class TestDay5
    {
        private readonly int day = 5;
        private List<string> input = null!;
        private List<string> exampleInput = null!;

        [OneTimeSetUp]
        public void Setup()
        {
            input = ReadInputFile.GetInput(day, "input.txt").ToList();
            exampleInput = ReadInputFile.GetInput(day, "exampleInput.txt").ToList();
        }

        [Test]
        public void ExamplePart1()
        {
            var answer = Day5.Part1(exampleInput);
            Assert.AreEqual(5, answer);
        }

        [Test]
        public void ExamplePart2()
        {
            var answer = Day5.Part2(exampleInput);
            Assert.AreEqual(12, answer);
        }

        [Test]
        public void Part1()
        {
            var answer = Day5.Part1(input);
            Assert.AreEqual(7436, answer);
        }

        [Test]
        public void Part2()
        {
            //your answer is too low. If you're stuck, make sure you're using the full input data; there are also some general tips on the about page, or you can ask for hints on the subreddit.Please wait one minute before trying again. (You guessed 21080.)
            var answer = Day5.Part2(input);
            Assert.AreEqual(-1, answer);
        }
    }

    [TestFixture]
    public class TestDay6
    {
        private readonly int day = 6;
        private List<int> input = null!;
        private List<int> exampleInput = null!;

        [OneTimeSetUp]
        public void Setup()
        {
            input = ReadInputFile.GetInput(day, "input.txt").First().Split(',').Select(Int32.Parse).ToList();
            exampleInput = ReadInputFile.GetInput(day, "exampleInput.txt").First().Split(',').Select(Int32.Parse).ToList();
        }

        [Test]
        public void ExamplePart1()
        {
            var answer = Day6.Part1(exampleInput, 80);
            Assert.AreEqual(5934, answer);
        }

        [Test]
        public void ExamplePart2()
        {
            var answer = Day6.Part2(exampleInput, 256);
            Assert.AreEqual(26984457539, answer);
        }

        [Test]
        public void Part1()
        {
            var answer = Day6.Part1(input, 80);
            Assert.AreEqual(390923, answer);
        }

        [Test]
        public void Part2()
        {
            var answer = Day6.Part2(input, 256);
            Assert.AreEqual(1749945484935, answer);
        }
    }

    [TestFixture]
    public class TestDay7
    {
        private readonly int day = 7;
        private List<int> input = null!;
        private List<int> exampleInput = null!;

        [OneTimeSetUp]
        public void Setup()
        {
            input = ReadInputFile.GetInput(day, "input.txt").First().Split(',').Select(Int32.Parse).ToList();
            exampleInput = ReadInputFile.GetInput(day, "exampleInput.txt").First().Split(',').Select(Int32.Parse).ToList();
        }

        [Test]
        public void ExamplePart1()
        {
            var answer = Day7.Part1(exampleInput);
            Assert.AreEqual(37, answer);
        }

        [Test]
        public void ExamplePart2()
        {
            var answer = Day7.Part2(exampleInput);
            Assert.AreEqual(168, answer);
        }

        [Test]
        public void Part1()
        {
            var answer = Day7.Part1(input);
            Assert.AreEqual(345035, answer);
        }

        [Test]
        public void Part2()
        {
            var answer = Day7.Part2(input);
            Assert.AreEqual(97038163, answer);
        }
    }

    [TestFixture]
    public class TestDay8
    {
        private readonly int day = 8;
        private List<string> input = null!;
        private List<string> exampleInput = null!;

        [OneTimeSetUp]
        public void Setup()
        {
            input = ReadInputFile.GetInput(day, "input.txt").ToList();
            exampleInput = ReadInputFile.GetInput(day, "exampleInput.txt").ToList();
        }

        [Test]
        public void ExamplePart1()
        {
            var answer = Day8.Part1(exampleInput);
            Assert.AreEqual(26, answer);
        }

        [Test]
        public void ExamplePart2()
        {
            var answer = Day8.Part2(exampleInput);
            Assert.AreEqual(61229, answer);
        }

        [Test]
        public void Part1()
        {
            var answer = Day8.Part1(input);
            Assert.AreEqual(493, answer);
        }

        [Test]
        public void Part2()
        {
            var answer = Day8.Part2(input);
            Assert.AreEqual(-1, answer);
        }
    }

    [TestFixture]
    public class TestDay9
    {
        private readonly int day = 9;
        private int[][] input = null!;
        private int[][] exampleInput = null!;

        [OneTimeSetUp]
        public void Setup()
        {

            var inputRows = ReadInputFile.GetInput(day, "input.txt");
            input = ReadInputFile.GetInputAsMultiArrayInt(inputRows);

            var exampleInputRows = ReadInputFile.GetInput(day, "exampleInput.txt");
            exampleInput = ReadInputFile.GetInputAsMultiArrayInt(exampleInputRows);
        }

        [Test]
        public void ExamplePart1()
        {
            var answer = Day9.Part1(exampleInput);
            Assert.AreEqual(15, answer);
        }

        [Test]
        public void ExamplePart2()
        {
            var answer = Day9.Part2(exampleInput);
            Assert.AreEqual(1134, answer);
        }

        [Test]
        public void Part1()
        {
            var answer = Day9.Part1(input);
            Assert.AreEqual(458, answer);
        }

        [Test]
        public void Part2()
        {
            var answer = Day9.Part2(input);
            Assert.AreEqual(1391940, answer);
        }
    }

    [TestFixture]
    public class TestDay10
    {
        private readonly int day = 10;
        private List<string> input = null!;
        private List<string> exampleInput = null!;

        [OneTimeSetUp]
        public void Setup()
        {
            input = ReadInputFile.GetInput(day, "input.txt").ToList();
            exampleInput = ReadInputFile.GetInput(day, "exampleInput.txt").ToList();
        }

        [Test]
        public void ExamplePart1()
        {
            var answer = Day10.Part1(exampleInput);
            Assert.AreEqual(26397, answer);
        }

        [TestCase("{([(<{}[<>[]}>{[]{[(<()>", '}')]
        [TestCase("[[<[([]))<([[{}[[()]]]", ')')]
        [TestCase("[{[{({}]{}}([{[{{{}}([]", ']')]
        [TestCase("[<(<(<(<{}))><([]([]()", ')')]
        [TestCase("<{([([[(<>()){}]>(<<{{", '>')]
        public void ExamplePart1_2(string input, char expected)
        {
            var answer = Day10.PushPop(input);
            Assert.AreEqual(expected, answer);
        }


        [Test]
        public void ExamplePart2()
        {
            var answer = Day10.Part2(exampleInput);
            Assert.AreEqual(288957, answer);
        }

        [Test]
        public void Part1()
        {
            var answer = Day10.Part1(input);
            Assert.AreEqual(442131, answer);
        }

        [Test]
        public void Part2()
        {
            var answer = Day10.Part2(input);
            Assert.AreEqual(3646451424, answer);
        }
    }

    [TestFixture]
    public class TestDay11
    {
        private readonly int day = 11;
        private int[][] input = null!;
        private int[][] exampleInput = null!;

        [OneTimeSetUp]
        public void Setup()
        {
            var inputRows = ReadInputFile.GetInput(day, "input.txt");
            input = ReadInputFile.GetInputAsMultiArrayInt(inputRows);

            var exampleInputRows = ReadInputFile.GetInput(day, "exampleInput.txt");
            exampleInput = ReadInputFile.GetInputAsMultiArrayInt(exampleInputRows);
        }

        [Test]
        public void ExamplePart1()
        {
            var answer = Day11.Part1(exampleInput);
            Assert.AreEqual(1656, answer);
        }


        [Test]
        public void ExamplePart2()
        {
            var answer = Day11.Part2(exampleInput);
            Assert.AreEqual(195, answer);
        }

        [Test]
        public void Part1()
        {
            var answer = Day11.Part1(input);
            Assert.AreEqual(1640, answer);
        }

        [Test]
        public void Part2()
        {
            var answer = Day11.Part2(input);
            Assert.AreEqual(312, answer);
        }
    }
}