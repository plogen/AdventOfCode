using Common;
using System;
using System.Text.RegularExpressions;

//Puzzle: https://adventofcode.com/2023/day/6
namespace aoc2023
{
    public class Day06 : DayPuzzle
    {
        public static Regex numbersRegex = new Regex(@"\s+(\d+)");

        public override object Part1(List<string> input)
        {
            var raceTimes = numbersRegex.Matches(input[0]).Select(m => long.Parse(m.Groups[1].Value)).ToList();
            var raceDistanceRecord = numbersRegex.Matches(input[1]).Select(m => long.Parse(m.Groups[1].Value)).ToList();
            return GetMargin(raceTimes, raceDistanceRecord);
        }
        public override object Part2(List<string> input)
        {
            var raceTimes = new List<long>() { int.Parse(input[0].Remove(0, 5).Replace(" ", "")) };
            var raceDistanceRecord = new List<long>() { long.Parse(input[1].Remove(0, 9).Replace(" ", "")) };
            return GetMargin(raceTimes, raceDistanceRecord);
        }


        private static object GetMargin(List<long> raceTimes, List<long> raceDistanceRecord)
        {
            int[] wins = new int[raceTimes.Count];

            for (int race = 0; race < raceTimes.Count; race++)
            {
                for (int tick = 0; tick < raceTimes[race]; tick++)
                {
                    var speed = tick;
                    var timeLeft = raceTimes[race] - tick;
                    var distance = speed * timeLeft;
                    if (distance > raceDistanceRecord[race])
                    {
                        wins[race]++;
                    }
                }
            }

            long margin = 1;
            foreach (int win in wins)
            {
                margin *= win;
            }

            return margin;
        }

    }
}