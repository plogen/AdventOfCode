using System.Net;

namespace Common
{
    public static class FetchInput
    {

        static readonly HttpClient client = new HttpClient();

        public static async Task<byte[]> GetInputFromGitHub(int year, int day)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"https://google.com");
                //HttpResponseMessage response = await client.GetAsync($"https://adventofcode.com/{year}/day/{day}/input");
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsByteArrayAsync();
                return responseBody;
            }
            catch (HttpRequestException e)
            {
                return null;
            }
        }

    }
}