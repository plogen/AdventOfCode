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

            return -1;
        }

        public static int Part2(List<string> inputs)
        {
            return -1;
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
