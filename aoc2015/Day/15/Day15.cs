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
using static aoc2015.Day09;
using MoreLinq;

namespace aoc2015
{
    public static class Day15
    {

        public static Regex reindeerRegex = new Regex(@"(\w+): capacity (-?\d+), durability (-?\d+), flavor (-?\d+), texture (-?\d+), calories (-?\d+)");

        public static int Part1(List<string> inputs)
        {
            var ingridients = GetIngredients(inputs);
            var permutations = Algorithms.GetPermutations(ingridients, ingridients.Count);

            // var dist = GetDistribution4(100);
            var dist = GetDistribution2(100);

            var ttt = GetScore(new int[] { 44, 56 }, ingridients);

            var points = new Hashtable();
            var points2 = new List<int>();
            foreach (var d in dist)
            {
                //points.Add(d, GetScore(d, ingridients));
                points2.Add(GetScore(d, ingridients));
            }

            return points2.Max();
        }

        public static int Part2(List<string> inputs)
        {
            return -1;
        }

        private static int GetScore(int[] dist, List<Ingredient> ingredients)
        {
            var temp = new Ingredient();
            for (int i = 0; i < ingredients.Count; i++)
            {
                temp.Capacity += ingredients[i].Capacity * dist[i];
                temp.Durability += ingredients[i].Durability * dist[i];
                temp.Flavor += ingredients[i].Flavor * dist[i];
                temp.Texture += ingredients[i].Texture * dist[i];
            }

            return temp.Capacity * temp.Durability * temp.Flavor * temp.Texture;
        }

        private static IEnumerable<int[]> GetDistribution4(int max)
        {
            List<int[]> distributions = new List<int[]>();

            for (int a = 0; a < max; a++)
            {
                for (int b = 0; b < max; b++)
                {
                    for (int c = 0; c < max; c++)
                    {
                        for (int d = 0; d < max; d++)
                        {
                            distributions.Add(new int[] { a, b, c, d });
                        }
                    }
                }
            }
            return distributions;
        }

        private static IEnumerable<int[]> GetDistribution2(int max)
        {
            List<int[]> distributions = new List<int[]>();

            for (int a = 0; a <= max; a++)
            {
                for (int b = max; b <= max - a; b++)
                {
                    distributions.Add(new int[] { a, b });
                }
            }
            return distributions;
        }


        public static IEnumerable<List<T>> Partition<T>(this IList<T> source, Int32 size)
        {
            for (int i = 0; i < Math.Ceiling(source.Count / (Double)size); i++)
                yield return new List<T>(source.Skip(size * i).Take(size));
        }


        private static List<Ingredient> GetIngredients(List<string> inputs)
        {
            var ingridients = new List<Ingredient>();

            inputs.ForEach(x =>
            {
                var match = reindeerRegex.Match(x);
                ingridients.Add(new Ingredient
                {
                    Name = match.Groups[1].Value,
                    Capacity = int.Parse(match.Groups[2].Value),
                    Durability = int.Parse(match.Groups[3].Value),
                    Flavor = int.Parse(match.Groups[4].Value),
                    Texture = int.Parse(match.Groups[5].Value),
                    Calories = int.Parse(match.Groups[6].Value)
                });
            });

            return ingridients;
        }

        public class Ingredient
        {
            public string Name { get; set; }
            public int Capacity { get; set; }
            public int Durability { get; set; }
            public int Flavor { get; set; }
            public int Texture { get; set; }
            public int Calories { get; set; }
        }


    }
}
