using Common;
using Microsoft.VisualBasic;
using static System.Net.Mime.MediaTypeNames;

//Puzzle: https://adventofcode.com/2023/day/7
namespace aoc2023
{
    public class Day07 : DayPuzzle
    {
        public override object Part1(List<string> input)
        {

            var hands = input.Select(x => new Hand() { Cards = x.Substring(0, 5), Bid = int.Parse(x.Substring(6)) }).ToList();
            hands.ForEach(x => SetHandType(x));
            var sortedHandGroups = hands
                                    .GroupBy(x => x.Type)
                                    .OrderBy(x => x.Key)
                                    .ToList();

            int lastRank = 0;
            foreach (var handTypeGroup in sortedHandGroups)
            {

                var handsInGroup = handTypeGroup.Select(x => x).ToList();

                try
                {
                    handsInGroup.Sort((a, b) => GetHandStrength(a, b));
                }
                catch (ArgumentException)
                {
                }
                
                foreach (var hand in handsInGroup)
                {
                    lastRank++;
                    hand.Rank = lastRank;
                }

            }

            
            long totalWinnings = 0;
            foreach (var handTypeGroup in sortedHandGroups)
            {
                foreach (var hand in handTypeGroup)
                {
                    totalWinnings += hand.Bid * hand.Rank;
                }
            }


            return totalWinnings;

        }

        public override object Part2(List<string> input)
        {
            throw new NotImplementedException();
        }

        private class Hand()
        {
            public string Cards { get; set; }
            public int Bid { get; set; }
            public HandType Type { get; set; }
            public int Rank { get; set; }
        }

        private static int GetHandStrength(Hand handA, Hand handB)
        {
            for (int i = 0; i < 5; i++)
            {
                if (GetCardStrenght(handA.Cards[i]) > GetCardStrenght(handB.Cards[i]))
                    return 1;
                if (GetCardStrenght(handA.Cards[i]) < GetCardStrenght(handB.Cards[i]))
                    return -1;
            }
            return 0;
        }

        private static int GetCardStrenght(char card)
        {
            switch (card)
            {
                case 'A':
                    return 14;
                    break;
                case 'K':
                    return 13;
                    break;
                case 'Q':
                    return 12;
                    break;
                case 'J':
                    return 11;
                    break;
                case 'T':
                    return 10;
                    break;
                default:
                    return card - 48;
            }
        }


        private static void SetHandType(Hand hand)
        {
            var cards = GetCardCount(hand.Cards);
            var orderedCards = cards.OrderByDescending(c => c.Value);

            if (orderedCards.First().Value == 5)
            {
                hand.Type = HandType.FiveOfKind;
                return;
            }
            else if (orderedCards.First().Value == 4)
            {
                hand.Type = HandType.FourOfKind;
                return;
            }
            else if (orderedCards.First().Value == 3 && orderedCards.Skip(1).First().Value == 2)
            {
                hand.Type = HandType.FullHouse;
                return;
            }
            else if (orderedCards.First().Value == 3)
            {
                hand.Type = HandType.ThreeOfKind;
                return;
            }
            else if (orderedCards.First().Value == 2 && orderedCards.Skip(1).First().Value == 2)
            {
                hand.Type = HandType.TwoPair;
                return;
            }
            else if (orderedCards.First().Value == 2)
            {
                hand.Type = HandType.OnePair;
                return;
            }
            else
            {
                hand.Type = HandType.HighCard;
                return;
            }
        }


        private static Dictionary<char, int> GetCardCount(string cards)
        {

            Dictionary<char, int> dict = new();
            foreach (var card in cards)
            {
                if (dict.ContainsKey(card))
                {
                    dict[card]++;
                }
                else
                {
                    dict.Add(card, 1);
                }
            }
            return dict;
        }

        private enum HandType
        {
            HighCard,
            OnePair,
            TwoPair,
            ThreeOfKind,
            FullHouse,
            FourOfKind,
            FiveOfKind
        }

        private static char[] CardType = new char[]
        {
            //'A', 'K', 'Q', 'J', 'T', '9', '8', '7', '6', '5', '4', '3', '2'
            '2','3','4','5','6','7','8','9','T','J','Q','K','A'
        };
    }
}