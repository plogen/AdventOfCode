using Common;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

//Puzzle: https://adventofcode.com/2023/day/9
namespace aoc2023
{
    public class Day09: DayPuzzle
    {
        public static Regex numbersRegex = new Regex(@"-?[0-9]\d*(\.\d+)?");
        public override object Part1(List<string> input)
        {

            List<List<List<long>>> measurements = new();

            foreach (string measurement in input)
            {
                List< List<long>> rows = new List< List<long>>();
                var firstRound = numbersRegex.Matches(measurement).Select(x => long.Parse(x.Groups[0].Value)).ToList();
                rows.Add(firstRound);

                bool finnished = false;
                int i = 0;
                while (finnished == false)
                {
                    var newRow = GetNewList(rows[i]);
                    rows.Add(newRow);
                    i++;
                    if(newRow.All(n => n == 0))
                        finnished = true;
                }


                for (int r = rows.Count-1; r > 0; r--)
                {
                    if(r == rows.Count - 1)
                        rows[r].Add(0);

                    if (r > 0)
                    {
                        var rowAbove = rows[r - 1];
                        var rowAboveCount = rowAbove.Count;
                        var diff = rowAbove[rowAboveCount-1] + rows[r].Last();
                         
                        rows[r - 1].Add(diff);
                    }
                }

                measurements.Add(rows);
            }

            var value = measurements.Select(x => new BigInteger(x.First().Last()));

            return value.Aggregate(BigInteger.Add);
        }

        private static List<long> GetNewList(List<long> numbers)
        {
            List<long> steps = new List<long>();
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                steps.Add(numbers[i + 1] - numbers[i]);
            }
            return steps;
        }

        public override object Part2(List<string> input)
        {
            throw new NotImplementedException();
        }
    }
}