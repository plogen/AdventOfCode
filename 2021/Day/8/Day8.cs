using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace aoc2021
{
    public static class Day8
    {
     
        public static int Part1(List<string> input)
        {
            var rows = GetRows(input);
            return GetKnownNumberCountEasyMethod(rows);
        }


        public static int Part2(List<string> input)
        {
            var rows = GetRows(input);

            var segmentNumbers2 = GetInitialSegments(rows[1]);
            CompleteSegments(segmentNumbers2, rows[1]);

            foreach (var row in rows)
            {
                var segmentNumbers = GetInitialSegments(row);
                CompleteSegments(segmentNumbers, row);
            }

            return 0;
        }

        private static void CompleteSegments(SegmentNumber[] segments, Row row)
        {
            while (segments.Any(s => s.AllKnown == false))
            {
                //Already known partial segments from other SegmentNumbers
                foreach (var segment in segments.Where(s => s.AllKnown == false))
                {
                    foreach (var index in segment.SegmenstIndexesUsed)
                    {
                        var foundKnownSegment = segments.FirstOrDefault(s => s.KnownSegmentCharsPos.ContainsKey(index));
                        if(foundKnownSegment != null)
                            segment.KnownSegmentCharsPos.Add(index, foundKnownSegment.KnownSegmentCharsPos[index]);
                    }
                }
                var toChageKnowStatusOn = segments.Where(s => s.AllKnown == false && s.SegmentCount == s.KnownSegmentCharsPos.Count()).ToList();
                foreach (var item in toChageKnowStatusOn)
                {
                    item.AllKnown = true;
                }


                //Detailed specific mapping to help
                var posible069 = row.FourDigitOutputValues.Where(r => r.Length == 6);
                var matchWith1 = segments.FirstOrDefault(s => s.Number == 1).KnownSegmentCharsPos.Values.ToArray();
                var matchWith4 = segments.FirstOrDefault(s => s.Number == 4).KnownSegmentCharsPos.Values.ToArray();
                foreach (var posible in posible069)
                {
                    if (posible.All(c => matchWith1.Contains(c)))
                    {
                        segments.FirstOrDefault(s => s.Number == 0).SegmentChars = posible;
                    }

                    if (posible.All(c => matchWith4.Contains(c)))
                    {
                        segments.FirstOrDefault(s => s.Number == 9).SegmentChars = posible;
                    }
                }



            }
        }


        private static SegmentNumber[] GetInitialSegments(Row row)
        {
            SegmentNumber[] segments = new SegmentNumber[]
            {
                new SegmentNumber() { Number = 0, SegmentCount = 6, SegmenstIndexesUsed = new List<int> { 0, 1, 2, 4, 5, 6 } },
                new SegmentNumber() { Number = 1, SegmentCount = 2, SegmenstIndexesUsed = new List<int> { 2, 5 } },
                new SegmentNumber() { Number = 2, SegmentCount = 5, SegmenstIndexesUsed = new List<int> { 0,2,3,4,6 } },
                new SegmentNumber() { Number = 3, SegmentCount = 5, SegmenstIndexesUsed = new List<int> { 0,2,3,5,6 } },
                new SegmentNumber() { Number = 4, SegmentCount = 4, SegmenstIndexesUsed = new List<int> { 1,2,3,5 } },
                new SegmentNumber() { Number = 5, SegmentCount = 5, SegmenstIndexesUsed = new List<int> { 0,1,3,5,6 } },
                new SegmentNumber() { Number = 6, SegmentCount = 6, SegmenstIndexesUsed = new List<int> { 0,1,3,4,5,6 } },
                new SegmentNumber() { Number = 7, SegmentCount = 3, SegmenstIndexesUsed = new List<int> { 0,2,5 } },
                new SegmentNumber() { Number = 8, SegmentCount = 7, SegmenstIndexesUsed = new List<int> { 0,1,2,3,4,5,6 } },
                new SegmentNumber() { Number = 9, SegmentCount = 6, SegmenstIndexesUsed = new List<int> { 0,1,2,3,5,6 } }
            };


            for (int i = 0; i < row.FourDigitOutputValues.Count; i++)
            {
                if (row.FourDigitOutputValues[i].Length == 2) // 1
                {
                    var s = segments.FirstOrDefault(s => s.Number == 1);
                    if (s != null && s.AllKnown)
                        continue;

                    if(string.IsNullOrEmpty(s.SegmentChars))
                    {
                        s.SegmentChars = row.FourDigitOutputValues[i];
                    }
                }
                else if (row.FourDigitOutputValues[i].Length == 4) // 4
                {
                    var s = segments.FirstOrDefault(s => s.Number == 4);
                    if (s != null && s.AllKnown)
                        continue;

                    if (string.IsNullOrEmpty(s.SegmentChars))
                    {
                        s.SegmentChars = row.FourDigitOutputValues[i];
                    }
                }
                else if (row.FourDigitOutputValues[i].Length == 3) // 7
                {
                    var s = segments.FirstOrDefault(s => s.Number == 7);
                    if (s != null && s.AllKnown)
                        continue;

                    if (string.IsNullOrEmpty(s.SegmentChars))
                    {
                        s.SegmentChars = row.FourDigitOutputValues[i];
                    }
                }
                else if (row.FourDigitOutputValues[i].Length == 7) // 8
                {
                    var s = segments.FirstOrDefault(s => s.Number == 8);
                    if (s != null && s.AllKnown)
                        continue;

                    if (string.IsNullOrEmpty(s.SegmentChars))
                    {
                        s.SegmentChars = row.FourDigitOutputValues[i];
                    }
                }
            }
            return segments;
        }



        private static int GetKnownNumberCountEasyMethod(List<Row> rows)
        {
            int count = 0;
            foreach (var row in rows)
            {
                foreach (var outputValue in row.FourDigitOutputValues)
                {
                    if (outputValue.Length == 2) // 1
                        count++;
                    else if (outputValue.Length == 4) // 4
                        count++;
                    else if (outputValue.Length == 3) // 7
                        count++;
                    else if (outputValue.Length == 7) // 8
                        count++;
                }
            }
            return count;
        }

        private static List<Row> GetRows(List<string> input)
        {
            List<Row> rows = new List<Row>();
            foreach (var row in input)
            {
                var data = Regex.Matches(row, @"(\w+)").Select(x => x.ToString()).ToList();
                rows.Add(new Row()
                {
                    SignalPatterns = data.GetRange(0, 10),
                    FourDigitOutputValues = data.GetRange(10, 4)
                });
            }
            return rows;
        }


        public class SegmentNumber
        {
            public int Number { get; set; }
            public int SegmentCount { get; set; }
            public List<int> SegmenstIndexesUsed { get; set; }
            public string SegmentChars { get; set; }
            public Dictionary<int, char> KnownSegmentCharsPos { get; set; } = new Dictionary<int, char>();
            public bool AllKnown { get; set; } = false;

            /*
             0000
            1    2
            1    2
             3333
            4    5
            4    5
             6666
            */

            /*
             aaaa
            b    c
            b    c
             dddd
            e    f
            e    f
             gggg
            */
        }

        public class Row
        {
            public List<string> SignalPatterns { get; set; } = new List<string>();
            public List<string> FourDigitOutputValues { get; set; } = new List<string>();
            public List<SegmentNumber> SegmentNumbersOutput = new List<SegmentNumber>();
        }

    }
}
