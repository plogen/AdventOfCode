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
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Xml.Linq;
using System.Text.Json.Nodes;
using Newtonsoft.Json.Linq;
using MoreLinq;

namespace aoc2015
{
    public static class Day12
    {

        public static Regex allDigits = new Regex(@"(-?\d+)");

        public static int Part1(string input)
        {
            var matches = allDigits.Matches(input);

            var sum = allDigits.Matches(input)
                .Cast<Match>()
                .Select(m => int.Parse(m.Value))
                .Sum();

            return sum;
        }

        public static long Part2(string input)
        {
            var t2 = JObject.Parse(input);
            return SumValidParts(t2);
        }


        public static long SumValidParts(JToken input) 
        {
            if (input is JObject) //Root object count as a JObject so recursivenes will start
            { 
                var jObject = (JObject)input;
                if (HasRed(jObject)) //Ignore any object (and all of its children) which has any property with the value "red".
                    return 0;

                return jObject.Properties().Select(p => p.Value)
                    .Sum(token => SumValidParts(token));
            }
            else if(input is JArray)
            {
                var jArray = (JArray)input;

                return jArray.Sum(token => SumValidParts(token));// do not ignore arrays but recusevly continue
            }
            else if (input is JValue)
            {
                var jValue = (JValue)input;
                if (jValue.Value is long)
                    return (long)jValue.Value;
                else
                    return 0;
            }

            throw new InvalidDataException();
        }


        public static bool HasRed(JObject input)
        {
            return input.Properties()
                .Select(p => p.Value).OfType<JValue>()
                .Select(v => v.Value).OfType<string>()
                .Any(v => v == "red");
        }


    }
}
