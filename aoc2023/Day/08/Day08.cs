using Common;
using System.Text.RegularExpressions;

//Puzzle: https://adventofcode.com/2023/day/8
namespace aoc2023
{
    public class Day08: DayPuzzle
    {
        public static Regex nodesRegex = new Regex(@"\w+");

        public override object Part1(List<string> input)
        {
            var instructions = input[0];

            var nodes = input.Skip(2).Select(i => new Node(i.Substring(0,3), i.Substring(7,3), i.Substring(12,3))).ToList();

            int i = 0;
            string node = "AAA";
            int stepps = 0;
            while (true)
            {
                var currentNode = nodes.First(n => n.x == node);

                if (currentNode.x == "ZZZ")
                    break;

                if (instructions[i] == 'L')
                    node = currentNode.y;
                else
                    node = currentNode.z;

                stepps++;
                i++;
                if (instructions.Count() == i)
                    i = 0;
            }

            return stepps;
        }

        public override object Part2(List<string> input)
        {
            throw new NotImplementedException();
        }

        private record Node(string x, string y, string z);
    }
}