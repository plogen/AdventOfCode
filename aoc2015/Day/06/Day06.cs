using Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static aoc2015.Day03;

namespace aoc2015
{
    public static class Day06
    {
        public enum Mode { 
            OnOff,
            Brightness
        };

        public static Regex regex = new Regex("([a-zA-Z\\s]+)(\\d+),(\\d+)");
        public static int Part1(List<string> inputs)
        {
            var grid = GetGrid(inputs, Mode.OnOff);
            return GetIntensisty(grid);
        }

        private static int[,] GetGrid(List<string> inputs, Mode mode)
        {
            int[,] grid = new int[1000, 1000];

            foreach (var input in inputs)
            {
                var match = regex.Matches(input);

                var startPoint = new Point(
                        int.Parse(match[0].Groups[2].Value),
                        int.Parse(match[0].Groups[3].Value)
                    );
                var endPoint = new Point(
                        int.Parse(match[1].Groups[2].Value),
                        int.Parse(match[1].Groups[3].Value)
                    );

                for (int x = startPoint.X; x <= endPoint.X; x++)
                {
                    for (int y = startPoint.Y; y <= endPoint.Y; y++)
                    {
                        var command = match[0].Groups[1].Value;

                        if (command == "turn on ")
                        {
                            if (mode == Mode.OnOff)
                                grid[x, y] = 1;
                            else if (mode == Mode.Brightness)
                                grid[x, y]++;

                        }
                        else if (command == "turn off ")
                        {
                            if (mode == Mode.OnOff)
                                grid[x, y] = 0;
                            else if (mode == Mode.Brightness && grid[x, y] > 0)
                                grid[x, y]--;
                        }
                        else if (command == "toggle ")
                        {
                            if (mode == Mode.OnOff)
                                grid[x, y] = grid[x, y] == 0 ? 1 : 0;
                            else if (mode == Mode.Brightness)
                                grid[x, y] = grid[x, y] + 2;
                        }

                    }
                }
            }

            return grid;
        }

        private static int GetIntensisty(int[,] grid)
        {
            int litLights = 0;
            for (int x = 0; x < 1000; x++)
            {
                for (int y = 0; y < 1000; y++)
                {
                    litLights += grid[x, y];
                }
            }

            return litLights;
        }

        public static int Part2(List<string> inputs)
        {
            var grid = GetGrid(inputs, Mode.Brightness);
            return GetIntensisty(grid);
        }

        public class LightAction
        { 
            
        }


    }
}
