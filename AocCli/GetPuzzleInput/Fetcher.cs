using Common;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AocCli.GetPuzzleInput
{
    public static class AocService
    {
        public static async Task<string> GetDayInputAsync(int year, int day)
        {
            ValidRequest(year, day);
            try
            {
                var response = await client.GetAsync($"{year}/day/{day}/input");
                return await response.EnsureSuccessStatusCode().Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error in fetching puzzle data");
                throw;
            }
        }


        private static HttpClientHandler handler = new HttpClientHandler
        {
            CookieContainer = GetCookieContainer(),
            UseCookies = true,
        };

        private static HttpClient client = new HttpClient(handler)
        {
            BaseAddress = new Uri("https://adventofcode.com/"),
        };

        private static CookieContainer GetCookieContainer()
        {
            CookieContainer cookieContainer = new();
            cookieContainer.Add(new Cookie
            {
                Name = "session",
                Domain = ".adventofcode.com",
                Value = GetSessionCoocke(),
            });
            return cookieContainer;
        }

        private static string GetSessionCoocke()
        {
            string solutionDir = Helper.GetSolutionDir();
            var fullFileName = Path.Combine(solutionDir, "sessionCookie.txt");

            string lineData = string.Empty;
            try
            {
                using (var sr = new StreamReader(fullFileName))
                {
                    lineData = sr.ReadLine();
                }
            }
            catch (IOException)
            {
                throw new Exception("error in parsing");
            }

            return lineData;
        }


        private static void ValidRequest(int year, int day)
        {
            //Puzzles will unlock at midnight EST (UTC-5).
            var estNow = DateTime.UtcNow.AddHours(-5);
            if (estNow < new DateTime(year, 12, day))
            {
                var error = $"You have requested Puzzle input for {year}-12-{day} to early.";
                var ex = new InvalidOperationException(error);
                Log.Error(ex, error);
                throw ex;
            }
                
        }


    }
}
