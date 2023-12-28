using Common;
using System.Collections.Generic;

//Puzzle: https://adventofcode.com/2023/day/12
namespace aoc2023
{
    public class Day12: DayPuzzle
    {
        public override object Part1(List<string> input)
        {
            var springs = GetSprings(input);

            return null;
        }

        private static List<Spring> GetSprings(List<string> rows)
        {
            List<Spring> springs = new();
            foreach (var row in rows)
            {
                var data = row.Split(' ');

                springs.Add(new()
                {
                    Line = data[0],
                    Springs = data[1].Split(',').Select(x => int.Parse(x)).ToList()
                });
            }
            return springs;
        }

        public override object Part2(List<string> input)
        {
            throw new NotImplementedException();
        }

        private class Spring
        {
            public string Line { get; set; }
            public List<int> Springs { get; set; }
        }
    }
}