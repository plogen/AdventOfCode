using Common;
using System.Collections;
using System.Text.RegularExpressions;
using static System.Collections.Specialized.BitVector32;

//Puzzle: https://adventofcode.com/2022/day/11
namespace aoc2022
{
    public class Day11: DayPuzzle
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



            //var t = Helper.Operators["+"](1, 2);

            for (int i = 0; i < 20; i++)
            {

                foreach (var monkey in monkeys)
                {
                    while (monkey.Items.Count > 0)
                    {
                        var item = monkey.Items.Dequeue();

                        var leftValue = monkey.OperationLeftValue == null ? item : monkey.OperationLeftValue;
                        var rightValue = monkey.OperationRightValue == null ? item : monkey.OperationRightValue;

                        var afterInspectionValue = Helper.Operators[monkey.Operation]((int)leftValue, (int)rightValue);
                        var afterReliefValue = Convert.ToInt32(Math.Floor((float)(afterInspectionValue / 3)));

                        if (afterReliefValue % monkey.TestOperationNumber == 0)
                            monkeys[monkey.TestTrueThrowTo].Items.Enqueue(afterReliefValue);
                        else
                            monkeys[monkey.TestFalseThrowTo].Items.Enqueue(afterReliefValue);

                        monkey.Inspections++;
                    }
                }
            }

            var mosteInspectedMokeys = monkeys.OrderByDescending(m => m.Inspections).Take(2).ToList();
            return mosteInspectedMokeys[0].Inspections * mosteInspectedMokeys[1].Inspections;

        }

        public override object Part2(List<string> input)
        {
            return -1;
        }




        private static List<Monkey> GetMonkeys(List<string> input)
        {
            List<Monkey> monkeys = new();
            var mokeysCount = (input.Count+1) / 7;
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
        public Queue<int> Items { get; set; } = new Queue<int>();
        public char Operation { get; set; }
        public int? OperationLeftValue { get; set; }
        public int? OperationRightValue { get; set; }

        public char TestOperation { get; set; }
        public int TestOperationNumber { get; set; }

        public int TestTrueThrowTo { get; set; }
        public int TestFalseThrowTo { get; set; }

        public int Inspections { get; set; }
    }

}