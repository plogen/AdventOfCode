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
    public static class Day6
    {
        public static ulong Part1(List<int> input, int days)
        {
            List<Fish> fishes = CreateFishes(input);
            for (int i = 0; i < days; i++)
            {
                OneDayPassed(fishes);

            }
            return (ulong)fishes.Count;
        }


        public static ulong Part2(List<int> input, int days)
        {
            return GroupedFishes(input, days);
        }


        #region New Solution

        private static ulong GroupedFishes(List<int> input, int days)
        {
            var source = new ulong[9]; // 9 different intervalls exists
            var destination = new ulong[9]; 
            //Create initial fishes in groups
            foreach (var fish in input)
            {
                source[fish]++;
            }

            for (int day = 0; day < days; day++)
            {
                ulong cached0value = 0;
                if (day % 2 == 0)
                {
                    cached0value = source[0];
                    Array.Copy(source, 1, destination, 0, source.Length - 1);
                    destination[6] = destination[6] + cached0value;
                    destination[8] = cached0value;
                }
                else
                {
                    cached0value = destination[0];
                    Array.Copy(destination, 1, source, 0, destination.Length - 1);
                    source[6] = source[6] + cached0value;
                    source[8] = cached0value;
                }
            }
            if(days%2 == 0)
                return source.Aggregate((a, c) => a + c);
            else
                return destination.Aggregate((a, c) => a + c);

        }

        #endregion

        #region Part1, works with small amount if itterations
        private static List<Fish> CreateFishes(List<int> input)
        {
            return input.Select(f => new Fish() { InternalTimer = f }).ToList();
        }

        private static void OneDayPassed(List<Fish> fishes)
        {
            var initialCount = fishes.Count;
            for (int i = 0; i < initialCount; i++)
            {
                if (fishes[i].InternalTimer == 0)
                {
                    fishes.Add(new Fish());
                    fishes[i].InternalTimer = 6;
                }
                else
                {
                    fishes[i].InternalTimer--;
                }

            }
        }

        public class Fish
        {
            public int InternalTimer { get; set; } = 8;
        }

        #endregion

    }
}
