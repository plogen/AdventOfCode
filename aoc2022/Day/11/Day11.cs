using Common;
using System.Collections;
using System.Numerics;
using System.Text.RegularExpressions;
using static System.Collections.Specialized.BitVector32;

//Puzzle: https://adventofcode.com/2022/day/11
namespace aoc2022
{
    public class Day11 : DayPuzzle
    {

        public static Regex numbersRegex = new Regex(@"(\d+)");
        public static Regex leftOldRegex = new Regex(@"  Operation: new = (?:old)");
        public static Regex leftValueRegex = new Regex(@"  Operation: new = (\d+)");
        public static Regex operationRegex = new Regex(@"Operation: new = (?:\S+) (\S)");
        public static Regex rightOldRegex = new Regex(@"  Operation: new = (?:\S+) \S (old)");
        public static Regex rightValueRegex = new Regex(@"  Operation: new = (?:\S+) \S (\d+)");
        public static Regex testRegex = new Regex(@"  Test: (divisible) by (\d+)");


        public override object Part1(List<string> input)
        {
            var monkeys = GetMonkeys(input);
            return GetMonkeyBusiness(monkeys, 20, true);
        }

        public override object Part2(List<string> input)
        {
            var monkeys = GetMonkeys(input);
            return GetMonkeyBusiness(monkeys, 10000, false);
        }

        private static object GetMonkeyBusiness(List<Monkey> monkeys, int rounds, bool inspectionRelief)
        {
            var cutOff = 1l;
            monkeys.ForEach(m => cutOff *= m.TestOperationNumber);

            try
            {

                for (int i = 0; i < rounds; i++)
                {

                    foreach (var monkey in monkeys)
                    {
                        while (monkey.Items.Count > 0)
                        {
                            var item = monkey.Items.Dequeue();

                            var leftValue = monkey.OperationLeftValue == null ? item : monkey.OperationLeftValue;
                            var rightValue = monkey.OperationRightValue == null ? item : monkey.OperationRightValue;

                            var afterInspectionValue = Helper.Operators[monkey.Operation]((long)leftValue, (long)rightValue);

                            long value;
                            if (inspectionRelief)
                                value = Convert.ToInt64(Math.Floor((double)(afterInspectionValue / 3)));
                            else
                                value = afterInspectionValue;

                            if (value % monkey.TestOperationNumber == 0)
                                monkeys[monkey.TestTrueThrowTo].Items.Enqueue(value % cutOff);
                            else
                                monkeys[monkey.TestFalseThrowTo].Items.Enqueue(value % cutOff);

                            monkey.Inspections++;
                        }
                    }
                }

                var mostInspectedMokeys = monkeys.OrderByDescending(m => m.Inspections).Take(2).ToList();
                return mostInspectedMokeys[0].Inspections * mostInspectedMokeys[1].Inspections;

            }
            catch (OverflowException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        private static List<Monkey> GetMonkeys(List<string> input)
        {
            List<Monkey> monkeys = new();
            var mokeysCount = (input.Count + 1) / 7;
            for (int m = 0; m < mokeysCount; m++)
            {
                Monkey monkey = new();
                var itemsString = input[m * 7 + 1];
                var items = numbersRegex.Matches(itemsString)
                            .Select(m => int.Parse(m.Groups[1].Value)).ToList();
                items?.ForEach(i => monkey.Items.Enqueue(i));

                var operationString = input[m * 7 + 2];

                monkey.Operation = operationRegex.Matches(operationString)
                    .Select(m => char.Parse(m.Groups[1].Value)).First();

                if (leftOldRegex.Matches(operationString).Count > 0)
                {
                    monkey.OperationLeftValue = null;
                }
                else
                {
                    monkey.OperationLeftValue = leftValueRegex.Matches(operationString).Select(m => int.Parse(m.Groups[1].Value)).First();
                }

                if (rightOldRegex.Matches(operationString).Count > 0)
                {
                    monkey.OperationRightValue = null;
                }
                else
                {
                    monkey.OperationRightValue = rightValueRegex.Matches(operationString).Select(m => int.Parse(m.Groups[1].Value)).First();
                }


                var testString = input[m * 7 + 3];
                var test = testRegex.Matches(testString);
                monkey.TestOperation = test.Select(m => m.Groups[1].Value.Equals("divisible") ? '/' : '?').First();
                monkey.TestOperationNumber = test.Select(m => int.Parse(m.Groups[2].Value)).First();

                var testTrueString = input[m * 7 + 4];
                monkey.TestTrueThrowTo = numbersRegex.Matches(testTrueString)
                    .Select(m => int.Parse(m.Groups[1].Value)).First();

                var testFalseString = input[m * 7 + 5];
                monkey.TestFalseThrowTo = numbersRegex.Matches(testFalseString)
                    .Select(m => int.Parse(m.Groups[1].Value)).First();

                monkeys.Add(monkey);
            }

            return monkeys;
        }



    }

    public class Monkey
    {
        public Queue<long> Items { get; set; } = new Queue<long>();
        public char Operation { get; set; }
        public long? OperationLeftValue { get; set; }
        public long? OperationRightValue { get; set; }

        public char TestOperation { get; set; }
        public long TestOperationNumber { get; set; }

        public int TestTrueThrowTo { get; set; }
        public int TestFalseThrowTo { get; set; }

        public long Inspections { get; set; }
    }

}