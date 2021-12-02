using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2021
{
    public static class Day2
    {
        public static int Part1(List<string> input)
        {
            int horizontal = 0;
            int depth = 0;

            foreach (var row in input)
            {
                var data = row.Split(' ');
                int value = int.Parse(data[1]);
                switch (data[0])
                {
                    case "forward":
                        horizontal += value;
                        break;
                    case "down":
                        depth += value;
                        break;
                    case "up":
                        depth -= value;
                        break;
                    default:
                        throw new Exception("parse error");
                }
            }
            return horizontal * depth;
        }

        public static int Part2(List<string> input)
        {
            int horizontal = 0;
            int depth = 0;
            int aim = 0;

            foreach (var row in input)
            {
                var data = row.Split(' ');
                int value = int.Parse(data[1]);
                switch (data[0])
                {
                    case "forward":
                        horizontal += value;
                        depth += (aim * value);
                        break;
                    case "down":
                        aim += value;
                        break;
                    case "up":
                        aim -= value;
                        break;
                    default:
                        throw new Exception("parse error");
                }
            }
            return horizontal * depth;
        }



    }
}
