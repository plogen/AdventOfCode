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
    public static class Day5
    {
        public static int Part1(List<string> input)
        {
            var lines = GetLines(input);

            return 0;
        }

        public static int Part2(List<string> input)
        {
            return 0;
        }

        public static List<int> DrawLinesOnGrid(List<Line> input)
        {
            var xStartMax = input.MaxBy(l => l.Start.x).Start.x;
            var yStartMax = input.MaxBy(l => l.Start.y).Start.y;
            var xEndMax = input.MaxBy(l => l.End.x).End.x;
            var yEndMax = input.MaxBy(l => l.End.y).End.y;

            var xMax = Math.Max(xStartMax, xEndMax);
            var yMax = Math.Max(yStartMax, yEndMax);

            int[][] grid = new int[xMax][xxx];

            foreach (var line in input)
            {
                if (line.Start.x == line.End.x)
                {
                    if (line.Start.y <= line.End.y)
                    {
                        for (int i = line.Start.y; i <= line.Start.x; i++)
                        {

                        }
                    }


                }
                else if (line.Start.y == line.End.y)
                { 
                
                }
            }
            return lines;
        }


        public static List<Line> GetLines(List<string> input)
        {
            List<Line> lines = new();
            foreach (var row in input)
            {
                Match match = Regex.Match(row,
                    @"(\d+)[,](\d+) -> (\d+)[,](\d+)");
                if (match.Success)
                {
                    lines.Add(new Line()
                    {
                        Start = new Point() { 
                            x = int.Parse(match.Groups[1].Value),
                            y = int.Parse(match.Groups[2].Value)
                        },
                        End = new Point()
                        {
                            x = int.Parse(match.Groups[3].Value),
                            y = int.Parse(match.Groups[4].Value)
                        }
                    });
                }

            }
            return lines;
        }


        public class Line
        {
            public Point Start { get; set; }
            public Point End { get; set; }
        }

        public class Point
        {
            public int x { get; set; }
            public int y { get; set; }
        }

    }
}
