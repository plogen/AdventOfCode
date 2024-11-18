using Common;

//Puzzle: https://adventofcode.com/2023/day/13
namespace aoc2023
{
    public class Day13 : DayPuzzle
    {
        public override object Part1(List<string> input)
        {
            List<List<string>> mirrors = new();
            List<string> mirror = new();
            foreach (var row in input) {
                if (string.IsNullOrEmpty(row))
                {
                    mirrors.Add(mirror);
                    mirror = new();
                }
                else
                {
                    mirror.Add(row);
                }
            }
            mirrors.Add(mirror);

            int result = 0;

            for (int i = 0; i < mirrors.Count; i++)
            {
                var verticleLines = GetVerticleLines(mirrors[i]);
                var verticleMirrorIndex = GetMirrorIndex(verticleLines);

                var horizontalLines = mirrors[i];
                var horizontalMirrorIndex = GetMirrorIndex(horizontalLines);

                

                result += (verticleMirrorIndex+1) + ((horizontalMirrorIndex+1) * 100);
            }

            return result;
        }

        public override object Part2(List<string> input)
        {
            throw new NotImplementedException();
        }


        private static int GetMirrorIndex(List<string> input)
        {
            for (int i = 0; i < input.Count-1; i++)
            {
                if (input[i] == input[i+1])
                    return i;
            }
            return -1;
        }


        private static List<string> GetVerticleLines(List<string> input)
        {
            var xCount = input.First().Length;
            var yCount = input.Count;
            List<string> verticleLines = new();

            for (int x = 0; x < xCount; x++)
            {
                var d = string.Concat(input.Select(c => c[x]));
                verticleLines.Add(d);
            }

            return verticleLines;
        }



        private static int GetVerticleLine(int[,] map)
        {
            int verticle = -1;

            var xCount = map.GetLength(0);
            var yCount = map.GetLength(1);
            for (int y = 0; y < yCount; y++)
            {
                for (int x = 0; x < xCount-1; x++)
                {
                    if (map[x, y] != map[x + 1, y])
                        break;
                        
                }
            }

            return verticle;
        }


        private static int[,] GetMap(List<string> input)
        {
            var xCount = input.First().Length;
            var yCount = input.Count;
            int[,] map = new int[xCount, yCount];

            for (int y = 0; y < yCount; y++)
            {
                for (int x = 0; x < xCount; x++)
                {
                    if (input[y][x] == '#')
                        map[x, y] = 1;
                    else
                        map[x, y] = 0;
                }
            }

            return map;
        }


    }
}