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
            UpdateLineDirection(lines);
            RemoveInvalidLines(lines, true);
            var grid = GetGrid(lines);
            var count = CountAbove(grid, 2);
            return count;
        }

        public static int Part2(List<string> input)
        {
            var lines = GetLines(input);
            UpdateLineDirection(lines);
            RemoveInvalidLines(lines, false);
            var grid = GetGrid(lines);
            var count = CountAbove(grid, 2);
            return count;
        }


        public static void RemoveInvalidLines(List<Line> input, bool removeDiagonal)
        {
            input.RemoveAll(l => l.Direction == Direction.Unknown);
            if(removeDiagonal)
                input.RemoveAll(l => l.Direction == Direction.Diagonal);
        }

        public static int CountAbove(int[,] grid, int value)
        {
            int count = 0;

            int yCount = grid.GetLength(0),
                xCount = grid.GetLength(1);
            for (int yIndex = 0; yIndex < yCount; yIndex++)
            {
                for (int xIndex = 0; xIndex < xCount; xIndex++)
                {
                    if (grid[yIndex, xIndex] >= value)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public static int[,] GetGrid(List<Line> input)
        {
            var xStartMax = input.MaxBy(l => l.Start.x).Start.x;
            var yStartMax = input.MaxBy(l => l.Start.y).Start.y;
            var xEndMax = input.MaxBy(l => l.End.x).End.x;
            var yEndMax = input.MaxBy(l => l.End.y).End.y;

            var xMax = Math.Max(xStartMax, xEndMax) + 1;
            var yMax = Math.Max(yStartMax, yEndMax) + 1;

            int[,] grid = new int[xMax, yMax];

            foreach (var line in input)
            {
                if (line.Direction == Direction.Horizontal)
                {
                    if (line.xPos)
                    {
                        for (int x = line.Start.x; x <= line.End.x; x++)
                        {
                            grid[x, line.Start.y]++;
                        }
                    }
                    else
                    {
                        for (int x = line.Start.x; x >= line.End.x; x--)
                        {
                            grid[x, line.Start.y]++;
                        }
                    }
                }

                if (line.Direction == Direction.Vertical)
                {
                    if (line.yPos)
                    {
                        for (int y = line.Start.y; y <= line.End.y; y++)
                        {
                            grid[line.Start.x, y]++;
                        }
                    }
                    else
                    {
                        for (int y = line.Start.y; y >= line.End.y; y--)
                        {
                            grid[line.Start.x, y]++;
                        }
                    }
                }

                if (line.Direction == Direction.Diagonal)
                {
                    int stepps = 0;
                    if(line.xPos)
                        stepps = line.End.x - line.Start.x;
                    else
                        stepps = line.Start.x - line.End.x;

                    for (int i = 0; i < stepps; i++)
                    {
                        int x = 0;
                        int y = 0;
                        if (line.xPos)
                            x = line.Start.x + i;
                        else
                            x = line.Start.x - i;

                        if (line.yPos)
                            y = line.Start.y + i;
                        else
                            y = line.Start.y - i;

                        grid[x, y]++;
                    }
                }
            }
            return grid;
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

        public static void UpdateLineDirection(List<Line> lines)
        {
            foreach (var line in lines)
            {
                if ((line.Start.x == line.End.x) && (line.Start.y != line.End.y))
                {
                    line.Direction = Direction.Vertical;
                    if (line.Start.y <= line.End.y)
                        line.yPos = true;
                }
                else if ((line.Start.y == line.End.y) && (line.Start.x != line.End.x))
                {
                    line.Direction = Direction.Horizontal;
                    if (line.Start.x <= line.End.x)
                        line.xPos = true;
                }
                else {
                    if (line.Start.y <= line.End.y)
                    {
                        line.yPos = true;
                    }

                    if (line.Start.x <= line.End.x)
                    {
                        line.xPos = true;
                    }

                    line.Direction = Direction.Diagonal;
                }
            }
        }


        public class Line
        {
            public Point Start { get; set; }
            public Point End { get; set; }
            public Direction Direction { get; set; }
            public bool xPos { get; set; }
            public bool yPos { get; set; }

        }

        public class Point
        {
            public int x { get; set; }
            public int y { get; set; }
        }

        public enum Direction
        { 
            Unknown,
            Horizontal,
            Vertical,
            Diagonal
        }

    }
}
