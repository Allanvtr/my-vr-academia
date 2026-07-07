using Microsoft.CognitiveServices.Speech;
using VrAudioCena.WebApi.Infrastructure.Persistence;

namespace VrAudioCena.WebApi.Infrastructure.Services.Tts
{
    public class AzureTtsClient : ITextToSpeechService
    {
        private readonly IOperationRepository _operationRepository;
        private readonly string _speechKey;
        private readonly string _speechRegion;
        private static readonly Random Random = new();
        private static readonly string[] AvailableVoices =
        {
            "pt-BR-FranciscaNeural",
            "pt-BR-AntonioNeural",
            "pt-BR-BrendaNeural",
            "pt-BR-FabioNeural",
            "pt-BR-YaraNeural"
        };

        public AzureTtsClient(IOperationRepository operationRepository)
        {
            _operationRepository = operationRepository;

            _speechKey = Environment.GetEnvironmentVariable("AZURE_SPEECH_KEY")
                ?? throw new Exception("AZURE_SPEECH_KEY not found");

            _speechRegion = Environment.GetEnvironmentVariable("AZURE_SPEECH_REGION")
                ?? throw new Exception("AZURE_SPEECH_REGION not found");
        }


        public async Task<List<string>> ConvertTextToSpeechAsync(
            Guid operationId,
            CancellationToken cancellationToken)
        {
            var texts = _operationRepository.GetAiFeedback(operationId);

            if (texts == null || texts.Count == 0)
            {
                throw new Exception("AI feedback not found");
            }

            var audioFiles = new List<string>();

            for (int i = 0; i < texts.Count; i++)
            {
                var voice = AvailableVoices[
                    Random.Next(AvailableVoices.Length)
                ];

                var speechConfig = SpeechConfig.FromSubscription(
                    _speechKey,
                    _speechRegion
                );

                speechConfig.SpeechSynthesisVoiceName = voice;

                using var synthesizer = new SpeechSynthesizer(speechConfig);

                var result = await synthesizer.SpeakTextAsync(texts[i]);


                if (result.Reason != ResultReason.SynthesizingAudioCompleted)
                {
                    var cancellationDetails =
                        SpeechSynthesisCancellationDetails.FromResult(result);

                    throw new Exception(
                        $"Azure TTS error: {cancellationDetails.ErrorDetails}"
                    );
                }


                var directory = "audio";

                Directory.CreateDirectory(directory);


                var filePath = Path.Combine(
                    directory,
                    $"{operationId}_{i}.wav"
                );


                await File.WriteAllBytesAsync(
                    filePath,
                    result.AudioData,
                    cancellationToken
                );


                audioFiles.Add(filePath);
            }

            return audioFiles;
        }

    }
}