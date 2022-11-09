using Common;

namespace aoc2015.Tests
{

    [TestFixture]
    public class TestDay12
    {
        private readonly int day = 12;
        private List<string> input = null!;

        [OneTimeSetUp]
        public void Setup()
        {
            input = ReadInputFile.GetInputDayPadding(day, "input.txt");
        }

        [Test]
        [TestCase("[1,2,3]", 6)]
        [TestCase("{\"a\":2,\"b\":4}", 6)]
        [TestCase("[[[3]]]", 3)]
        [TestCase("{\"a\":{\"b\":4},\"c\":-1}", 3)]
        [TestCase("{\"a\":[-1,1]}", 0)]
        [TestCase("[-1,{\"a\":1}]", 0)]
        [TestCase("[]", 0)]
        [TestCase("{}", 0)]
        public void ExamplePart1(string input, int expected)
        {
            var answer = Day12.Part1(input);
            Assert.AreEqual(expected, answer);
        }

        [Test]
        public void Part1()
        {
            var answer = Day12.Part1(input.First());
            Assert.AreEqual(111754, answer);
        }

        [Test]
        public void Part2()
        {
            var answer = Day12.Part2(input.First());
            Assert.AreEqual(65402, answer);
        }
    }


}