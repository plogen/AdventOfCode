using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2020.Day3
{
    public static class Trajectory
    {

        public static List<string> GetInput()
        {
            List<string> rows = new List<string>();
            string lineData;

            using (var sr = new StreamReader("./Day3/input.txt"))
            {
                while ((lineData = sr.ReadLine()) != null)
                    rows.Add(lineData);
            }
            return rows;
        }

        public static int GetCrashes(List<string> input, Slope slope)
        {
            int trees = 0;
            int mapWidth = input[0].Length;
            int mapHight = input.Count;
            int y = 0;
            int x = 0;

            while (y < (mapHight - 1))
            {
                y += slope.Y;
                x += slope.X;
                if (x >= mapWidth)
                    x = x - mapWidth;

                if (input[y][x] == '#')
                    trees++;
            }

            return trees;
        }

        public static long GetMultiSlopeCrashes(List<string> input, List<Slope> slopes)
        {
            long answer = 1L;
            foreach (var slope in slopes)
            {
                answer = answer * GetCrashes(input, slope);
            }
            
            return answer;
        }

        public class Slope
        {
            public int X { get; set; }
            public int Y { get; set; }
        }

    }
}
