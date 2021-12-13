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
    public static class Day11
    {

        public static int Part1(int[][] input)
        {
            int result = 0;
            var opctopuses = GetOctupuses(input);
            for (int i = 0; i < 100; i++)
            {
                result += OneFlashRound(opctopuses);
            }
            
            return result;
        }

        public static int Part2(int[][] input)
        {
            int result = 0;
            var opctopuses = GetOctupuses(input);
            while (opctopuses.Any(o => o.EnergyLevel != 0))
            {
                OneFlashRound(opctopuses);
                result++;
            }


            return result;
        }

        public static List<Octopus> GetOctupuses(int[][] input)
        {
            List<Octopus> opctopuses = new();

            for (int y = 0; y < input.Length; y++)
            {
                for (int x = 0; x < input[0].Length; x++)
                {
                    opctopuses.Add(new Octopus() { EnergyLevel = input[y][x], X = x, Y = y });
                }
            }
            return opctopuses;
        }

        public static int OneFlashRound(List<Octopus> opctopuses)
        {
            int flashes = 0;

            foreach (var octopus in opctopuses)
            {
                octopus.EnergyLevel++;
                octopus.HasFlashed = false;
            }

            bool stillToFlash = true;
            int lastFlashCount = -1;
            while (stillToFlash)
            {
                if (lastFlashCount == flashes)
                {
                    stillToFlash = false;
                    break;
                }                
                lastFlashCount = flashes;


                foreach (var octupus in opctopuses)
                {
                    if (octupus.HasFlashed)
                        continue;

                    if (octupus.EnergyLevel > 9)
                    {
                        octupus.EnergyLevel = 0;
                        octupus.HasFlashed = true;
                        flashes++;

                        for (int y = octupus.Y - 1; y <= octupus.Y + 1; y++)
                        {
                            for (int x = octupus.X - 1; x <= octupus.X + 1; x++)
                            {
                                var neighbour = opctopuses.FirstOrDefault(o => o.X == x && o.Y == y && o.HasFlashed == false);
                                if (neighbour != null && neighbour != octupus)
                                    neighbour.EnergyLevel++;
                            }
                        }
                    }
                }
                 
            }

            return flashes;
        
        }


        public class Octopus
        {
            public int EnergyLevel { get; set; }
            public bool HasFlashed { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
        }

    }
}
