using Common;
using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;

//Puzzle: https://adventofcode.com/2023/day/4
namespace aoc2023
{
    public class Day04: DayPuzzle
    {
        public static Regex cardNumberRegex = new Regex(@"Card\s+(\d+):");
        public static Regex numbersRegex = new Regex(@"(\d+)");
        public static Regex pickedNumbersRegex = new Regex(@".+\|(?:\s+(\d+))+");

        public override object Part1(List<string> input)
        {
            var cards = input.Select(i => GetCard(i)).ToList();

            double totalPoints = 0;
            foreach (var card in cards)
            {
                int points = card.pickedNumbers.Select(p => card.winningNumbers.Contains(p) ? 1 : 0).Sum();
                if(points > 0)
                    totalPoints += Math.Pow(2, points - 1);
            }
            return totalPoints;
        }

        public override object Part2(List<string> input)
        {
            var cards = input.Select(i => GetCard(i)).ToList();
            var cardCounts = cards.Select(_ => 1).ToArray(); // Initial cards shall be counted
            for (int i = 0; i < cards.Count; i++)
            {
                int points = cards[i].pickedNumbers.Select(p => cards[i].winningNumbers.Contains(p) ? 1 : 0).Sum();
                if (points > 0)
                {
                    for (int j = 1; j <= points; j++)
                    {
                        cardCounts[i + j] += cardCounts[i];
                    }
                }
            }
            return cardCounts.Sum();
        }

        private static Card GetCard(string input)
        {
            var cardNumber = int.Parse(cardNumberRegex.Match(input).Groups[1].Value);
            var parts = input.Split(':', '|');
            var winningNumbers = numbersRegex.Matches(parts[1]).Select(n => int.Parse(n.Groups[1].Value)).ToList();
            var pickedNumbers = numbersRegex.Matches(parts[2]).Select(n => int.Parse(n.Groups[1].Value)).ToList();
            return new Card(cardNumber, winningNumbers, pickedNumbers);
        }

        private record Card(int cardNumber, List<int> winningNumbers, List<int> pickedNumbers);
    }
}