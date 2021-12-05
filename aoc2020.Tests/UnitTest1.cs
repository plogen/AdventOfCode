using _2020.Day._5;
using Common;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace aoc2020.Tests
{
    [TestFixture]
    public class TestDay5
    {
        private readonly int day = 5;
        private string[] input = null!;

        [OneTimeSetUp]
        public void Setup()
        {
            input = ReadInputFile.GetInput(day, "input.txt").ToArray();
        }

        [Test]
        public void ExamplePart1()
        {
            var expected0 = new BoardingPass() { Input = "FBFBBFFRLR", Row = 44, Col = 5, SeatID = 357 };
            var actual0 = Day5.GetBoardingPass(expected0.Input);
            Assert.AreEqual(expected0, actual0);

            var expected1 = new BoardingPass() { Input = "BFFFBBFRRR", Row = 70, Col = 7, SeatID = 567 };
            var actual1 = Day5.GetBoardingPass(expected1.Input);
            Assert.AreEqual(expected1, actual1);
            
            var expected2 = new BoardingPass() { Input = "FFFBBBFRRR", Row = 14, Col = 7, SeatID = 119 };
            var actual2 = Day5.GetBoardingPass(expected2.Input);
            Assert.AreEqual(expected2, actual2);

            var expected3 = new BoardingPass() { Input = "BBFFBBFRLL", Row = 102, Col = 4, SeatID = 820 };
            var actual3 = Day5.GetBoardingPass(expected3.Input);
            Assert.AreEqual(expected3, actual3);
        }

        [Test]
        public void Part1()
        {
            int highestSeatID = 0;
            List<BoardingPass> boardingPasses = new();
            foreach (var s in input)
            {
                var b = Day5.GetBoardingPass(s);
                if(b.SeatID > highestSeatID)
                    highestSeatID = b.SeatID;
                boardingPasses.Add(b);
            }

            //var highestSeatID = boardingPasses.OrderByDescending(b => b.SeatID).ToList();


            //Assert.AreEqual(887, highestSeatID.SeatID);
        }

        //[Test]
        //public void Part2()
        //{
        //    var answer = Day1.Part2(input);
        //    Assert.AreEqual(1600, answer);
        //}
    }
}