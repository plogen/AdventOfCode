using Common;
using System.Text.RegularExpressions;

//Puzzle: https://adventofcode.com/2023/day/8
namespace aoc2023
{
    public class Day08: DayPuzzle
    {
        public static Regex part1StopAtRegex = new Regex(@"ZZZ");
        public static Regex part2StopAtRegex = new Regex(@"\w\wZ");

        public override object Part1(List<string> input)
        {
            var instructions = input[0];

            var nodes = input.Skip(2).Select(i => new Node(i.Substring(0, 3), i.Substring(7, 3), i.Substring(12, 3), null)).ToList();

            var startingNode = nodes.First(n => n.x == "AAA");

            return GetStepps(instructions, nodes, new List<Node>() { startingNode }, part1StopAtRegex);
        }

        public override object Part2(List<string> input)
        {
            var instructions = input[0];

            var nodes = input.Skip(2).Select(i => new Node(i.Substring(0, 3), i.Substring(7, 3), i.Substring(12, 3), null)).ToList();

            var startingNodes = nodes.Where(n => n.x[2] == 'A').ToList();

            return GetStepps(instructions, nodes, startingNodes, part2StopAtRegex);
        }


        private static object GetStepps(string instructions, List<Node> nodes, List<Node> startingNodes, Regex stoppAt)
        {
            int instructionCount = instructions.Count();
            int i = 0;
            int stepps = 0;

            startingNodes.ForEach(n => { n.currentStepp = n.x; });
            Dictionary<string, Node> map = new Dictionary<string, Node>();
            nodes.ForEach(n => { map.Add(n.x, n); });


            while (true)
            {
                if (startingNodes.All(s => stoppAt.Match(s.currentStepp).Success))
                    break;

                foreach (var node in startingNodes)
                {
                    //var currentNode = nodes.First(n => n.x == node.currentStepp);
                    var currentNode = map[node.currentStepp];

                    if (instructions[i] == 'L')
                        node.currentStepp = currentNode.y;
                    else
                        node.currentStepp = currentNode.z;
                }

                stepps++;
                i++;

                if (instructionCount == i)
                    i = 0;
            }

            return stepps;
        }


        private class Node
        {
            public string x { get; set; }
            public string y { get; set; }
            public string z { get; set; }
            public bool endsWithZ { get; set; }
            public string currentStepp { get; set; }

            public Node(string x, string y, string z, string currentStepp)
            {
                this.x = x;
                this.y = y;
                this.z = z;
                this.currentStepp = currentStepp;
                this.endsWithZ = x[2] == 'Z';
            }

        };
    }
}