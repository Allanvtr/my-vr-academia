using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace VrAudioCena.WebApi.Infrastructure.Services.AI
{
    public class GroqClient : IAIService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<GroqClient> _logger;

        private readonly string _apiKey;
        private readonly string _model;

        public GroqClient(
            HttpClient httpClient,
            ILogger<GroqClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;

            _apiKey = Environment.GetEnvironmentVariable("GROQ_API_KEY")
                ?? throw new Exception("GROQ_API_KEY not found");

            _model = Environment.GetEnvironmentVariable("MODEL")
                ?? throw new Exception("MODEL not found");
        }


        public async Task<List<string>> ProcessPresentationAsync(string presentation, int questionCount)
        {
            var request = new
            {
                model = _model,
                messages = new[]
                {
                    new
                    {
                        role = "user",
                        content = $@"
                            Você é um membro da plateia assistindo a uma apresentação acadêmica.

                            Com base exclusivamente na apresentação abaixo, gere exatamente 3 perguntas.

                            Regras:
                            - Gere exatamente {questionCount} perguntas.
                            - As perguntas devem ser curtas, claras e objetivas.
                            - Não inclua respostas, explicações ou comentários.
                            - Não utilize numeração ou marcadores.
                            - Se alguma informação não estiver presente na apresentação, não invente fatos.

                            Retorne apenas um JSON válido, sem markdown e sem texto adicional, no seguinte formato de acordo com o número de perguntas solicitado:

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


            var httpRequest = new HttpRequestMessage(
                HttpMethod.Post,
                "https://api.groq.com/openai/v1/chat/completions"
            );


            httpRequest.Headers.Authorization =
                new AuthenticationHeaderValue("Bearer", _apiKey);


            httpRequest.Content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json"
            );


            var response = await _httpClient.SendAsync(httpRequest);

            response.EnsureSuccessStatusCode();


            var body = await response.Content.ReadAsStringAsync();


            using var jsonDoc = JsonDocument.Parse(body);


            var message = jsonDoc.RootElement
                .GetProperty("choices")[0]
                .GetProperty("message")
                .GetProperty("content")
                .GetString();


            if (string.IsNullOrWhiteSpace(message))
            {
                throw new Exception("AI returned an empty response");
            }


            using var questionsJson = JsonDocument.Parse(message);


            return questionsJson.RootElement
                .GetProperty("questions")
                .EnumerateArray()
                .Select(q => q.GetString()!)
                .ToList();
        }
    }
}