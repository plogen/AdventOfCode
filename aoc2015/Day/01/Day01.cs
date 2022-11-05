using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2015
{
    public static class Day01
    {
        public static int Part1(string input)
        {
            int floor = 0;
            foreach (var c in input)
            {
                if(c == '(')
                    floor++;
                else if(c == ')')
                    floor--;
            }
            return floor;
        }

        public static int Part2(string input)
        {
            int floor = 0;
            int index = 1;
            foreach (var c in input)
            {
                if (c == '(')
                    floor++;
                else if (c == ')')
                    floor--;

                if (floor == -1)
                    return index;

                index++;
            }
            return 0;
        }



    }
}
