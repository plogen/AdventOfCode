using Common;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static aoc2022.Day02;

namespace aoc2022
{
    public static class Day10
    {
        public static Regex addxRegex = new Regex(@"(\w+) (-?\d+)");

        public static int Part1(List<string> input)
        {
            var instructions = GetInstructions(input);


            int result = 0;
            var x = 1;
            var cycle = 0;
            int[] interestingCycles = new int[]
            {
                20, 60, 100, 140, 180, 220
            };
            foreach (var instruction in instructions)
            {
                if (instruction.name == "noop")
                {
                    result += InterestingCycleResult(interestingCycles, cycle, x, 1);
                    cycle++;
                }
                else if (instruction.name == "addx")
                {
                    result += InterestingCycleResult(interestingCycles, cycle, x, 2);
                    cycle += 2;
                    x += instruction.value;
                }




            }

            return result;
        }

        private static int InterestingCycleResult(int[] interestingCycles, int cycle, int x, int cycleIncrement)
        {
            var interestin = interestingCycles.FirstOrDefault(i => i > cycle && i <= cycle + cycleIncrement);

            if (interestin != 0)
            {
                var r = interestin * x;
                return r;
            }

            return 0;
        }



        public static int Part2(List<string> input)
        {
            return -1;
        }

        private static List<Instruction> GetInstructions(List<string> input)
        {
            var instructions = new List<Instruction>();

            foreach (var row in input)
            {
                var addxMatch = addxRegex.Match(row);
                if (addxMatch.Success)
                {
                    instructions.Add(new Instruction(addxMatch.Groups[1].Value, int.Parse(addxMatch.Groups[2].Value)));
                }
                else
                {
                    instructions.Add(new Instruction("noop", 0));
                }
            }
            return instructions;
        }

        private record Instruction(string name, int value);

    }
}
