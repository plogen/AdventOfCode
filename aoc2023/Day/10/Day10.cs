using Common;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;

//Puzzle: https://adventofcode.com/2023/day/10
namespace aoc2023
{
    public class Day10 : DayPuzzle
    {
        public override object Part1(List<string> input)
        {
            int[,] map = GetMap(input);
            var animal = Helper.SearchArray(0, map);
            var animalWays = GetWays(map, animal);

            var startingPosition = (animal.X, animal.Y);

            var way1 = (animalWays.Value.way1.Item1, animalWays.Value.way1.Item2);
            var way1stepps = GetSteps(map, animal, startingPosition, way1);

            return way1stepps / 2;
        }

        public override object Part2(List<string> input)
        {
            int[,] map = GetMap(input);
            var animal = Helper.SearchArray(0, map);
            var animalWays = GetWays(map, animal);

            var startingPosition = (animal.X, animal.Y);

            var way1 = (animalWays.Value.way1.Item1, animalWays.Value.way1.Item2);
            var way1stepps = GetSteppedMap(map, animal, startingPosition, way1);



            GraphicsPath gp = new GraphicsPath();
            gp.StartFigure();
            gp.AddLines(way1stepps.Item2.ToArray());
            gp.CloseFigure();


            //Only used to get a nice drawing ;)
            Bitmap bm = new Bitmap(map.GetLength(0) * 10, map.GetLength(1) * 10);
            Graphics g = Graphics.FromImage(bm);
            g.DrawPath(Pens.DarkRed, gp);


            int tilesInsodeLoop = 0;
            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {

                    if (way1stepps.Item1[x, y] == 0)//Do not include actual pipes that is visited by the loop
                    {
                        bool isInPath = gp.IsVisible(new Point(x * 10, y * 10));
                        if (isInPath)
                        {
                            if (map[x, y] == -1)
                            {
                                //Real dot
                                g.FillRectangle(Brushes.Yellow, x * 10, y * 10, 4, 4);
                            }
                            else
                            {
                                //Junk pipes
                                g.FillRectangle(Brushes.OrangeRed, x * 10, y * 10, 4, 4);
                            }
                            tilesInsodeLoop++;
                        }
                        else
                        {
                            //Outside loop
                            g.FillRectangle(Brushes.Gray, x * 10, y * 10, 4, 4);
                        }
                    }
                }
            }

            bm.Save("Day10Part2.bmp", ImageFormat.Bmp);
            g.Dispose();

            return tilesInsodeLoop;
        }

        private static int GetSteps(int[,] map, (int X, int Y) animal, (int X, int Y) startingPosition, (int, int) initialNextPosition)
        {
            var prevPosition = startingPosition;
            var nextPosition = initialNextPosition;

            var stepps = 1;
            while (nextPosition != animal)
            {
                var nextPipeType = map[nextPosition.Item1, nextPosition.Item2];
                var aPos = GetNextPosition(prevPosition, nextPipeType, nextPosition);
                prevPosition = nextPosition;
                nextPosition = aPos;
                stepps++;
            }

            return stepps;
        }

        private static (int[,], List<Point>) GetSteppedMap(int[,] map, (int X, int Y) animal, (int X, int Y) startingPosition, (int, int) initialNextPosition)
        {
            int[,] steppedMap = new int[map.GetLength(0), map.GetLength(1)];
            List<Point> points = new List<Point>();
            points.Add(new Point(startingPosition.X * 10, startingPosition.Y * 10));


            var prevPosition = startingPosition;
            var nextPosition = initialNextPosition;

            steppedMap[startingPosition.X, startingPosition.Y] = 1;
            steppedMap[initialNextPosition.Item1, initialNextPosition.Item2] = 1;

            while (nextPosition != animal)
            {
                points.Add(new Point(nextPosition.Item1 * 10, nextPosition.Item2 * 10));

                var nextPipeType = map[nextPosition.Item1, nextPosition.Item2];
                var aPos = GetNextPosition(prevPosition, nextPipeType, nextPosition);
                prevPosition = nextPosition;
                nextPosition = aPos;
                steppedMap[nextPosition.Item1, nextPosition.Item2] = 1;
            }

            return (steppedMap, points);
        }

