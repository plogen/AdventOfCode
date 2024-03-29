﻿using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace aoc2022
{
    public static class Day08
    {

        public static int Part1(List<string> input)
        {
            byte[,] trees = GetTrees(input);
            return Part1NotSoNiceSolution(trees);
        }


        public static int Part2(List<string> input)
        {
            byte[,] trees = GetTrees(input);

            int width = trees.GetLength(0);
            int height = trees.GetLength(1);
            HashSet<int> result = new HashSet<int>();
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    int visableCount = 0;
                    visableCount += GetVisableTrees(trees, width, height, x, y, 0, -1).visableTrees; //North
                    visableCount *= GetVisableTrees(trees, width, height, x, y, 0, 1).visableTrees; //South
                    visableCount *= GetVisableTrees(trees, width, height, x, y, 1, 0).visableTrees; //East
                    visableCount *= GetVisableTrees(trees, width, height, x, y, -1, 0).visableTrees; //West
                    result.Add(visableCount);
                }
            }

            return result.Max();
        }




        private static int Part1NotSoNiceSolution(byte[,] trees)
        {
            int width = trees.GetLength(0);
            int height = trees.GetLength(1);
            int visableCount = 0;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (IsVisable(trees, width, height, x, y))
                        visableCount++;
                }
            }

            return visableCount;
        }

        private static byte[,] GetTrees(List<string> input)
        {
            int width = input[0].Length;
            int height = input.Count;
            byte[,] trees = new byte[width, height];

            for (int y = 0; y < height; y++)
            {
                var row = input[y];
                for (int x = 0; x < width; x++)
                {
                    trees[x, y] = (byte)(row[x] - '0');
                }
            }

            return trees;
        }


        private static (bool visable, int visableTrees) GetVisableTrees(byte[,] trees, int width, int heigh, int currentPosX, int currentPosY, int horizantalStepDir, int verticalStepDir)
        {
            var tree = trees[currentPosX, currentPosY];
            int visableTrees = 0;

            var x = currentPosX + horizantalStepDir;
            var y = currentPosY + verticalStepDir;
            while (x >= 0 && x < width && y >= 0 && y < heigh)
            {
                visableTrees++;
                if (tree <= trees[x, y])
                {
                    return (false, visableTrees);
                }
                x += horizantalStepDir;
                y += verticalStepDir;
            }
            return (true, visableTrees);
        }

        private static bool IsVisable(byte[,] trees, int width, int heigh, int x, int y)
        {
            if (x == 0 || x == width || y == 0 || y == heigh)
                return true;

            var tree = trees[x, y];

            //North
            bool visableNorth = true;
            for (int n = y - 1; n >= 0; n--)
            {
                if (trees[x, n] >= tree)
                    visableNorth = false;
            }

            //South
            bool visableSouth = true;
            for (int s = y + 1; s < heigh; s++)
            {
                if (trees[x, s] >= tree)
                    visableSouth = false;
            }

            //East
            bool visableEast = true;
            for (int w = x + 1; w < width; w++)
            {
                if (trees[w, y] >= tree)
                    visableEast = false;
            }

            //West
            bool visableWest = true;
            for (int w = x - 1; w >= 0; w--)
            {
                if (trees[w, y] >= tree)
                    visableWest = false;
            }


            return (visableNorth || visableSouth || visableEast || visableWest);
        }

    }
}
