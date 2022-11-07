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
using System.Collections;

namespace aoc2015
{
    public static class Day09
    {

        public static Regex route = new Regex(@"([a-zA-Z]+) to ([a-zA-Z]+) = (\d+)");

        public static int Part1(List<string> inputs)
        {
            IEnumerable<int> costs = GetDistances(inputs);
            return costs.Min();
        }

        public static int Part2(List<string> inputs)
        {
            IEnumerable<int> costs = GetDistances(inputs);
            return costs.Max();
        }

        private static IEnumerable<int> GetDistances(List<string> inputs)
        {
            var routes = new HashSet<Route>();
            foreach (var input in inputs)
            {
                var r = GetRoute(input);
                routes.Add(r);
                routes.Add(GetRevertedRoute(r));
            }

            var cities = new HashSet<string>();
            foreach (var route in routes)
            {
                cities.Add(route.Source);
                cities.Add(route.Destination);
            }


            var permutations = GetPermutations(cities, cities.Count);
            var costs = permutations.Select(p =>
                            p.Zip(p.Skip(1), (source, destination) => //Get Pairwise
                            routes.First(r => r.Source == source && r.Destination == destination).Distance)
                            .Sum());
            return costs;
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

        public static Route GetRevertedRoute(Route route)
        {
            return
                new Route()
                {
                    Source = route.Destination,
                    Destination = route.Source,
                    Distance = route.Distance
                };
        }


        //https://stackoverflow.com/questions/756055/listing-all-permutations-of-a-string-integer
        static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }

    }
}
