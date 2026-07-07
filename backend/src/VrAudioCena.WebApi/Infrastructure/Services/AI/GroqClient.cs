using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace VrAudioCena.WebApi.Infrastructure.Services.AI
{
    public class GroqClient : IAIService
    {
        private readonly HttpClient _httpClient;

        public GroqClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<string>> ProcessPresentationAsync(string presentation)
        {
            var apiKey = Environment.GetEnvironmentVariable("GROQ_API_KEY");
            var model = Environment.GetEnvironmentVariable("MODEL");

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", apiKey);

            var request = new
            {
                model = "llama-3.3-70b-versatile",
                messages = new[]
                {
                    new
                    {
                        role = "user",
                        content = presentation
                    }
                }
            };

            var json = JsonSerializer.Serialize(request);

            var response = await _httpClient.PostAsync(
                "https://api.groq.com/openai/v1/chat/completions",
                new StringContent(json, Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadAsStringAsync();

            var jsonDoc = JsonDocument.Parse(body);

            var mensagem =
                jsonDoc.RootElement
                    .GetProperty("choices")[0]
                    .GetProperty("message")
                    .GetProperty("content")
                    .GetString();

            return new List<string> { mensagem ?? string.Empty };
        }

    }
}