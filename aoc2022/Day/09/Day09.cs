using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace aoc2022
{
    public static class Day09
    {
        public static Regex cdRegex = new Regex(@"(.) (\d+)");

        public static int Part1(List<string> input)
        {
            var directions = GetDirections(input);
            return GetTailVisitedCount(directions);
        }


        public static int Part2(List<string> input)
        {
            return -1;
        }


        private static int GetTailVisitedCount(List<(int x, int y)> directions)
        { 


            HashSet<(int, int)> visited = new();
            (int x, int y) head = (0, 0);
            (int x, int y) tail = (0, 0);
            visited.Add(tail); //Starting point

            foreach (var move in directions)
            {
                //for (int x = 0; x != move.x; x++)
                //{
                //    for (int y = 0; y != move.y; y++)
                //    {

                //    }

                //}

                var oneSteppDir = Get1StepDir(move.x, move.y);
                int x = 0;
                int y = 0;
                while (x != move.x || y != move.y)
                {
                    x += oneSteppDir.x;
                    y += oneSteppDir.y;
                    head.x += oneSteppDir.x;
                    head.y += oneSteppDir.y;

                    if(IsCloseEnough(head, tail) == false)
                    {
                        var moveCloserDir = GetMoveCloserDirection(head, tail);
                        tail.x += moveCloserDir.x;
                        tail.y += moveCloserDir.y;
                        visited.Add(tail); //Starting point
                    }
                }
            }

            return visited.Count;
        
        }


        private static (int x, int y) GetMoveCloserDirection((int x, int y) head, (int x, int y) tail)
        {
            var x = 0;
            //TODO: Must be an easier way to do this...
            if (Helper.IsPositive(head.x - tail.x))
                x++;
            else if (Helper.IsNegative(head.x - tail.x))
                x--;

            var y = 0;
            //TODO: Must be an easier way to do this...
            if (Helper.IsPositive(head.y - tail.y))
                y++;
            else if (Helper.IsNegative(head.y - tail.y))
                y--;


            return (x,y);
        }

        private static bool IsCloseEnough((int x, int y) head, (int x, int y) tail)
        {
            if (Math.Abs(head.x - tail.x) > 1)
            {
                return false;
            }

            if (Math.Abs(head.y - tail.y) > 1)
            {
                return false;
            }

            return true; 
        }


        private static (int x, int y) Get1StepDir(int x, int y)
        {
            int returndeX = 0;
            int returndeY = 0;

            if (Helper.IsPositive(x))
                returndeX++;
            else if (Helper.IsNegative(x))
                returndeX--;

            if (Helper.IsPositive(y))
                returndeY++;
            else if (Helper.IsNegative(y))
                returndeY--;

            return (returndeX, returndeY);
        }

        private static List<(int x, int y)> GetDirections(List<string> input)
        {
            List<(int x, int y)> directions = new();
            foreach (var row in input)
            {
                var match = cdRegex.Match(row);
                int x = 0;
                int y = 0;
                switch (match.Groups[1].Value[0])
                {
                    case 'U':
                        y = -int.Parse(match.Groups[2].Value);
                        break;
                    case 'D':
                        y = int.Parse(match.Groups[2].Value);
                        break;
                    case 'L':
                        x = -int.Parse(match.Groups[2].Value);
                        break;
                    case 'R':
                        x = int.Parse(match.Groups[2].Value);
                        break;
                    default:
                        break;
                }
                directions.Add((x, y));
            }
            return directions;
        }



    }
}
