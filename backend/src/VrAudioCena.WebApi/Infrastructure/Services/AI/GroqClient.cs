using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace VrAudioCena.WebApi.Infrastructure.Services.AI
{
    public class GroqClient : IAIService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<GroqClient> _logger;

        public GroqClient(HttpClient httpClient, ILogger<GroqClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }
        public async Task<List<string>> ProcessPresentationAsync(string presentation)
        {
            var apiKey = Environment.GetEnvironmentVariable("GROQ_API_KEY");
            var groqModel = Environment.GetEnvironmentVariable("MODEL");

            _httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", apiKey);

            var request = new
            {
                model = groqModel,
                messages = new[]
                {
                    new
                    {
                        role = "user",
                        content = $@"
                            Você é um membro da plateia assistindo a uma apresentação acadêmica.

                            Com base exclusivamente na apresentação abaixo, gere exatamente 3 perguntas.

                            Regras:
                            - Gere exatamente 3 perguntas.
                            - As perguntas devem ser curtas, claras e objetivas.
                            - Não inclua respostas, explicações ou comentários.
                            - Não utilize numeração ou marcadores.
                            - Se alguma informação não estiver presente na apresentação, não invente fatos.

                            Retorne apenas um JSON válido, sem markdown e sem texto adicional, no seguinte formato:

                            {{
                            ""questions"": [
                                ""Pergunta 1"",
                                ""Pergunta 2"",
                                ""Pergunta 3""
                            ]
                            }}

                            Apresentação:

                            {presentation}"
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
            
            using var questionsJson = JsonDocument.Parse(mensagem!);

            var questions = questionsJson.RootElement
                .GetProperty("questions")
                .EnumerateArray()
                .Select(q => q.GetString()!)
                .ToList();
            
            return questions;
        }

    }
}