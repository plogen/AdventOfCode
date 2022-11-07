using Common;
using static aoc2015.Day02;
using static aoc2015.Day07;

namespace aoc2015.Tests
{

    [TestFixture]
    public class TestDay08
    {
        private readonly int day = 8;
        private List<string> input = null!;
        private List<string> exampleInput = null!;

        [OneTimeSetUp]
        public void Setup()
        {
            input = ReadInputFile.GetInputDayPadding(day, "input.txt");
            exampleInput = ReadInputFile.GetInputDayPadding(day, "exampleInput.txt");
        }

        [Test]
        public void ExamplePart1()
        {
            var answer = Day08.Part1(exampleInput);
            Assert.AreEqual(12, answer);
        }

        [Test]
        public void Part1()
        {
            var answer = Day08.Part1(input);
            Assert.AreEqual(1333, answer);
        }


        [Test]
        public void ExamplePart2()
        {
            var answer = Day08.Part2(exampleInput);
            Assert.AreEqual(19, answer);
        }

        [Test]
        public void Part2()
        {
            var answer = Day08.Part2(input);
            Assert.AreEqual(2046, answer);
        }
    }


}