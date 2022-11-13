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
using static aoc2015.Day09;
using MoreLinq;

namespace aoc2015
{
    public static class Day14
    {

        public static Regex reindeerRegex = new Regex(@"(\w+) can fly (\d+) km/s for (\d+) seconds, but then must rest for (\d+)");

        public static int Part1(List<string> inputs, int duration)
        {
            var reindeers = GetReindeers(inputs);

            foreach (var reindeer in reindeers)
            {
                UpdateTraveled(reindeer, duration);
            }

            return reindeers.OrderByDescending(r => r.Traveled).First().Traveled;
        }

        public static int Part2(List<string> inputs, int duration)
        {
            var reindeers = GetReindeers(inputs);

            StartTheRace(reindeers);

            for (int i = 0; i < duration; i++)
            {
                foreach (var reindeer in reindeers)
                {
                    UpdateRace(reindeer);
                }
                GiveLeaderExtraPoints(reindeers);
            }

            return reindeers.OrderByDescending(r => r.Points).First().Points;
        }

        private static void UpdateTraveled(Reindeer reindeer, int durationInSeconds)
        {
            bool durationReached = false;
            int duration = 0;
            while (durationReached == false)
            {
                if (reindeer.FlightDuration <= durationInSeconds - duration)
                {
                    reindeer.Traveled += reindeer.FlightDuration * reindeer.FlightSpeed;
                    duration += reindeer.FlightDuration;
                    duration += reindeer.RestDuration;

                }
                else
                {
                    var secondsLeftToFly = durationInSeconds - duration;
                    reindeer.Traveled += secondsLeftToFly * reindeer.FlightSpeed;
                    duration += secondsLeftToFly;

                }

                if(duration >= durationInSeconds)
                    durationReached = true;
            }
        }



        private static void StartTheRace(List<Reindeer> reindeers)
        {
            foreach (var reindeer in reindeers)
            {
                reindeer.IsFlying = true;
                reindeer.DurationLeft = reindeer.FlightDuration;
            }
        }

        private static void UpdateRace(Reindeer reindeer)
        {
            if(reindeer.IsFlying)
            {
                reindeer.Traveled += reindeer.FlightSpeed;
            }

            reindeer.DurationLeft--;

            if(reindeer.DurationLeft == 0)
            {
                reindeer.IsFlying = !reindeer.IsFlying;

                if(reindeer.IsFlying)
                    reindeer.DurationLeft = reindeer.FlightDuration;
                else
                    reindeer.DurationLeft = reindeer.RestDuration;
            }
        }

        private static void GiveLeaderExtraPoints(List<Reindeer> reindeers)
        {
            var leadingTracelDistance = reindeers.OrderByDescending(r => r.Traveled).First().Traveled;
            reindeers.Where(r => r.Traveled == leadingTracelDistance)
                        .ForEach(r => r.Points++);
        }




        private class Reindeer
        {
            public string Name { get; set; }
            public int FlightSpeed { get; set; }
            public int FlightDuration { get; set; }
            public int RestDuration { get; set; }

            public int Traveled { get; set; }
            public bool IsFlying { get; set; } = true;
            public int DurationLeft { get; set; }
            public int Points { get; set; }
        }


        private static List<Reindeer> GetReindeers(List<string> inputs)
        {
            var reindeers = new List<Reindeer>();

            inputs.ForEach(x =>
            {
                var match = reindeerRegex.Match(x);
                reindeers.Add(new Reindeer
                {
                    Name = match.Groups[1].Value,
                    FlightSpeed = int.Parse(match.Groups[2].Value),
                    FlightDuration = int.Parse(match.Groups[3].Value),
                    RestDuration = int.Parse(match.Groups[4].Value)
                });
            });

            return reindeers;
        }




    }
}
