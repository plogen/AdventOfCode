using Common;
using static aoc2015.Day02;

namespace aoc2015.Tests
{

    [TestFixture]
    public class TestDay05
    {
        private readonly int day = 5;
        private List<string> input = null!;

        [OneTimeSetUp]
        public void Setup()
        {
            input = ReadInputFile.GetInputDayPadding(day, "input.txt");
        }

        [Test]
        [TestCase("ugknbfddgicrmopn", true)]
        [TestCase("aaa", true)]
        [TestCase("jchzalrnumimnmhp", false)]
        [TestCase("haegwjzuvuyypxyu", false)]
        [TestCase("dvszwmarrgswjxmb", false)]
        public void ExamplePart1(string input, bool expected)
        {
            var answer = Day05.IsNice(input);
            Assert.AreEqual(expected, answer);
        }

        [Test]
        public void Part1()
        {
            var answer = Day05.Part1(input);
            Assert.AreEqual(258, answer);
        }


        [Test]
        [TestCase("qjhvhtzxzqqjkmpb", 1)]
        [TestCase("xxyxx", 1)]
        [TestCase("uurcxstgmygtbstg", 0)]
        [TestCase("ieodomkazucvgmuy", 0)]
        public void ExamplePart2(string input, int expected)
        {
            var answer = Day05.Part2(new List<string> { input });
            Assert.AreEqual(expected, answer);
        }


        [Test]
        public void Part2()
        {
            var answer = Day05.Part2(input);
            Assert.AreEqual(53, answer);
        }
    }


}