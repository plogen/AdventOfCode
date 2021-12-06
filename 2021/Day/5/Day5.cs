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
            var filteredLines = RemoveInvalidLines(lines, true);
            var grid = GetGrid(filteredLines);
            var count = CountAbove(grid, 2);
            return count;
        }

        public static int Part2(List<string> input)
        {
            //var lines = GetLines(input);
            //UpdateLineDirection(lines);
            //var filteredLines = RemoveInvalidLines(lines, false);
            //var grid = GetGrid(filteredLines);
            //var count = CountAbove(grid, 2);
            //return count;

            var lines = GetLines(input);
            UpdateLineDirection(lines);
            RemoveInvalidLinesV2(lines, false);
            var grid = GetGridV2(lines);
            var count = CountAbove(grid, 2);
            return count;
        }

        public static List<Line> RemoveInvalidLines(List<Line> input, bool removeDiagonal)
        {
            List<Line> output = new List<Line>();
            var horOrVertLines = input.Where(l => (l.Start.x == l.End.x) || (l.Start.y == l.End.y)).ToList();
            output.AddRange(horOrVertLines);
            var diagonalLines = input.Where(l => (l.Start.x - l.End.x) == (l.Start.y - l.End.y)).ToList();

            if (removeDiagonal == false)
            {
                output.AddRange(diagonalLines);
            }
            return output;
        }

        public static void RemoveInvalidLinesV2(List<Line> input, bool removeDiagonal)
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
                if (line.Start.x == line.End.x)
                {
                    if (line.Start.y <= line.End.y)
                    {
                        for (int y = line.Start.y; y <= line.End.y; y++)
                        {
                            grid[line.Start.x, y]++;
                        }
                    }

                    if (line.Start.y > line.End.y)
                    {
                        for (int y = line.End.y; y <= line.Start.y; y++)
                        {
                            grid[line.Start.x, y]++;
                        }
                    }
                }
                else if (line.Start.y == line.End.y)
                {
                    if (line.Start.x <= line.End.x)
                    {
                        for (int x = line.Start.x; x <= line.End.x; x++)
                        {
                            grid[x, line.Start.y]++;
                        }
                    }

                    if (line.Start.x > line.End.x)
                    {
                        for (int x = line.End.x; x <= line.Start.x; x++)
                        {
                            grid[x, line.Start.y]++;
                        }
                    }
                }
                else //Diagonal
                {
                    var stepps = Math.Abs(line.Start.x - line.End.x);

                    for (int i = 0; i < stepps; i++)
                    {
                        int x = 0;
                        int y = 0;
                        if (line.Start.x <= line.End.x)
                            x = line.Start.x + i;
                        else
                            x = line.End.x + i;

                        if (line.Start.y <= line.End.y)
                            y = line.Start.y + i;
                        else
                            y = line.End.y + i;

                        grid[x, y]++;
                    }

                }
            }
            return grid;
        }



        public static int[,] GetGridV2(List<Line> input)
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
                
                }

                if (line.Start.x == line.End.x)
                {
                    if (line.Start.y <= line.End.y)
                    {
                        for (int y = line.Start.y; y <= line.End.y; y++)
                        {
                            grid[line.Start.x, y]++;
                        }
                    }

                    if (line.Start.y > line.End.y)
                    {
                        for (int y = line.End.y; y <= line.Start.y; y++)
                        {
                            grid[line.Start.x, y]++;
                        }
                    }
                }
                else if (line.Start.y == line.End.y)
                {
                    if (line.Start.x <= line.End.x)
                    {
                        for (int x = line.Start.x; x <= line.End.x; x++)
                        {
                            grid[x, line.Start.y]++;
                        }
                    }

                    if (line.Start.x > line.End.x)
                    {
                        for (int x = line.End.x; x <= line.Start.x; x++)
                        {
                            grid[x, line.Start.y]++;
                        }
                    }
                }
                else //Diagonal
                {
                    var stepps = Math.Abs(line.Start.x - line.End.x);

                    for (int i = 0; i < stepps; i++)
                    {
                        int x = 0;
                        int y = 0;
                        if (line.Start.x <= line.End.x)
                            x = line.Start.x + i;
                        else
                            x = line.End.x + i;

                        if (line.Start.y <= line.End.y)
                            y = line.Start.y + i;
                        else
                            y = line.End.y + i;

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
                    line.Direction = Direction.Horizontal;
                    if (line.Start.y <= line.End.y)
                        line.yPos = true;
                }
                else if ((line.Start.y == line.End.y) && (line.Start.x != line.End.x))
                {
                    line.Direction = Direction.Vertical;
                    if (line.Start.x <= line.End.x)
                        line.xPos = true;
                }
                else {
                    int x, y = 0;
                    if (line.Start.y <= line.End.y)
                    {
                        y = line.End.y - line.Start.y;
                        line.yPos = true;
                    }
                    else
                        y = line.Start.y - line.End.y;


                    if (line.Start.x <= line.End.x)
                    {
                        x = line.End.x - line.Start.x;
                        line.xPos = true;
                    }
                    else
                        x = line.Start.x - line.End.x;
                    
                    if(x == y)
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
