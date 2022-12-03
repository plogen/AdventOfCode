using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2022
{
    public static class Day02
    {
        public static long Part1(List<string> input)
        {
            return input.Select(x => GetRoundPointsPart1(x)).Sum();
        }

        public static long Part2(List<string> input)
        {
            return input.Select(x => GetRoundPointsPart2(x)).Sum();
        }


        private static int GetRoundPointsPart1(string input)
        {
            var oponentHand = OponentHand(input[0]);
            var myHand = MyHand(input[2]);

            return GetPointsGromHands(oponentHand, myHand);

        }

        private static int GetRoundPointsPart2(string input)
        {
            var oponentHand = OponentHand(input[0]);
            var expexterResult = GetResult(input[2]);
            var myHand = GetHandForExpextedResult(expexterResult, oponentHand);

            return GetPointsGromHands(oponentHand, myHand);
        }



        private static int GetPointsGromHands(Hand oponentHand, Hand myHand)
        {
            int outcomeScore = 0;
            int handScore = 0;

            if (myHand == oponentHand)
                outcomeScore = 3;

            //Rock
            if (myHand == Hand.Rock && oponentHand == Hand.Paper)
                outcomeScore = 0;

            if (myHand == Hand.Rock && oponentHand == Hand.Scissor)
                outcomeScore = 6;


            //Paper
            if (myHand == Hand.Paper && oponentHand == Hand.Scissor)
                outcomeScore = 0;

            if (myHand == Hand.Paper && oponentHand == Hand.Rock)
                outcomeScore = 6;


            //Scissor
            if (myHand == Hand.Scissor && oponentHand == Hand.Rock)
                outcomeScore = 0;

            if (myHand == Hand.Scissor && oponentHand == Hand.Paper)
                outcomeScore = 6;


            switch (myHand)
            {
                case Hand.Rock:
                    handScore = 1;
                    break;
                case Hand.Paper:
                    handScore = 2;
                    break;
                case Hand.Scissor:
                    handScore = 3;
                    break;
                default:
                    break;
            }

            return outcomeScore + handScore;
        }


        private static Hand GetHandForExpextedResult(Result expectedResult, Hand oponentHand)
        {
            if (expectedResult == Result.Draw)
                return oponentHand;

            if (oponentHand == Hand.Rock)
            {
                switch (expectedResult)
                {
                    case Result.Lose:
                        return Hand.Scissor;
                    case Result.Win:
                        return Hand.Paper;
                    default:
                        throw new System.Exception("Invalid evaluation");
                        break;
                }
            }

            if (oponentHand == Hand.Paper)
            {
                switch (expectedResult)
                {
                    case Result.Lose:
                        return Hand.Rock;
                    case Result.Win:
                        return Hand.Scissor;
                    default:
                        throw new System.Exception("Invalid evaluation");
                        break;
                }
            }

            if (oponentHand == Hand.Scissor)
            {
                switch (expectedResult)
                {
                    case Result.Lose:
                        return Hand.Paper;
                    case Result.Win:
                        return Hand.Rock;
                    default:
                        throw new System.Exception("Invalid evaluation");
                        break;
                }
            }

            throw new System.Exception("Invalid evaluation");

        }



        private static Hand OponentHand(char input)
        {
            switch (input)
            {
                case 'A':
                    return Hand.Rock;
                case 'B':
                    return Hand.Paper;
                case 'C':
                    return Hand.Scissor;
                default:
                    throw new System.Exception("Invalid input");
                    break;
            }
        }

        private static Hand MyHand(char input)
        {
            switch (input)
            {
                case 'X':
                    return Hand.Rock;
                case 'Y':
                    return Hand.Paper;
                case 'Z':
                    return Hand.Scissor;
                default:
                    throw new System.Exception("Invalid input");
                    break;
            }
        }



        private static Result GetResult(char input)
        {
            switch (input)
            {
                case 'X':
                    return Result.Lose;
                case 'Y':
                    return Result.Draw;
                case 'Z':
                    return Result.Win;
                default:
                    throw new System.Exception("Invalid input");
                    break;
            }
        }


        public enum Hand
        {
            Rock,
            Paper,
            Scissor
        }


        public enum Result
        {
            Lose,
            Draw,
            Win
        }



    }
}
