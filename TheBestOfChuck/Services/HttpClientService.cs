using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using TheBestOfChuck.Models;

namespace TheBestOfChuck.Services
{
    public interface IHttpClientService
    {
        public Task<string> ReturnChuckJoke();
    }
    public class HttpClientService : IHttpClientService
    {
        private readonly ILogger _logger;
        private readonly HttpClient _httpClient;

        public HttpClientService(ILogger<HttpClientService> logger) 
        {
            _logger = logger;
            _httpClient = new HttpClient();
        }

        public async Task<string> ReturnChuckJoke()
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://matchilling-chuck-norris-jokes-v1.p.rapidapi.com/jokes/random"),
                Headers =
                {
                    { "accept", "application/json" },
                    { "X-RapidAPI-Key", Environment.GetEnvironmentVariable("API_KEY") },
                    { "X-RapidAPI-Host", "matchilling-chuck-norris-jokes-v1.p.rapidapi.com" },
                },
            };

            using (var response = await _httpClient.SendAsync(request))
            {
                _logger.LogInformation($"{DateTime.Now}|INFORMATION|Joke pull request executed");
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<ChuckNorrisRandomJokeModel>(body);

                return data.Value;
            }
        }


    }
}
