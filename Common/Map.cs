using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class Map
    {
        public static bool North(int[,] map, int x, int y, string word)
        {
            if (!NorthValid(map, x, y, word))
                return false;

            var s = $"{(char)map[x, y]}{(char)map[x, y - 1]}{(char)map[x, y - 2]}{(char)map[x, y - 3]}";

            if (s == word)
                return true;

            return false;
        }
        public static bool NorthValid(int[,] map, int x, int y, string word)
        {
            if (y < 3)
                return false;

            return true;
        }





        public static bool South(int[,] map, int x, int y, string word)
        {
            if (!SouthValid(map, x, y, word))
                return false;

            var s = $"{(char)map[x, y]}{(char)map[x, y + 1]}{(char)map[x, y + 2]}{(char)map[x, y + 3]}";

            if (s == word)
                return true;

            return false;
        }

        public static bool SouthValid(int[,] map, int x, int y, string word)
        {
            var ySize = map.GetLength(1);
            if (y > ySize - word.Length)
                return false;

            return true;
        }





        public static bool East(int[,] map, int x, int y, string word)
        {
            if (!EastValid(map, x, y, word))
                return false;

            var s = $"{(char)map[x, y]}{(char)map[x + 1, y]}{(char)map[x + 2, y]}{(char)map[x + 3, y]}";

            if (s == word)
                return true;

            return false;
        }
        public static bool EastValid(int[,] map, int x, int y, string word)
        {
            var xSize = map.GetLength(0);
            if (x > xSize - word.Length)
                return false;

            return true;
        }






        public static bool West(int[,] map, int x, int y, string word)
        {
            if (!WestValid(map, x, y, word))
                return false;

            var s = $"{(char)map[x, y]}{(char)map[x - 1, y]}{(char)map[x - 2, y]}{(char)map[x - 3, y]}";

            if (s == word)
                return true;

            return false;
        }
        public static bool WestValid(int[,] map, int x, int y, string word)
        {
            if (x < word.Length - 1)
                return false;

            return true;
        }





        public static bool SouthEast(int[,] map, int x, int y, string word)
        {
            if (!SouthValid(map, x, y, word))
                return false;

            if (!Map.EastValid(map, x, y, word))
                return false;

            var s = $"{(char)map[x, y]}{(char)map[x + 1, y + 1]}{(char)map[x + 2, y + 2]}{(char)map[x + 3, y + 3]}";

            if (s == word)
                return true;

            return false;
        }

        public static bool NorthEast(int[,] map, int x, int y, string word)
        {
            if (!NorthValid(map, x, y, word))
                return false;

            if (!EastValid(map, x, y, word))
                return false;

            var s = $"{(char)map[x, y]}{(char)map[x + 1, y - 1]}{(char)map[x + 2, y - 2]}{(char)map[x + 3, y - 3]}";

            if (s == word)
                return true;

            return false;
        }


        public static bool NorthWest(int[,] map, int x, int y, string word)
        {
            if (!NorthValid(map, x, y, word))
                return false;

            if (!WestValid(map, x, y, word))
                return false;

            var s = $"{(char)map[x, y]}{(char)map[x - 1, y - 1]}{(char)map[x - 2, y - 2]}{(char)map[x - 3, y - 3]}";

            if (s == word)
                return true;

            return false;
        }

        public static bool SouthWest(int[,] map, int x, int y, string word)
        {
            if (!SouthValid(map, x, y, word))
                return false;

            if (!WestValid(map, x, y, word))
                return false;

            var s = $"{(char)map[x, y]}{(char)map[x - 1, y + 1]}{(char)map[x - 2, y + 2]}{(char)map[x - 3, y + 3]}";

            if (s == word)
                return true;

            return false;
        }


    }
}
