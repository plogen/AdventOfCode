using Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static aoc2015.Day03;
using static aoc2015.Day07;
using System.Collections;
using static aoc2015.Day09;
using MoreLinq;

namespace aoc2015
{
    public static class Day13
    {

        public static Regex route = new Regex(@"(\w+) would (\w+) (\d+) happiness units by sitting next to (\w+)");

        public static int Part1(List<string> inputs)
        {
            Dictionary<(string x, string y), int> seatings = GetSeatings(inputs);

            var persons = new HashSet<string>();
            seatings.ForEach(x => {
                persons.Add(x.Key.x);
                persons.Add(x.Key.y);
            });

            var people = persons.ToArray();
            int personCount = people.Length;

            var adjacencyMatrix = GetAdjacencyMatrix(people, seatings);
            var permutations = Algorithms.GetPermutations(people, personCount);
            var result = GetOptimalHappiness(personCount, adjacencyMatrix);

            return result;
        }

        public static int Part2(List<string> inputs)
        {
            Dictionary<(string x, string y), int> seatings = GetSeatings(inputs);

            var persons = new HashSet<string>();
            seatings.ForEach(x => {
                persons.Add(x.Key.x);
                persons.Add(x.Key.y);
            });

            var people = persons.ToArray();
            int personCount = people.Length;

            var adjacencyMatrix = GetAdjacencyMatrix(people, seatings);
            var permutations = Algorithms.GetPermutations(people, personCount);
            var result = GetOptimalHappiness(personCount + 1, adjacencyMatrix); //One additinal neutral person

            return result;
        }



        private static Dictionary<(string x, string y), int> GetSeatings(List<string> inputs)
        {
            var happinesses = new Dictionary<(string x, string y), int>();

            inputs.ForEach(x =>
            {
                var match = route.Matches(x);
                var p1 = match[0].Groups[1].Value;
                var p2 = match[0].Groups[4].Value;
                var gain = match[0].Groups[2].Value == "gain" ? true : false;
                var value = int.Parse(match[0].Groups[3].Value);
                happinesses[(p1, p2)] = gain ? value : value * -1;
            });
            return happinesses;
        }




        private static int[,] GetAdjacencyMatrix(string[] people, Dictionary<(string x, string y), int> seatings)
        {
            int personCount = people.Length;

            int[,] adjacencyMatrix = new int[personCount + 1, personCount + 1]; // +1 to fit part 2
            for (int a = 0; a < personCount; a++)
            {
                for (int b = 0; b < personCount; b++)
                {
                    if (seatings.TryGetValue((people[a], people[b]), out int happiness))
                    {
                        adjacencyMatrix[a, b] = happiness;
                    }
                }
            }
            return adjacencyMatrix;
        }


        private static int GetOptimalHappiness(int numPeople, int[,] adjacencyMatrix)
        {
            int[] people = new int[numPeople];
            for (int p = 0; p < numPeople; p++)
            {
                people[p] = p;
            }

            int maxHappiness = int.MinValue;
            var permutations = Algorithms.GetPermutations(people, numPeople);
            foreach (var permutation in permutations)
            {
                var p = permutation.ToArray();

                int totalHappiness = 0;
                int prevPerson = p[^1];
                for (int j = 0; j < p.Length; j++)
                {
                    int person = p[j];
                    totalHappiness += adjacencyMatrix[prevPerson, person];
                    totalHappiness += adjacencyMatrix[person, prevPerson];
                    prevPerson = person;
                }

                maxHappiness = Math.Max(totalHappiness, maxHappiness);
            }

            return maxHappiness;
        }




    }
}