        private static int[,] GetMap(List<string> input)
        {
            var xSize = input.First().Length;
            var ySize = input.Count;

            int[,] map = new int[xSize, ySize];

            for (int y = 0; y < ySize; y++)
            {
                for (int x = 0; x < xSize; x++)
                {
                    map[x, y] = GetLocationType(input[y][x]);
                }
            }

            return map;
        }


        private static int GetLocationType(char card)
        {
            switch (card)
            {
                case 'S':
                    return 0;
                case '|':
                    return 1;
                case '-':
                    return 2;
                case 'L':
                    return 3;
                case 'J':
                    return 4;
                case '7':
                    return 5;
                case 'F':
                    return 6;
                case '.':
                    return -1;
                default:
                    throw new ArgumentException("Not expected location input");
            }

            //| is a vertical pipe connecting north and south.
            //- is a horizontal pipe connecting east and west.
            //L is a 90 - degree bend connecting north and east.
            //J is a 90 - degree bend connecting north and west.
            //7 is a 90 - degree bend connecting south and west.
            //F is a 90 - degree bend connecting south and east.
            //. is ground; there is no pipe in this tile.
            //S is the starting position of the animal; there is a pipe on this tile, but your sketch doesn't show what shape the pipe has.
        }

        private static Dictionary<int, Tuple<(int, int), (int, int)>> PipeEndings = new()
        {

            { 1, new Tuple<(int, int), (int, int)>( (0, -1), (0, 1)) },
            { 2, new Tuple<(int, int), (int, int)>( (-1, 0), (1, 0)) },
            { 3, new Tuple<(int, int), (int, int)>( (0, -1), (1, 0)) },
            { 4, new Tuple<(int, int), (int, int)>( (-1, 0), (0, -1)) },
            { 5, new Tuple<(int, int), (int, int)>( (-1, 0), (0, 1)) },
            { 6, new Tuple<(int, int), (int, int)>( (0, 1), (1, 0)) },
        };

        private static (Tuple<int, int>? way1, Tuple<int, int>? way2)? GetWays(int[,] map, (int, int) startingPoint)
        {
            Tuple<int, int>? way1 = null;
            Tuple<int, int>? way2 = null;
            for (int y = startingPoint.Item2 - 1; y < startingPoint.Item2 + 2; y++)
            {
                if (y < 0 || y > map.GetLength(1))
                    continue;

                for (int x = startingPoint.Item1 - 1; x < startingPoint.Item1 + 2; x++)
                {
                    if (x < 0 || x > map.GetLength(0))
                        continue;

                    if (x == startingPoint.Item1 && y == startingPoint.Item2)
                        continue;

                    if (map[x, y] > 0)
                    {
                        var pipeEndings = PipeEndings[map[x, y]];

                        if ((x + pipeEndings.Item1.Item1) == startingPoint.Item1 &&
                            (y + pipeEndings.Item1.Item2) == startingPoint.Item2)
                        {
                            if (way1 == null)
                                way1 = new Tuple<int, int>(x, y);
                            else
                                way2 = new Tuple<int, int>(x, y);
                        }

                        if ((x + pipeEndings.Item2.Item1) == startingPoint.Item1 &&
                            (y + pipeEndings.Item2.Item2) == startingPoint.Item2)
                        {
                            if (way1 == null)
                                way1 = new Tuple<int, int>(x, y);
                            else
                                way2 = new Tuple<int, int>(x, y);
                        }

                    }
                }
            }
            return new(way1, way2);
        }



        private static (int, int) GetNextPosition((int, int) startingPoint, int pipeType, (int, int) pipePosition)
        {
            var pipeEndings = PipeEndings[pipeType];
            if ((pipePosition.Item1 + pipeEndings.Item1.Item1) == startingPoint.Item1 &&
                (pipePosition.Item2 + pipeEndings.Item1.Item2) == startingPoint.Item2)
            {
                return (pipePosition.Item1 + pipeEndings.Item2.Item1, pipePosition.Item2 + pipeEndings.Item2.Item2);
            }
            else
            {
                return (pipePosition.Item1 + pipeEndings.Item1.Item1, pipePosition.Item2 + pipeEndings.Item1.Item2);
            }
        }


    }
}