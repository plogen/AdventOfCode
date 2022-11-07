using aoc2015.Day._09;
using Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static aoc2015.Day03;
using static aoc2015.Day07;

using Dijkstra.NET.Graph;
using Dijkstra.NET.ShortestPath;
using Dijkstra.NET.PageRank;
using System.Collections;

namespace aoc2015
{
    public static class Day09
    {

        public static Regex route = new Regex(@"([a-zA-Z]+) to ([a-zA-Z]+) = (\d+)");

        public static int Part1(List<string> inputs)
        {

            var routes = new HashSet<Route>();
            foreach (var input in inputs)
            {
                routes.Add(GetRoute(input));
            }




            //var townSet = new HashSet<string>();
            //var distances = new Dictionary<(string source, string destination), int>();

            //foreach (var route in routes)
            //{
            //    townSet.Add(route.Source);
            //    townSet.Add(route.Destination);
            //    distances[(route.Source, route.Destination)] = route.Distance;
            //    distances[(route.Destination, route.Source)] = route.Distance;
            //}

            //// convert adjacency list to adjacency matrix
            //string[] townNames = townSet.ToArray();
            //int numTowns = townNames.Length;

            //int[,] adjMatrix = new int[numTowns, numTowns];
            //int[] towns = new int[numTowns];
            //for (int a = 0; a < numTowns; a++)
            //{
            //    towns[a] = a;
            //    for (int b = 0; b < numTowns; b++)
            //    {
            //        if (a != b)
            //        {
            //            adjMatrix[a, b] = distances[(townNames[a], townNames[b])];
            //        }
            //    }
            //}


            //int minDistance = int.MaxValue;
            //int maxDistance = int.MinValue;
            //foreach (Span<int> perm in towns.AsSpan().GetPermutations())
            //{
            //    int pathDist = 0;
            //    int prevTown = perm[0];
            //    for (int j = 1; j < numTowns; j++)
            //    {
            //        int town = perm[j];
            //        pathDist += adjMatrix[prevTown, town];
            //        prevTown = town;
            //    }

            //    minDistance = Math.Min(minDistance, pathDist);
            //    maxDistance = Math.Max(maxDistance, pathDist);
            //}

            //var Part1Aswer = minDistance;
            //var Part2Aswer = maxDistance;






            //var graph = new Graph<string, string>();
            //foreach (var route in routes) {
            //    if (dic.ContainsKey(route.Source) == false)
            //    {
            //        uint a = graph.AddNode(route.Source);
            //        dic.Add(route.Source, a);
            //    }
            //    if (dic.ContainsKey(route.Destination) == false)
            //    {
            //        uint b = graph.AddNode(route.Destination);
            //        dic.Add(route.Destination, b);
            //    }
            //    graph.Connect(dic[route.Source], dic[route.Destination], route.Distance, $"{route.Source}>>{route.Destination}"); //First node has key equal 1
            //}
            //var result = graph.Dijkstra(dic["London"], dic["Belfast"]);
            //uint[] path = result.GetPath().ToArray();


            return -1;
        }


        public static int Part2(List<string> inputs)
        {
            return -1;
        }

        public class Route
        {
            public string Source { get; set; }
            public string Destination { get; set; }
            public int Distance { get; set; }
        }
        public static Route GetRoute(string input)
        {
            var match = route.Matches(input);
            return
                new Route()
                {
                    Source = match[0].Groups[1].Value,
                    Destination = match[0].Groups[2].Value,
                    Distance = int.Parse(match[0].Groups[3].Value)
                };
        }



    }
}
