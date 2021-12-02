using _2020.Day._5;
using Common;
using NUnit.Framework;

namespace aoc2020.Tests
{
    [TestFixture]
    public class TestDay5
    {
        private readonly int day = 5;
        private int[] input = null!;
        private int[] exampleInput = null!;

        [OneTimeSetUp]
        public void Setup()
        {
            //input = ReadInputFile.GetInput(day, "input.txt").ToArray();
        }

        [Test]
        public void ExamplePart1()
        {
            var expected0 = new BoardingPass() { Input = "FBFBBFFRLR", Row = 70, Col = 7, SeatID = 567 };
            var actual0 = Day5.GetBoardingPass(expected0.Input);

            var expected1 = new BoardingPass() { Input = "BFFFBBFRRR", Row = 70, Col = 7, SeatID = 567 };
            var actual1 = Day5.GetBoardingPass(expected1.Input);
            Assert.AreEqual(expected1, actual1);
            var example2 = new BoardingPass() { Input = "FFFBBBFRRR", Row = 14, Col = 7, SeatID = 119 };
            var example3 = new BoardingPass() { Input = "BBFFBBFRLL", Row = 102, Col = 4, SeatID = 820 };
        }

        //[Test]
        //public void Part1()
        //{
        //    var answer = Day1.Part1(input);
        //    Assert.AreEqual(1559, answer);
        //}

        //[Test]
        //public void Part2()
        //{
        //    var answer = Day1.Part2(input);
        //    Assert.AreEqual(1600, answer);
        //}
    }
}