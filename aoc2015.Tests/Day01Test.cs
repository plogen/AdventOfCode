using Common;

namespace aoc2015.Tests
{

    [TestFixture]
    public class TestDay01
    {
        private readonly int day = 1;
        private string input = null!;

        [OneTimeSetUp]
        public void Setup()
        {
            input = ReadInputFile.GetInputDayPadding(day, "input.txt").First();
        }

        [Test]
        [TestCase("(())", 0)]
        [TestCase("()()", 0)]
        [TestCase("(((", 3)]
        [TestCase("(()(()(", 3)]
        [TestCase("))(((((", 3)]
        [TestCase("())", -1)]
        [TestCase("))(", -1)]
        [TestCase(")))", -3)]
        [TestCase(")())())", -3)]
        public void ExamplePart1(string input, int expected)
        {
            var answer = Day01.Part1(input);
            Assert.AreEqual(expected, answer);
        }

        [Test]
        public void Part1()
        {
            var answer = Day01.Part1(input);
            Assert.AreEqual(-1, answer);
        }

        [Test]
        public void Part2()
        {
            var answer = Day01.Part2(input);
            Assert.AreEqual(-1, answer);
        }
    }


}