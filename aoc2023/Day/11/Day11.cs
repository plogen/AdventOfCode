using Common;

//Puzzle: https://adventofcode.com/2023/day/11
namespace aoc2023
{
    public class Day11: DayPuzzle
    {
        public override object Part1(List<string> input)
        {
            var xCount = input.First().Length;
            var yCount = input.Count;
            int[,] map = new int[xCount, yCount];

            List<Galaxy> galaxies = GetGalaxies(input, xCount, yCount);
            List<int> emptyRows = GetEmtyRows(input, yCount);
            List<int> emptyCols = GetEmpyCols(input, xCount);

            return GetTotalDistances(galaxies, 1, emptyRows, emptyCols);
        }

        public override object Part2(List<string> input)
        {
            var xCount = input.First().Length;
            var yCount = input.Count;
            int[,] map = new int[xCount, yCount];

            List<Galaxy> galaxies = GetGalaxies(input, xCount, yCount);
            List<int> emptyRows = GetEmtyRows(input, yCount);
            List<int> emptyCols = GetEmpyCols(input, xCount);

            return GetTotalDistances(galaxies, 1, emptyRows, emptyCols);
        }

        private static List<Galaxy> GetGalaxies(List<string> input, int xCount, int yCount)
        {
            List<Galaxy> galaxys = new();
            int galaxyCount = 0;
            for (int y = 0; y < yCount; y++)
            {
                for (int x = 0; x < xCount; x++)
                {
                    if (input[y][x] == '#')
                    {
                        galaxyCount++;
                        galaxys.Add(new Galaxy()
                        {
                            ID = galaxyCount,
                            X = x,
                            Y = y,
                        });
                    }
                }
            }

            return galaxys;
        }

        private static long GetTotalDistances(List<Galaxy> galaxies, long expantionRate, List<int> emptyRows, List<int> emptyCols)
        {
            var galaxyPairs = galaxies.SelectMany((value, index) => galaxies.Skip(index + 1),
                       (first, second) => new { first, second });

            long totalDistances = 0;
            foreach (var galaxyPair in galaxyPairs)
            {
                var xDist = Math.Abs(galaxyPair.first.X - galaxyPair.second.X);
                var yDist = Math.Abs(galaxyPair.first.Y - galaxyPair.second.Y);
                var exp = Expantion(emptyRows, emptyCols, galaxyPair.first, galaxyPair.second);
                totalDistances += xDist;
                totalDistances += yDist;
                totalDistances += exp.xExp * expantionRate;
                totalDistances += exp.yExp * expantionRate;
            }
            return totalDistances;
        }


        private static List<int> GetEmpyCols(List<string> input, int xCount)
        {
            List<int> emptyCols = new List<int>();
            for (int x = 0; x < xCount; x++)
            {
                if (input.All(c => c[x] == '.'))
                {
                    emptyCols.Add(x);
                }
            }

            return emptyCols;
        }

        private static List<int> GetEmtyRows(List<string> input, int yCount)
        {
            List<int> emptyRows = new List<int>();
            for (int y = 0; y < yCount; y++)
            {
                if (input[y].All(c => c == '.'))
                {
                    emptyRows.Add(y);
                }
            }

            return emptyRows;
        }



        private static (int xExp, int yExp) Expantion(List<int> emptyRows, List<int> emptyCols, Galaxy a, Galaxy b)
        {
            var xExp = 0;
            if (a.X < b.X)
                xExp = emptyCols.Where(e => e > a.X && e < b.X).Count();
            else
                xExp = emptyCols.Where(e => e < a.X && e > b.X).Count();

            var yExp = 0;
            if (a.Y < b.Y)
                yExp = emptyRows.Where(e => e > a.Y && e < b.Y).Count();
            else
                yExp = emptyRows.Where(e => e < a.Y && e > b.Y).Count();

            return (xExp, yExp);
        }


        private class Galaxy
        {
            public int ID { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
        }


    }
}