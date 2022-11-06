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


        public static List<Wire> GetInitialWireList(List<string> inputs)
        {
            var wires = new List<Wire>();
            foreach (var input in inputs)
            {
                MatchCollection match;
                match = SIGNALValue.Matches(input);
                if (match.Count > 0)
                {
                    var value = UInt16.Parse(match[0].Groups[1].Value);
                    var destination = match[0].Groups[2].Value;
                    wires.Add(new Wire() { Name = destination, Value = value, Depend1 = match[0].Groups[1].Value, ConnectionType = ConnectionType.SIGNALValue, IsDone = true });
                    continue;
                }

                match = SIGNAL.Matches(input);
                if (match.Count > 0)
                {
                    var source = match[0].Groups[1].Value;
                    var destination = match[0].Groups[2].Value;
                    var sourceWire = wires.FirstOrDefault(w => w.Name == source);

                    if (sourceWire is null || sourceWire.IsDone == false)
                    {
                        wires.Add(new Wire() { Name = destination, Depend1 = source, ConnectionType = ConnectionType.SIGNAL });
                        continue;
                    }

                    var value = sourceWire.Value;
                    wires.Add(new Wire() { Name = destination, Value = value, Depend1 = source, ConnectionType = ConnectionType.SIGNAL, IsDone = true });
                    continue;
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

                    if (sourceWire1 is null || sourceWire1.IsDone == false || sourceWire2 is null || sourceWire2.IsDone == false)
                    {
                        wires.Add(new Wire() { Name = destination, Depend1 = source1, Depend2 = source2, ConnectionType = ConnectionType.AND });
                        continue;
                    }

                    UInt16 value = (UInt16)(sourceWire1.Value & sourceWire2.Value);
                    wires.Add(new Wire() { Name = destination, Value = value, Depend1 = source1, Depend2 = source2, ConnectionType = ConnectionType.AND, IsDone = true });
                    continue;
                }

                match = OR.Matches(input);
                if (match.Count > 0)
                {
                    var source1 = match[0].Groups[1].Value;
                    var source2 = match[0].Groups[2].Value;
                    var destination = match[0].Groups[3].Value;

                    var sourceWire1 = wires.FirstOrDefault(w => w.Name == source1);
                    var sourceWire2 = wires.FirstOrDefault(w => w.Name == source2);

                    if (sourceWire1 is null || sourceWire1.IsDone == false || sourceWire2 is null || sourceWire2.IsDone == false)
                    {
                        wires.Add(new Wire() { Name = destination, Depend1 = source1, Depend2 = source2, ConnectionType = ConnectionType.OR });
                        continue;
                    }

                    UInt16 value = (UInt16)(sourceWire1.Value | sourceWire2.Value);
                    wires.Add(new Wire() { Name = destination, Value = value, Depend1 = source1, Depend2 = source2, ConnectionType = ConnectionType.OR, IsDone = true });
                    continue;
                }

                match = LSHIFT.Matches(input);
                if (match.Count > 0)
                {
                    var source = match[0].Groups[1].Value;
                    var valueToShift = UInt16.Parse(match[0].Groups[2].Value);
                    var destination = match[0].Groups[3].Value;

                    var sourceWire = wires.FirstOrDefault(w => w.Name == source);

                    if (sourceWire is null || sourceWire.IsDone == false)
                    {
                        wires.Add(new Wire() { Name = destination, Depend1 = source, Input = valueToShift, ConnectionType = ConnectionType.LSHIFT });
                        continue;
                    }

                    var value = (ushort)(sourceWire.Value << valueToShift);
                    wires.Add(new Wire() { Name = destination, Value = value, Depend1 = source, Input = valueToShift, ConnectionType = ConnectionType.LSHIFT, IsDone = true });
                    continue;
                }


                match = RSHIFT.Matches(input);
                if (match.Count > 0)
                {
                    var source = match[0].Groups[1].Value;
                    var valueToShift = UInt16.Parse(match[0].Groups[2].Value);
                    var destination = match[0].Groups[3].Value;

                    var sourceWire = wires.FirstOrDefault(w => w.Name == source);

                    if (sourceWire is null || sourceWire.IsDone == false)
                    {
                        wires.Add(new Wire() { Name = destination, Depend1 = source, Input = valueToShift, ConnectionType = ConnectionType.RSHIFT });
                        continue;
                    }
                    var value = (ushort)(sourceWire.Value >> valueToShift);
                    wires.Add(new Wire() { Name = destination, Value = value, Depend1 = source, Input = valueToShift, ConnectionType = ConnectionType.RSHIFT, IsDone = true });
                    continue;
                }


                match = NOT.Matches(input);
                if (match.Count > 0)
                {
                    var source = match[0].Groups[1].Value;
                    var destination = match[0].Groups[2].Value;
                    var sourceWire = wires.FirstOrDefault(w => w.Name == source);

                    if (sourceWire is null || sourceWire.IsDone == false)
                    {
                        wires.Add(new Wire() { Name = destination, Depend1 = source, ConnectionType = ConnectionType.NOT });
                        continue;
                    }

                    var value = (ushort)~sourceWire.Value;
                    wires.Add(new Wire() { Name = destination, Value = value, Depend1 = source, ConnectionType = ConnectionType.NOT, IsDone = true });
                    continue;
                }

            }
            return wires;

        }


        public static void ConnectWires(List<Wire> wires)
        {
            foreach (var wire in wires)
            {
                if (wire.IsDone)
                    continue;

                try
                {
                    if (wire.Depend1 is null && wire.Depend2 is null)
                    {
                        UpdateWireValue(wires, wire);
                    }


                    if (wires.First(w => w.Name == wire.Depend1).IsDone && wire.Depend2 is null)
                    {
                        UpdateWireValue(wires, wire);
                    }

                    if (wires.First(w => w.Name == wire.Depend1).IsDone &&
                        (wire.Depend2 != null && wires.First(w => w.Name == wire.Depend2).IsDone))
                    {
                        UpdateWireValue(wires, wire);
                    }
                }
                catch (Exception)
                {
                    continue;
                }
            }
        }

        public static void SortWiresByDependency(List<Wire> wires)
        {
            wires.Shuffle();
        }


        public static void UpdateWireValue(List<Wire> wires, Wire wire)
        {
            var sourceWire1 = wires.FirstOrDefault(w => w.Name == wire.Depend1);
            var sourceWire2 = wires.FirstOrDefault(w => w.Name == wire.Depend2);

            switch (wire.ConnectionType)
            {
                case ConnectionType.SIGNALValue:
                    wire.Value = wire.Input;
                    wire.IsDone = true;
                    break;
                case ConnectionType.SIGNAL:
                    wire.Value = sourceWire1.Value;
                    wire.IsDone = true;
                    break;
                case ConnectionType.AND:
                    wire.Value = (UInt16)(sourceWire1.Value & sourceWire2.Value);
                    wire.IsDone = true;
                    break;
                case ConnectionType.OR:
                    wire.Value = (UInt16)(sourceWire1.Value | sourceWire2.Value);
                    wire.IsDone = true;
                    break;
                case ConnectionType.LSHIFT:
                    wire.Value = (ushort)(sourceWire1.Value << wire.Input);
                    wire.IsDone = true;
                    break;
                case ConnectionType.RSHIFT:
                    wire.Value = (ushort)(sourceWire1.Value >> wire.Input);
                    wire.IsDone = true;
                    break;
                case ConnectionType.NOT:
                    wire.Value = (ushort)~sourceWire1.Value;
                    wire.IsDone = true;
                    break;
                default:
                    break;
            }

        }

        public static int Part1(List<string> inputs)
        {
            var wires = GetInitialWireList(inputs);

            //foreach (var input in inputs)
            //{
            //    ConnectWires(input, wires);
            //}



            while (wires.Any(w => w.IsDone == false))
            {
                SortWiresByDependency(wires);
                ConnectWires(wires);
                var left = wires.Count(w => w.IsDone == false);
                Console.WriteLine($"Left: {left}");
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

            public UInt16 Input { get; set; }

            public ConnectionType ConnectionType { get; set; }
            public UInt16 Value { get; set; }
        }

        public enum ConnectionType
        {
            SIGNALValue,
            SIGNAL,
            AND,
            OR,
            LSHIFT,
            RSHIFT,
            NOT
        }



        private static Random rng = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }





    }
}
