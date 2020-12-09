using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace _2020.Day1
{
    public static class FindExpenceError
    {
        public static List<int> GetInput()
        {
            List<int> list = new List<int>();
            int line = 1;
            string lineData;
            try
            {
                using (var sr = new StreamReader("./Day1/input.txt"))
                {
                    while ((lineData = sr.ReadLine()) != null)
                    {
                        ushort value;
                        if (ushort.TryParse(lineData, out value))
                        {
                            list.Add(value);
                        }
                        else
                        {
                            Console.WriteLine($"Error while parsing line {line}");
                        }
                        line++;
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            return list;
        }


        public static int GetAnswer2(List<int> inputs)
        {
            int pair1 = 0;
            int pair2 = 0;
            foreach (var input in inputs)
            {
                int expectedPair = (2020 - input);
                if (inputs.Contains(expectedPair))
                {
                    pair1 = input;
                    pair2 = expectedPair;
                    break;
                }
            }
            return pair1 * pair2;
        }

        public static int GetAnswer(List<int> input)
        {
            int result = 0;
            for (int x = 0; x < input.Count; x++)
            {
                for (int y = 0; y < input.Count; y++)
                {
                    if (x == y)
                        continue;

                    var value = input[x] + input[y];

                    if (value == 2020)
                    {
                        result = input[x] * input[y];
                        Console.WriteLine($"{input[x]} * {input[y]} = {value}");
                    }
                }
            }
            return result;
        }
    }
}
