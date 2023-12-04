using Common;
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
            throw new NotImplementedException();
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