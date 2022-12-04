using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aoc2022
{
    public static class Day03
    {
        public static long Part1(List<string> input)
        {
            int points = 0;
            foreach (var x in input)
            {
                var rucksack = GetRucksack(x);
                var duplicatedItem = GetDuplicatedItem(rucksack);
                points += AlphabetScore[duplicatedItem];
            }

            return points;
        }

        public static long Part2(List<string> input)
        {

            List<Rucksack> rucksacks = new List<Rucksack>();

            input.ForEach(i => rucksacks.Add(GetRucksack(i)));

            var elvesGroups = rucksacks.MakeChunks(3);

            int points = 0;
            foreach (var group in elvesGroups)
            {
                var duplicatedItem = GetCommonItem(group);
                points += AlphabetScore[duplicatedItem];
            }

            return points;
        }


        private static Rucksack GetRucksack(string input)
        {
            return new Rucksack(input.Substring(0, input.Length / 2), input.Substring(input.Length / 2));            
        }

        private static char GetDuplicatedItem(Rucksack rucksack)
        {
            return rucksack.Compartment1.FirstOrDefault(c => rucksack.Compartment2.Contains(c));
        }

        private static char GetCommonItem(List<Rucksack> elvesGroup)
        {
            var completeContent = elvesGroup.Select(r => r.Compartment1+ r.Compartment2).ToList();

            foreach (var c in completeContent.First())
            {
                if(completeContent.All(x => x.Contains(c)))
                    return c;
            }

            throw new Exception("Invalid evaluation");            
        }


        private record Rucksack(string Compartment1, string Compartment2);


        private static Dictionary<char, int> AlphabetScore = new Dictionary<char, int>()
        {
            {'a',1},{'b',2},{'c',3},{'d',4},{'e',5},{'f',6},{'g',7},{'h',8},{'i',9},{'j',10},{'k',11},{'l',12},{'m',13},{'n',14},{'o',15},{'p',16},{'q',17},{'r',18},{'s',19},{'t',20},{'u',21},{'v',22},{'w',23},{'x',24},{'y',25},{'z',26},{'A',27},{'B',28},{'C',29},{'D',30},{'E',31},{'F',32},{'G',33},{'H',34},{'I',35},{'J',36},{'K',37},{'L',38},{'M',39},{'N',40},{'O',41},{'P',42},{'Q',43},{'R',44},{'S',45},{'T',46},{'U',47},{'V',48},{'W',49},{'X',50},{'Y',51},{'Z',52}
        };


    }
}
