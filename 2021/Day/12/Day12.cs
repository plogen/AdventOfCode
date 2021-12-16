using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace aoc2021
{
    public static class Day12
    {
        private static readonly string startNodeID = "start";
        private static Node startNode;
        private static readonly string endNodeID = "end";
        private static Node endNode;


        public static int Part1(List<string> input)
        {
            int result = 0;
            var nodes = GetNodes(input);
            UpdateStartEndNodes(nodes);

            LookForPaths(startNode, endNode);

            return result;
        }

        private static void LookForPaths(Node startNode, Node endNode)
        {
            int paths = 0;
            Stack<Node> visited = new();
            visited.Push(startNode);

            foreach (var node in visited)
            {
                foreach (var target in node.Targets)
                {
                    if (target == endNode)
                    {
                        paths++;
                        continue;
                    }

                    if (target.MultiVisit && target.Visits < 2)
                    {
                        visited.Push(target);
                        target.Visits++;
                    }


                }

            }
        }

        public static long Part2(List<string> input)
        {

            int result = 0;


            return result;
        }

        public static List<Node> GetNodes(List<string> input)
        {
            List<Node> nodes = new();
            foreach (var row in input)
            {
                var data = row.Split('-');
                Node n1 = nodes.FirstOrDefault(n => n.ID == data[0]);
                Node n2 = nodes.FirstOrDefault(n => n.ID == data[1]);

                if (n1 == null)
                {
                    n1 = new Node() { ID = data[0], MultiVisit = Char.IsUpper(data[0][0]) ? true : false };
                    nodes.Add(n1);
                }
                if (n2 == null)
                {
                    n2 = new Node() { ID = data[1], MultiVisit = Char.IsUpper(data[1][0]) ? true : false };
                    nodes.Add(n2);
                }
                n1.Targets.Add(n2);
                n2.Targets.Add(n1);
            }
            return nodes;
        }

        private static void UpdateStartEndNodes(List<Node> nodes)
        {
            startNode = nodes.FirstOrDefault(n =>n.ID == startNodeID);
            endNode = nodes.FirstOrDefault(n =>n.ID == endNodeID);
        
        }

        public static List<Transistions> GetTransissions(List<string> input)
        {
            List<Transistions> output = new();
            foreach (var row in input)
            {
                var data = row.Split('-');

            }

            return output;
        }

        public class Node
        {
            public string ID { get; set; }
            public bool MultiVisit { get; set; }
            public int Visits { get; set; }
            public HashSet<Node> Targets { get; set; } = new HashSet<Node>();
        }

        public record Transistions
        {
            public string From { get; set; }
            public string To { get; set; }
        }



    }
}
