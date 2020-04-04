using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace whatismyip
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        private const string API_URL = "https://api.ipify.org?format=json";

        static async Task Main(string[] args)
        {
            Stream responseStream = await client.GetStreamAsync(API_URL);
            ServiceResponse response = await JsonSerializer.DeserializeAsync<ServiceResponse>(responseStream);

            Console.WriteLine($"Your IP address is {response.ip}");
        }
    }
}
