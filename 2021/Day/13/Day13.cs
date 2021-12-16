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
    public static class Day13
    {

        public static int Part1(List<string> input)
        {  
            var paper = GetPaper(input);
            FoldPaper(paper.Foldings.First(), paper);
            var finalDotsVisable = paper.Dots.Cast<int>().Where(val => val == 1).Count();
            return finalDotsVisable;
        }

        public static Paper Part2(List<string> input)
        {
            var paper = GetPaper(input);
            foreach (var fold in paper.Foldings)
            {
                FoldPaper(fold, paper);
            }
            return paper;
        }

        private static Paper GetPaper(List<string> input)
        {
            Paper paper = new Paper();
            List<Tuple<int, int>> dots = new List<Tuple<int, int>>();
            foreach (var row in input)
            {
                var cords = row.Split(',');
                if (cords.Length == 2)
                    dots.Add(new Tuple<int, int>(int.Parse(cords[0]), int.Parse(cords[1])));

                if (row.StartsWith("fold"))
                {
                    paper.Foldings.Add(new Folding()
                    { 
                        FoldAlong = row[11],
                        Index = int.Parse(row.Substring(13))
                    });
                }
            }
            
            var xMax = dots.Max(d => d.Item1) + 1;
            var yMax = dots.Max(d => d.Item2) + 1;

            paper.Dots = new int[xMax, yMax];

            foreach (var dot in dots)
            {
                paper.Dots[dot.Item1, dot.Item2] = 1;
            }

            return paper;
        }


        public static void FoldPaper(Folding folding, Paper paper)
        {
            var xSize = paper.Dots.GetLength(0);
            var ySize = paper.Dots.GetLength(1);

            if (folding.FoldAlong == 'y')
            {
                for (int y = folding.Index + 1; y < ySize; y++)
                {
                    for (int x = 0; x < xSize; x++)
                    {
                        if (paper.Dots[x, y] == 1)
                        {
                            paper.Dots[x, (ySize - 1) - y] = 1;
                        }
                    }
                }

                int[,] newDots = new int[xSize, folding.Index];
                for (int y = 0; y < folding.Index; y++)
                {
                    for (int x = 0; x < xSize; x++)
                    {
                        newDots[x, y] = paper.Dots[x, y];
                    }
                }

                paper.Dots = newDots;
            }

            else if (folding.FoldAlong == 'x')
            {
                for (int y = 0; y < ySize; y++)
                {
                    for (int x = 0; x < folding.Index; x++)
                    {
                        if (paper.Dots[x + folding.Index + 1, y] == 1)
                        {
                            paper.Dots[(folding.Index - x - 1), y] = 1;
                        }
                    }
                }

                int[,] newDots = new int[folding.Index, ySize];
                for (int y = 0; y < ySize; y++)
                {
                    for (int x = 0; x < folding.Index; x++)
                    {
                        newDots[x, y] = paper.Dots[x, y];
                    }
                }

                paper.Dots = newDots;
            }

            

        }

        public class Paper
        {
            public int[,] Dots { get; set; }
            public List<Folding> Foldings { get; set; } = new List<Folding>();
        }

        public class Folding
        {
            public char FoldAlong { get; set; }
            public int Index { get; set; }
        }
        
    }
}
