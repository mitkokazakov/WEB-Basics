using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ReadBasicRecepies
{
    class StartUp
    {
        static async Task Main(string[] args)
        {
            await ReadSomeText();
        }

        static async Task ReadSomeText()
        {
            string url = $"https://vicove.com/vic-62573";

            HttpClient httpClient = new HttpClient();

            var response = await httpClient.GetAsync(url);

            var result = await response.Content.ReadAsStringAsync();

            Console.WriteLine(result);
        }
    }
}
