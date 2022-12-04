using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace aoc2022
{
    public static class Day04
    {

        public static Regex sectionsRegex = new Regex(@"(\d+)-(\d+),(\d+)-(\d+)");


        public static long Part1(List<string> input)
        {
            List<Section> sections = GetSections(input);
            return GetFullyContainedPairs(sections);
        }


        public static long Part2(List<string> input)
        {
            List<Section> sections = GetSections(input);
            return GetPartiallyOverlappingPairs(sections);
        }



        private static int GetFullyContainedPairs(List<Section> sections)
        {
            int fullyContainedPairs = 0;
            foreach (var section in sections)
            {
                if (section.StartA <= section.StartB &&
                    section.EndA >= section.EndB)
                {
                    fullyContainedPairs++;
                    continue;
                }

                if (section.StartB <= section.StartA &&
                    section.EndB >= section.EndA)
                {
                    fullyContainedPairs++;
                    continue;
                }

            }

            return fullyContainedPairs;
        }

        private static int GetPartiallyOverlappingPairs(List<Section> sections)
        {
            int partiallyContainedPairs = 0;
            foreach (var section in sections)
            {

                if (section.StartA >= section.StartB &&
                    section.StartA <= section.EndB)
                {
                    partiallyContainedPairs++;
                    continue;
                }

                if (section.StartA >= section.StartB &&
                    section.StartA <= section.EndB)
                {
                    partiallyContainedPairs++;
                    continue;
                }


                if (section.StartB >= section.StartA &&
                    section.StartB <= section.EndA)
                {
                    partiallyContainedPairs++;
                    continue;
                }

                if (section.StartB >= section.StartA &&
                    section.StartB <= section.EndA)
                {
                    partiallyContainedPairs++;
                    continue;
                }
            }

            return partiallyContainedPairs;
        }

        private static List<Section> GetSections(List<string> input)
        {
            List<Section> sections = new List<Section>();
            foreach (var section in input)
            {
                var match = sectionsRegex.Match(section);
                sections.Add(new Section()
                {
                    StartA = int.Parse(match.Groups[1].Value),
                    EndA = int.Parse(match.Groups[2].Value),
                    StartB = int.Parse(match.Groups[3].Value),
                    EndB = int.Parse(match.Groups[4].Value)
                });
            }

            return sections;
        }


        private class Section
        {
            public int StartA { get; set; }
            public int EndA { get; set; }

            public int StartB { get; set; }
            public int EndB { get; set; }
        }

    }
}
