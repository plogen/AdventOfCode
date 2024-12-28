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

            string data = "";
            for (int i = 0; i < word.Length; i++)
            {
                data += (char)map[x, y - i];
            }

            if (data == word)
                return true;

            return false;
        }
        public static bool NorthValid(int[,] map, int x, int y, string word)
        {
            if (y < word.Length - 1)
                return false;

            return true;
        }





        public static bool South(int[,] map, int x, int y, string word)
        {
            if (!SouthValid(map, x, y, word))
                return false;

            string data = "";
            for (int i = 0; i < word.Length; i++)
            {
                data += (char)map[x, y + i];
            }

            if (data == word)
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

            string data = "";
            for (int i = 0; i < word.Length; i++)
            {
                data += (char)map[x + i, y];
            }

            if (data == word)
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

            string data = "";
            for (int i = 0; i < word.Length; i++)
            {
                data += (char)map[x - i, y];
            }

            if (data == word)
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


            string data = "";
            for (int i = 0; i < word.Length; i++)
            {
                data += (char)map[x + i, y + i];
            }

            if (data == word)
                return true;

            return false;
        }

        public static bool NorthEast(int[,] map, int x, int y, string word)
        {
            if (!NorthValid(map, x, y, word))
                return false;

            if (!EastValid(map, x, y, word))
                return false;


            string data = "";
            for (int i = 0; i < word.Length; i++)
            {
                data += (char)map[x + i, y - i];
            }

            if (data == word)
                return true;

            return false;
        }


        public static bool NorthWest(int[,] map, int x, int y, string word)
        {
            if (!NorthValid(map, x, y, word))
                return false;

            if (!WestValid(map, x, y, word))
                return false;

            string data = "";
            for (int i = 0; i < word.Length; i++)
            {
                data += (char)map[x - i, y - i];
            }

            if (data == word)
                return true;

            return false;
        }

        public static bool SouthWest(int[,] map, int x, int y, string word)
        {
            if (!SouthValid(map, x, y, word))
                return false;

            if (!WestValid(map, x, y, word))
                return false;

            string data = "";
            for (int i = 0; i < word.Length; i++)
            {
                data += (char)map[x - i, y + i];
            }

            if (data == word)
                return true;

            return false;
        }


    }
}
