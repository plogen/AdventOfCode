using Common;
using System;
using System.Text;
using System.Text.RegularExpressions;

//Puzzle: https://adventofcode.com/2023/day/5
namespace aoc2023
{
    public class Day05 : DayPuzzle
    {
        public static Regex seedsRegex = new Regex(@"seeds:(?:\s(\d+))+");
        public static Regex mapRegex = new Regex(@"(\w+)-to-(\w+)");
        public static Regex dataRegex = new Regex(@"^(\d+)\s(\d+)\s(\d+)");

        public override object Part1(List<string> input)
        {
            var seeds = input[0].Substring(7).Split(' ').Select(v => long.Parse(v)).ToList();

            var maps = GetMaps(input);

            List<Tuple<string, string>> links = new List<Tuple<string, string>>()
            {
                //new Tuple<string, string>("seed", "soil"),
                new Tuple<string, string>("soil", "fertilizer"),
                new Tuple<string, string>("fertilizer", "water"),
                new Tuple<string, string>("water", "light"),
                new Tuple<string, string>("light", "temperature"),
                new Tuple<string, string>("temperature", "humidity"),
                new Tuple<string, string>("humidity", "location"),
            };

            List<long> locations = new();
            foreach (var seed in seeds)
            {
                var firstLink =
                        maps.FirstOrDefault(m =>
                            m.source == "seed" &&
                            m.destination == "soil" &&
                            m.sourceStart <= seed &&
                            m.sourceEnd >= seed);

                long firstDestination;
                if (firstLink != null)
                {
                    firstDestination = firstLink.destinationStart + (seed - firstLink.sourceStart);
                }
                else
                {
                    firstDestination = seed;
                }


                long destination = firstDestination;
                foreach (var link in links)
                {
                    var xxx = maps.FirstOrDefault(m =>
                                m.source == link.Item1 &&
                                m.destination == link.Item2 &&
                                m.sourceStart <= destination &&
                                m.sourceEnd >= destination);

                    if (xxx != null)
                    {
                        destination = xxx.destinationStart + (destination - xxx.sourceStart);
                    }
                    else
                    {
                        destination = destination;
                    }
                }

                locations.Add(destination);
            }

            return locations.Min();
        }

        public override object Part2(List<string> input)
        {
            throw new NotImplementedException();
        }



        private static List<Map> GetMaps(List<string> input)
        {
            List<Map> maps = new();
            string source = "";
            string destination = "";
            long destinationRangeStart;
            long sourceRangeStart;
            long rangeLength;
            foreach (var row in input)
            {
                var mapMatch = mapRegex.Match(row);
                if (mapMatch.Success)
                {
                    source = mapMatch.Groups[1].Value;
                    destination = mapMatch.Groups[2].Value;
                    continue;
                }

                var dataMatch = dataRegex.Match(row);
                if (dataMatch.Success)
                {
                    destinationRangeStart = long.Parse(dataMatch.Groups[1].Value);
                    sourceRangeStart = long.Parse(dataMatch.Groups[2].Value);
                    rangeLength = long.Parse(dataMatch.Groups[3].Value);
                    maps.Add(new Map(source, destination, sourceRangeStart, sourceRangeStart + rangeLength, destinationRangeStart, destinationRangeStart + rangeLength));
                }
            }
            return maps;
        }


        private record Map(string source, string destination, long sourceStart, long sourceEnd, long destinationStart, long destinationEnd);


    }
}