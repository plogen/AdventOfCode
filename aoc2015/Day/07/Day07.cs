using Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static aoc2015.Day03;
using static aoc2015.Day07;

namespace aoc2015
{
    public static class Day07
    {

        public static Regex SIGNALValue = new Regex(@"^(\d+) -> ([a-zA-Z]+)$");
        public static Regex SIGNAL = new Regex(@"^([a-zA-Z]+) -> ([a-zA-Z]+)$");
        public static Regex AND = new Regex(@"([a-zA-Z]+)\sAND\s([a-zA-Z]+) -> ([a-zA-Z]+)");
        public static Regex OR = new Regex(@"([a-zA-Z]+)\sOR\s([a-zA-Z]+) -> ([a-zA-Z]+)");
        public static Regex LSHIFT = new Regex(@"([a-zA-Z]+)\s(?:LSHIFT)\s(\d+) -> ([a-zA-Z]+)");
        public static Regex RSHIFT = new Regex(@"([a-zA-Z]+)\s(?:RSHIFT)\s(\d+) -> ([a-zA-Z]+)");
        public static Regex NOT = new Regex(@"NOT\s([a-zA-Z]+) -> ([a-zA-Z]+)");
        

        public static string? ConnectWires(string input, List<Wire> wires)
        {
            MatchCollection match;

            match = SIGNALValue.Matches(input);
            if (match.Count > 0)
            {
                var value = UInt16.Parse(match[0].Groups[1].Value);
                var destination = match[0].Groups[2].Value;
                var destinationWire = wires.FirstOrDefault(w => w.Name == destination);
                if (destinationWire is null)
                {
                    wires.Add(new Wire() { Name = destination, Value = value });
                }
                else
                {
                    destinationWire.Value = value;
                }
                return null;
            }

            match = SIGNAL.Matches(input);
            if (match.Count > 0)
            {
                var source = match[0].Groups[1].Value;
                var destination = match[0].Groups[2].Value;

                var sourceWire = wires.FirstOrDefault(w => w.Name == source);
                var destinationWire = wires.FirstOrDefault(w => w.Name == destination);

                if(sourceWire is null)
                    return input;

                var value = sourceWire.Value;

                if (destinationWire is null)
                {
                    wires.Add(new Wire() { Name = destination, Value = value });
                }
                else
                {
                    destinationWire.Value = value;
                }
                return null;
            }


            match = AND.Matches(input);
            if (match.Count > 0)
            {
                var source1 = match[0].Groups[1].Value;
                var source2 = match[0].Groups[2].Value;
                var destination = match[0].Groups[3].Value;

                var sourceWire1 = wires.FirstOrDefault(w => w.Name == source1);
                var sourceWire2 = wires.FirstOrDefault(w => w.Name == source2);
                var destinationWire = wires.FirstOrDefault(w => w.Name == destination);

                if(sourceWire1 is null || sourceWire2 is null)
                    return input;

                UInt16 value = (UInt16)(sourceWire1.Value & sourceWire2.Value);

                if (destinationWire is null)
                {
                    wires.Add(new Wire() { Name = destination, Value = value });
                }
                else
                {
                    destinationWire.Value = value;
                }
                return null;
            }

            match = OR.Matches(input);
            if (match.Count > 0)
            {
                var source1 = match[0].Groups[1].Value;
                var source2 = match[0].Groups[2].Value;
                var destination = match[0].Groups[3].Value;

                var sourceWire1 = wires.FirstOrDefault(w => w.Name == source1);
                var sourceWire2 = wires.FirstOrDefault(w => w.Name == source2);
                var destinationWire = wires.FirstOrDefault(w => w.Name == destination);

                if (sourceWire1 is null || sourceWire2 is null)
                    return input;

                UInt16 value = (UInt16)(sourceWire1.Value | sourceWire2.Value);

                if (destinationWire is null)
                {
                    wires.Add(new Wire() { Name = destination, Value = value });
                }
                else
                {
                    destinationWire.Value = value;
                }
                return null;
            }

            match = LSHIFT.Matches(input);
            if (match.Count > 0)
            {
                var source = match[0].Groups[1].Value;
                var valueToShift = UInt16.Parse(match[0].Groups[2].Value);
                var destination = match[0].Groups[3].Value;

                var sourceWire = wires.FirstOrDefault(w => w.Name == source);
                var destinationWire = wires.FirstOrDefault(w => w.Name == destination);

                if (sourceWire is null)
                    return input;

                var value = (ushort)(sourceWire.Value << valueToShift);

                if (destinationWire is null)
                {
                    wires.Add(new Wire() { Name = destination, Value = value });
                }
                else
                {
                    destinationWire.Value = value;
                }
                return null;
            }


            match = RSHIFT.Matches(input);
            if (match.Count > 0)
            {
                var source = match[0].Groups[1].Value;
                var valueToShift = UInt16.Parse(match[0].Groups[2].Value);
                var destination = match[0].Groups[3].Value;

                var sourceWire = wires.FirstOrDefault(w => w.Name == source);
                var destinationWire = wires.FirstOrDefault(w => w.Name == destination);

                if (sourceWire is null)
                    return input;

                var value = (ushort)(sourceWire.Value >> valueToShift);

                if (destinationWire is null)
                {
                    wires.Add(new Wire() { Name = destination, Value = value });
                }
                else
                {
                    destinationWire.Value = value;
                }
                return null;
            }


            match = NOT.Matches(input);
            if (match.Count > 0)
            {
                var source = match[0].Groups[1].Value;
                var destination = match[0].Groups[2].Value;

                var sourceWire = wires.FirstOrDefault(w => w.Name == source);
                var destinationWire = wires.FirstOrDefault(w => w.Name == destination);

                if (sourceWire is null)
                    return input;

                var value = (ushort)~sourceWire.Value;

                if (destinationWire is null)
                {
                    wires.Add(new Wire() { Name = destination, Value = value });
                }
                else
                {
                    destinationWire.Value = value;
                }
                return null;
            }

            return null;
        }

        public static int Part1(List<string> inputs)
        {
            var wires = new List<Wire>();
            var retries = new Queue<string>();
            foreach (var input in inputs)
            {
                var result = ConnectWires(input, wires);
                if(result != null)
                {
                    retries.Enqueue(result);
                }
            }

            while (retries.Count > 0)
            {
                var retry = retries.Dequeue();
                var result = ConnectWires(retry, wires);
                if (result != null)
                {
                    retries.Enqueue(result);
                }
            }

            return -1;
        }

        public static int Part2(List<string> inputs)
        {
            return -1;
        }

        public class Wire
        {
            public string Name { get; set; }
            public bool IsDone { get; set; }
            public string? Depend1 { get; set; }
            public string? Depend2 { get; set; }
            public UInt16 Value { get; set; }
        }






    }
}
