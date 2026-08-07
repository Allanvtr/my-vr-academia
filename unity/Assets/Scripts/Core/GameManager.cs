using System;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Cronometro cronometro;

    private readonly BackendService backend = new();
    
    public SignalRService signalR = new();

    private GameConfig config;

    [SerializeField] private AudioSource audioSource;

    async void Start()
    {
        config = AndroidIntentReader.GetConfig();

        Debug.Log($"OperationId: {config.OperacaoId}");
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
            status =
                await backend.BuscarStatus(config.OperacaoId);

            Debug.Log($"[CONEXAO] Status: {status.status}");
        }
        catch (Exception ex)
        {
            Debug.LogError("[CONEXAO] Erro Requisição " + ex.Message);
        }

        signalR.AudioGenerated += ReceiveAudio;

        if (status?.status == "Completed")
        {
            // baixar o aúdio
        }
        else
        {
            Debug.Log("[CONEXAO] Indo para signalR");
            await signalR.ConnectAsync();
        }


        //await signalR.Disconnect();

    }

    public async void ReceiveAudio(List<string> audios)
    {
        Debug.Log("Quantidade de áudios: " + audios.Count);

        for (int i = 0; i < audios.Count; i++)
        {
            Debug.Log($"Baixando áudio {i}");

            AudioClip clip = await backend.DownloadAudio(audios[i]);

            while (cronometro.GetTime() != 0)
            {
                Debug.Log($"Tocando áudio {i}");

                audioSource.clip = clip;
                audioSource.Play();

                while (audioSource.isPlaying)
                {
                    await Task.Yield();
                }
            }
        }

        Debug.Log("Todos os áudios terminaram");
    }

    private void Update()
    {
        
    }
}