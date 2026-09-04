using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Cronometro cronometro;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private float tempoResposta = 5f;

    private readonly BackendService backend = new();

    public SignalRService signalR = new();

    private GameConfig config;

    private List<AudioClip> perguntas = new();

    private GazeAnimation[] personagens;

    private bool esperandoPergunta = false;
    private bool processandoPergunta = false;

    async void Start()
    {
        personagens = FindObjectsByType<GazeAnimation>(
            FindObjectsSortMode.None
        );

        config = AndroidIntentReader.GetConfig();

        Debug.Log($"OperationId: {config.OperationId}");
        Debug.Log($"Tempo: {config.Tempo}");
        Debug.Log($"Fase: {config.Fase}");

        if (config.Tempo <= 0)
        {
            cronometro.SetTime(10);
        }
        else
        {
            cronometro.SetTime(config.Tempo);
        }

        StatusResponse status = null;

        try
        {
            status = await backend.BuscarStatus(config.OperationId);

            Debug.Log(
                $"[CONEXAO] Status: {status.status}"
            );
        }
        catch (Exception ex)
        {
            Debug.LogError(
                "[CONEXAO] Erro Requisição " + ex.Message
            );
        }

        signalR.AudioGenerated += OnAudioGenerated;

        if (status?.status == "Completed")
        {
            Debug.Log(
                $"[REQUISICAO] ID: {status.operationId}, " +
                $"Status: {status.status}"
            );

            await ReceberPerguntas(status.audioUrl);

            IniciarFluxoPerguntas();
        }
        else
        {
            Debug.Log("[CONEXAO] Indo para SignalR");

            await signalR.ConnectAsync();
        }
    }

    private async void OnAudioGenerated(List<string> audios)
    {
        await ReceberPerguntas(audios);

        IniciarFluxoPerguntas();
    }

    private async Task ReceberPerguntas(List<string> audios)
    {
        perguntas.Clear();

        for (int i = 0; i < audios.Count; i++)
        {
            Debug.Log(
                $"[AUDIO] Baixando pergunta {i}: {audios[i]}"
            );

            AudioClip clip =
                await backend.DownloadAudio(audios[i]);

            perguntas.Add(clip);

            Debug.Log(
                $"[AUDIO] Pergunta {i} baixada"
            );
        }

        Debug.Log(
            $"[AUDIO] Total de perguntas: {perguntas.Count}"
        );
    }

    private void IniciarFluxoPerguntas()
    {
        Debug.Log("[GAME] Perguntas prontas.");

        // A apresentação continua normalmente.
        // Quando o cronômetro chegar a zero,
        // o Update() iniciará as perguntas.
    }

    private void Update()
    {
        if (processandoPergunta)
            return;

        if (esperandoPergunta)
            return;

        if (perguntas.Count == 0)
            return;

        if (cronometro.Terminou())
        {
            AtivarProximaRodada();
        }
    }

    private void AtivarProximaRodada()
    {
        esperandoPergunta = true;

        Debug.Log("[GAME] Tempo acabou!");
        Debug.Log("[GAME] Personagens levantando a mão...");

        foreach (GazeAnimation personagem in personagens)
        {
            if (!personagem.TemPergunta())
                continue;

            int index = personagem.PerguntaIndex;

            if (index < 0 || index >= perguntas.Count)
                continue;

            personagem.LevantarMao();
        }
    }

    public async void SelecionarPersonagem(GazeAnimation personagem)
    {
        if (processandoPergunta)
            return;

        if (!esperandoPergunta)
            return;

        if (!personagem.TemPergunta())
            return;

        int index = personagem.PerguntaIndex;

        if (index < 0 || index >= perguntas.Count)
        {
            Debug.LogError(
                $"Pergunta inválida: {index}"
            );

            return;
        }

        processandoPergunta = true;
        esperandoPergunta = false;

        Debug.Log($"[GAME] Personagem selecionado: {personagem.name}");
        Debug.Log($"[GAME] Personagem index: {index}");

        personagem.BaixarMao();
        personagem.MarcarComoRespondida();

        AudioClip audio = perguntas[index];

        await TocarAudio(audio);

        if (TodasPerguntasRespondidas())
        {
            FinalizarPerguntas();
            return;
        }

        Debug.Log(
            "[GAME] Iniciando tempo de resposta: 20 segundos"
        );

        cronometro.Resetar(tempoResposta);

        processandoPergunta = false;
    }

    private async Task TocarAudio(AudioClip audio)
    {
        if (audio == null)
        {
            Debug.LogError("[AUDIO] AudioClip nulo!");
            return;
        }

        audioSource.clip = audio;
        audioSource.Play();

        Debug.Log("[AUDIO] Tocando pergunta...");

        while (audioSource.isPlaying)
        {
            await Task.Yield();
        }

        Debug.Log("[AUDIO] Pergunta terminou.");
    }

    private bool TodasPerguntasRespondidas()
    {
        foreach (GazeAnimation personagem in personagens)
        {
            if (personagem.TemPergunta())
                return false;
        }

        return true;
    }

    private void FinalizarPerguntas()
    {
        Debug.Log("[GAME] Não existem mais perguntas.");

        cronometro.Parar();

        processandoPergunta = false;
        esperandoPergunta = false;

        _ = signalR.Disconnect();
    }
}