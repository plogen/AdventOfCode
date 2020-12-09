using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _2020.Day2
{
    public static class ValidatePasswords
    {

        public class Password
        {
            public char ExpectedChar { get; set; }
            public byte LowLimit { get; set; }
            public byte HighLimit { get; set; }

            public string Input { get; set; }

            public bool IsValid { get; set; }

            public Password(char expectedChar, byte lowLimit, byte highLimit, string input)
            {
                ExpectedChar = expectedChar;
                LowLimit = lowLimit;
                HighLimit = highLimit;
                Input = input;
            }
        }

        public static List<Password> GetInput()
        {
            List<Password> list = new List<Password>();
            int line = 1;
            string lineData;
            try
            {
                using (var sr = new StreamReader("./Day2/input.txt"))
                {
                    while ((lineData = sr.ReadLine()) != null)
                    {
                        var data = Regex.Match(lineData, @"^(\d{1,2})-(\d{1,2})[ ](\w{1})..(\w*)");

                        try
                        {
                            Password pass = new(data.Groups[3].Value[0], byte.Parse(data.Groups[1].Value), byte.Parse(data.Groups[2].Value), data.Groups[4].Value);
                            list.Add(pass);
                        }
                        catch (Exception)
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

        public static int ValidPasswords(List<Password> passwords)
        {
            return passwords.Count(p => p.Input.Count(c => c == p.ExpectedChar) >= p.LowLimit && p.Input.Count(c => c == p.ExpectedChar) <= p.HighLimit);
        }
    }
}
