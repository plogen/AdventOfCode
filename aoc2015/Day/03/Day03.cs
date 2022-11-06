using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static aoc2015.Day03;

namespace aoc2015
{
    public static class Day03
    {
        public static int Part1(string input)
        {
            var houses = GetVisitedHouses(input);
            return houses.Count(h => h.Presents >= 1);
        }

        private static List<House> GetVisitedHouses(string input)
        {
            int x = 0;
            int y = 0;

            List<House> houses = new List<House>()
            {
                new House(){ X = x, Y = y, Presents = 1 }
            };

            foreach (var c in input)
            {
                switch (c)
                {
                    case '^':
                        y++; break;
                    case 'v':
                        y--; break;
                    case '<':
                        x--; break;
                    case '>':
                        x++; break;
                    default:
                        break;
                }

                var house = houses.FirstOrDefault(h => h.X == x && h.Y == y);
                if (house is null)
                    houses.Add(new House() { X = x, Y = y, Presents = 1 });
                else
                    house.Presents++;
            }
            return houses;
        }



        private static List<House> GetVisitedHousesRobotSanta(string input)
        {
            int turn = 0;
            int x = 0;
            int y = 0;

            var santas = new Santa[] { new Santa(), new Santa() };

            var houses = new List<House>()
            {
                new House(){ X = x, Y = y, Presents = 2 }
            };

            foreach (var c in input)
            {
                var santa = santas[turn];
                switch (c)
                {
                    case '^':
                        santa.Y++; break;
                    case 'v':
                        santa.Y--; break;
                    case '<':
                        santa.X--; break;
                    case '>':
                        santa.X++; break;
                    default:
                        break;
                }

                var house = houses.FirstOrDefault(h => h.X == santa.X && h.Y == santa.Y);
                if (house is null)
                    houses.Add(new House() { X = santa.X, Y = santa.Y, Presents = 1 });
                else
                    house.Presents++;

                turn = turn == 1 ? 0 : 1;
            }
            return houses;
        }

        public static int Part2(string input)
        {
            var houses = GetVisitedHousesRobotSanta(input);
            return houses.Count(h => h.Presents >= 1);
        }



        public class House
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Presents { get; set; }
        }


        public class Santa {
            public int X { get; set; }
            public int Y { get; set; }
            public Santa()
            {

            }
        }

    }
}
