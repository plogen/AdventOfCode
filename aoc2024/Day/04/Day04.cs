using Common;

//Puzzle: https://adventofcode.com/2024/day/4
namespace aoc2024;
public class Day04 : DayPuzzle
{
    private const string xmas = "XMAS";

    public override object Part1(List<string> input)
    {
        var map = GetMap(input);

        var count = CountXmasFromMap(map);

        return count;
    }

    public override object Part2(List<string> input)
    {
        var map = GetMap(input);

        var count = CountStarMasFromMap(map);

        return count;
    }


    private int CountStarMasFromMap(int[,] map)
    {
        int count = 0;
        int masCount = 0;

        var xSize = map.GetLength(0);
        var ySize = map.GetLength(1);
        char A = 'A';

        for (int y = 0; y < ySize; y++)
        {
            for (int x = 0; x < xSize; x++)
            {
                if (map[x, y] == A)
                {
                    masCount = 0;

                    if (Map.NorthWest(map, x, y, "AM") &&
                        Map.SouthEast(map, x, y, "AS")
                        ||
                        Map.NorthWest(map, x, y, "AS") &&
                        Map.SouthEast(map, x, y, "AM")
                        )
                    { masCount++; }


                    if (Map.NorthEast(map, x, y, "AM") &&
                        Map.SouthWest(map, x, y, "AS")
                        ||
                        Map.NorthEast(map, x, y, "AS") &&
                        Map.SouthWest(map, x, y, "AM")
                        )
                    { masCount++; }


                    if (masCount == 2)
                        count++;
                }
            }
        }

        return count;
    }


    private int CountXmasFromMap(int[,] map)
    {
        int count = 0;

        var xSize = map.GetLength(0);
        var ySize = map.GetLength(1);
        char X = 'X';

        for (int y = 0; y < ySize; y++)
        {
            for (int x = 0; x < xSize; x++)
            {
                if (map[x, y] == X)
                {
                    if (Map.North(map, x, y, xmas))
                        count++;
                    if (Map.NorthEast(map, x, y, xmas))
                        count++;
                    if (Map.NorthWest(map, x, y, xmas))
                        count++;
                    if (Map.South(map, x, y, xmas))
                        count++;
                    if (Map.SouthEast(map, x, y, xmas))
                        count++;
                    if (Map.SouthWest(map, x, y, xmas))
                        count++;
                    if (Map.East(map, x, y, xmas))
                        count++;
                    if (Map.West(map, x, y, xmas))
                        count++;
                }
            }
        }

        return count;

    }



    private int[,] GetMap(List<string> input)
    {
        int xLenght = input.First().Length;
        int yLenght = input.Count;

        int[,] map = new int[xLenght, yLenght];

        for (int x = 0; x < xLenght; x++)
        {
            for (int y = 0; y < yLenght; y++)
            {
                map[x, y] = input[y][x];
            }
        }

        return map;
    }

}