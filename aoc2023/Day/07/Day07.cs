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
            hands.ForEach(x => SetHandType(x, false));
            var sortedHandGroups = hands
                                    .GroupBy(x => x.Type)
                                    .OrderBy(x => x.Key)
                                    .ToList();

            int lastRank = 0;
            foreach (var handTypeGroup in sortedHandGroups)
            {
                var handsInGroup = handTypeGroup.Select(x => x).ToList();
                handsInGroup.Sort((a, b) => GetHandStrength(a, b, false));

                foreach (var hand in handsInGroup)
                {
                    lastRank++;
                    hand.Rank = lastRank;
                }
            }

            return GetTotalWinnings(sortedHandGroups);
        }


        public override object Part2(List<string> input)
        {
            var hands = input.Select(x => new Hand() { Cards = x.Substring(0, 5), Bid = int.Parse(x.Substring(6)) }).ToList();
            hands.ForEach(x => SetHandType(x, true));
            var sortedHandGroups = hands
                                    .GroupBy(x => x.Type)
                                    .OrderBy(x => x.Key)
                                    .ToList();

            int lastRank = 0;
            foreach (var handTypeGroup in sortedHandGroups)
            {
                var handsInGroup = handTypeGroup.Select(x => x).ToList();
                handsInGroup.Sort((a, b) => GetHandStrength(a, b, true));

                foreach (var hand in handsInGroup)
                {
                    lastRank++;
                    hand.Rank = lastRank;
                }
            }

            return GetTotalWinnings(sortedHandGroups);
        }



        private static long GetTotalWinnings(List<IGrouping<HandType, Hand>> sortedHandGroups)
        {
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

        private class Hand()
        {
            public string Cards { get; set; }
            public int Bid { get; set; }
            public HandType Type { get; set; }
            public int Rank { get; set; }
        }

        private static int GetHandStrength(Hand handA, Hand handB, bool jokerIsActive)
        {
            for (int i = 0; i < 5; i++)
            {
                if (GetCardStrenght(handA.Cards[i], jokerIsActive) > GetCardStrenght(handB.Cards[i], jokerIsActive))
                    return 1;
                if (GetCardStrenght(handA.Cards[i], jokerIsActive) < GetCardStrenght(handB.Cards[i], jokerIsActive))
                    return -1;
            }
            return 0;
        }

        private static int GetCardStrenght(char card, bool jokerIsActive)
        {
            switch (card)
            {
                case 'A':
                    return 14;
                case 'K':
                    return 13;
                case 'Q':
                    return 12;
                case 'J':
                    if (jokerIsActive)
                        return 1;
                    else
                        return 11;
                case 'T':
                    return 10;
                default:
                    return card - 48;
            }
        }


        private static void SetHandType(Hand hand, bool jokerIsActive)
        {
            var cards = GetCardCount(hand.Cards);
            var orderedCards = cards.OrderByDescending(c => c.Value);

            var jokers = 0;
            if(jokerIsActive)
                jokers = orderedCards.FirstOrDefault(c => c.Key == 'J').Value;

            if ((orderedCards.First().Value + jokers) == 5)
            {
                hand.Type = HandType.FiveOfKind;
                return;
            }
            else if ((orderedCards.First().Value + jokers) == 4)
            {
                hand.Type = HandType.FourOfKind;
                return;
            }
            else if ((orderedCards.First().Value + jokers) == 3 && orderedCards.Skip(1).First().Value == 2)
            {
                hand.Type = HandType.FullHouse;
                return;
            }
            else if ((orderedCards.First().Value + jokers) == 3)
            {
                hand.Type = HandType.ThreeOfKind;
                return;
            }
            else if ((orderedCards.First().Value + jokers) == 2 && orderedCards.Skip(1).First().Value == 2)
            {
                hand.Type = HandType.TwoPair;
                return;
            }
            else if ((orderedCards.First().Value + jokers) == 2)
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