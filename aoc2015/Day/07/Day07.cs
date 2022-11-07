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
        public static Regex ANDValue = new Regex(@"(\d+)\sAND\s([a-zA-Z]+) -> ([a-zA-Z]+)");
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
                    wires.Add(new Wire() { Name = destination, Value = value, Input = value, ConnectionType = ConnectionType.SIGNALValue, IsDone = true });
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

                match = ANDValue.Matches(input);
                if (match.Count > 0)
                {
                    var source1 = UInt16.Parse(match[0].Groups[1].Value);
                    var source2 = match[0].Groups[2].Value;
                    var destination = match[0].Groups[3].Value;

                    var sourceWire2 = wires.FirstOrDefault(w => w.Name == source2);
                    var destinationWire = wires.FirstOrDefault(w => w.Name == destination);

                    if (sourceWire2 is null || sourceWire2.IsDone == false)
                    {
                        wires.Add(new Wire() { Name = destination, Depend2 = source2, Input = source1, ConnectionType = ConnectionType.ANDValue });
                        continue;
                    }

                    UInt16 value = (UInt16)(source1 & sourceWire2.Value);
                    wires.Add(new Wire() { Name = destination, Value = value, Depend2 = source2, Input = source1, ConnectionType = ConnectionType.ANDValue, IsDone = true });
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

        public static void SortWiresByDependency(List<Wire> wires)
        {
            List<Tuple<string, string>> tuples= new List<Tuple<string, string>>();
            List<string> nodes = new List<string>();
            foreach (var wire in wires)
            {
                bool Depend1OK = true;
                if (wire.Depend1 != null && wires.First(w => w.Name == wire.Depend1).IsDone == false)
                    Depend1OK = false;

                bool Depend2OK = true;
                if (wire.Depend2 != null && wires.First(w => w.Name == wire.Depend2).IsDone == false)
                    Depend2OK = false;

                if(Depend1OK && Depend2OK)
                {
                    if (Depend1OK && wire.Depend1 != null)
                        tuples.Add(Tuple.Create(wire.Name, wire.Depend1));
                    if (Depend2OK && wire.Depend2 != null)
                        tuples.Add(Tuple.Create(wire.Name, wire.Depend2));

                    nodes.Add(wire.Name);
                }

            }


            var ret = TopologicalSort(
                new HashSet<string>(nodes.ToArray()),
                new HashSet<Tuple<string, string>>(
                    tuples
                )
            );

            foreach (var wireName in ret) {
                UpdateWireValue(wires, wires.First(w => w.Name == wireName));
            }


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
                case ConnectionType.ANDValue:
                    wire.Value = (UInt16)(wire.Input & sourceWire2.Value);
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

        public static List<Wire> Part1(List<string> inputs)
        {
            var wires = GetInitialWireList(inputs);
            while (wires.Any(w => w.IsDone == false))
            {
                SortWiresByDependency(wires);
            }

            return wires;
        }

        public static int Part2(List<string> inputs)
        {
            var wires = GetInitialWireList(inputs);
            while (wires.Any(w => w.IsDone == false))
            {
                SortWiresByDependency(wires);
            }

            var aValue = wires.First(w => w.Name == "a").Value;

            //Reset
            wires = GetInitialWireList(inputs);
            //Change
            wires.First(w => w.Name == "b").Value = aValue;
            wires.First(w => w.Name == "b").Input = aValue;

            //Recalculate
            while (wires.Any(w => w.IsDone == false))
            {
                SortWiresByDependency(wires);
            }

            return wires.First(w => w.Name == "a").Value;
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
            ANDValue,
            OR,
            LSHIFT,
            RSHIFT,
            NOT
        }



        /// <summary>
        /// Topological Sorting (Kahn's algorithm) 
        /// </summary>
        /// <remarks>https://en.wikipedia.org/wiki/Topological_sorting</remarks>
        /// <typeparam name="T"></typeparam>
        /// <param name="nodes">All nodes of directed acyclic graph.</param>
        /// <param name="edges">All edges of directed acyclic graph.</param>
        /// <returns>Sorted node in topological order.</returns>
        static List<T> TopologicalSort<T>(HashSet<T> nodes, HashSet<Tuple<T, T>> edges) where T : IEquatable<T>
        {
            // Empty list that will contain the sorted elements
            var L = new List<T>();

            // Set of all nodes with no incoming edges
            var S = new HashSet<T>(nodes.Where(n => edges.All(e => e.Item2.Equals(n) == false)));

            // while S is non-empty do
            while (S.Any())
            {

                //  remove a node n from S
                var n = S.First();
                S.Remove(n);

                // add n to tail of L
                L.Add(n);

                // for each node m with an edge e from n to m do
                foreach (var e in edges.Where(e => e.Item1.Equals(n)).ToList())
                {
                    var m = e.Item2;

                    // remove edge e from the graph
                    edges.Remove(e);

                    // if m has no other incoming edges then
                    if (edges.All(me => me.Item2.Equals(m) == false))
                    {
                        // insert m into S
                        S.Add(m);
                    }
                }
            }

            // if graph has edges then
            if (edges.Any())
            {
                // return error (graph has at least one cycle)
                return null;
            }
            else
            {
                // return L (a topologically sorted order)
                return L;
            }
        }





    }
}
