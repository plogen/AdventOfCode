using Common;
using System.Text.RegularExpressions;

//Puzzle: https://adventofcode.com/2023/day/2
namespace aoc2023
{
    public class Day02: DayPuzzle
    {
        public static Regex gameIdRegex = new Regex(@"Game (\d+)");
        public static Regex redRegex = new Regex(@"(\d+)(?: red)");
        public static Regex greenRegex = new Regex(@"(\d+)(?: green)");
        public static Regex blueRegex = new Regex(@"(\d+)(?: blue)");
        public override object Part1(List<string> input)
        {
            var refFame = new Game(0, 12, 13, 14);
            List<Game> games = new();
            input.ForEach(x => games.Add(GetGame(x)));

            List<Game> gamesThatFit = new();
            foreach (var game in games)
            {
                if (GameFits(refFame, game))
                    gamesThatFit.Add(game);
            }
            
            return gamesThatFit.Select(g => g.gameId).Sum();
        }

        public override object Part2(List<string> input)
        {
            List<Game> games = new();
            input.ForEach(x => games.Add(GetGame(x)));
            return games.Select(g => g.red * g.green * g.blue).Sum();
        }

        private static Game GetGame(string input)
        {
             
            var gameId = gameIdRegex.Matches(input).Select(x => int.Parse(x.Groups[1].Value)).First();
            var red = redRegex.Matches(input).Select(x => int.Parse(x.Groups[1].Value)).Max();
            var green = greenRegex.Matches(input).Select(x => int.Parse(x.Groups[1].Value)).Max();
            var blue = blueRegex.Matches(input).Select(x => int.Parse(x.Groups[1].Value)).Max();
            return new Game(gameId, red, green, blue);
        }

        private bool GameFits(Game refGame, Game game)
        { 
            if(game.red > refGame.red)
                return false;
            if (game.green > refGame.green)
                return false;
            if (game.blue > refGame.blue)
                return false;

            return true; 
        }

        record Game(int gameId, int red, int green, int blue);
    }
}