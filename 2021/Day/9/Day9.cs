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
    public static class Day9
    {

        public static int Part1(int[][] input)
        {
            var lowestPoints = GetLowestPoints(input);
            int result = 0;
            foreach (var point in lowestPoints)
            {
                result += input[point.Item1][point.Item2] + 1;
            }
            return result;
        }

        public static int Part2(int[][] input)
        {
            var lowestPoints = GetLowestPoints(input);
            List<int> basins = new();
            foreach (var cord in lowestPoints)
            {
                var point = GetPointFromCord(input, cord);
                var basin = GetBasinSize(input, point);
                basins.Add(basin);
            }
            basins.Sort();
            var t = basins.GetRange(basins.Count - 3, 3).ToList();
            return t.Aggregate((x, y) => x * y);
        }



        public static List<Tuple<int, int>> GetLowestPoints(int[][] input)
        {
            List<Tuple<int, int>> points = new();
            for (int x = 0; x < input[0].Length; x++)
            {
                for (int y = 0; y < input.Count(); y++)
                {
                    var cordValue = input[y][x];
                    bool hasUp = y > 0;
                    bool hasDown = y < (input.Count() - 1);
                    bool hasLeft = x > 0;
                    bool hasRight = x < input[0].Length - 1;


                    //X check
                    if (hasLeft && (cordValue >= input[y][x - 1]))
                        continue;
                    if (hasRight && (cordValue >= input[y][x + 1]))
                        continue;
                    //Y check
                    if (hasUp && (cordValue >= input[y - 1][x]))
                        continue;
                    if (hasDown && (cordValue >= input[y + 1][x]))
                        continue;

                    points.Add(new Tuple<int, int>(y, x));
                }
            }
            return points;
        }

        public static int GetBasinSize(int[][] input, Point lowPointInput)
        {
            List<Point> finalList = new() { lowPointInput };
            List<Point> lastList = new() { lowPointInput };
            bool done = false;
            while (done == false)
            {
                var newList = TraverseOutwards(input, lastList);
                newList.RemoveAll(p => p.Value == 9);
                newList.RemoveAll(p => finalList.Any(f => f.X == p.X && f.Y == p.Y));
                var v = newList.GroupBy(g => new { g.X, g.Y })
                         .Select(g => g.First())
                         .ToList();
                if (v.Count > 0)
                {
                    finalList.AddRange(v);
                    lastList = v;
                }
                else
                    done = true;
            };

            return finalList.Count();
        }

        private static List<Point> TraverseOutwards(int[][] input, List<Point> points)
        {
            List<Point> newPoints = new();
            foreach (var point in points)
            {
                if (newPoints.Any(p => p.X == point.X && p.Y == point.Y))
                    continue;

                if (point.HasLeft && point.LeftIsHigher == true)
                {
                    newPoints.Add(GetPointFromCord(input, new Tuple<int, int>(point.Y, point.X - 1)));
                }
                if (point.HasRight && point.RightIsHigher == true)
                {
                    newPoints.Add(GetPointFromCord(input, new Tuple<int, int>(point.Y, point.X + 1)));
                }
                if (point.HasUp && point.UpIsHigher == true)
                {
                    newPoints.Add(GetPointFromCord(input, new Tuple<int, int>(point.Y - 1, point.X)));
                }
                if (point.HasDown && point.DownIsHigher == true)
                {
                    newPoints.Add(GetPointFromCord(input, new Tuple<int, int>(point.Y + 1, point.X)));
                }
            }
            return newPoints;
        }

        public  static Point GetPointFromCord(int[][] grid, Tuple<int, int> cord)
        {
            Point point = new Point()
            {
                X = cord.Item2,
                Y = cord.Item1,
                Value = grid[cord.Item1][cord.Item2],
                HasUp = cord.Item1 > 0,
                HasDown = cord.Item1 < (grid.Count() - 1),
                HasLeft = cord.Item2 > 0,
                HasRight = cord.Item2 < grid[0].Length - 1
            };

            //X check
            if (point.HasLeft && (point.Value < grid[point.Y][point.X - 1]))
                point.LeftIsHigher = true;
            if (point.HasRight && (point.Value < grid[point.Y][point.X + 1]))
                point.RightIsHigher = true;
            //Y check
            if (point.HasUp && (point.Value < grid[point.Y - 1][point.X]))
                point.UpIsHigher = true;
            if (point.HasDown && (point.Value < grid[point.Y + 1][point.X]))
                point.DownIsHigher = true;


            return point;
        }

        public class Point
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Value { get; set; }
            public bool HasUp { get; set; }
            public bool UpIsHigher { get; set; }
            public bool HasDown { get; set; }
            public bool DownIsHigher { get; set; }
            public bool HasLeft { get; set; }
            public bool LeftIsHigher { get; set; }
            public bool HasRight { get; set; }
            public bool RightIsHigher { get; set; }

        }


    }
}
