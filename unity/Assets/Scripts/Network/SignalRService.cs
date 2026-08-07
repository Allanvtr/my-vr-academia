using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class SignalRService
{
    private HubConnection connection;
    public event Action<List<string>> AudioGenerated;

    public async Task ConnectAsync(/*Guid operationId*/)
    {
        try
        {
            var builder = new HubConnectionBuilder();
            Debug.Log("[CONEXAO]Builder OK");

            builder = (HubConnectionBuilder)builder.WithUrl("https://starring-purse-blabber.ngrok-free.dev/sceneHub");
            Debug.Log("[CONEXAO]WithUrl OK");

            var hubType = typeof(HubConnection);
            Debug.Log("[CONEXAO] Tipo carregado: " + hubType.Assembly.FullName);

            try
            {
                connection = builder.Build();
                Debug.Log("[CONEXAO]Build OK");
            }
            catch (Exception ex)
            {
                Debug.LogError("[CONEXAO]" + (ex.ToString()));
            }
        }
        catch (Exception ex)
        {
            Debug.LogError("[CONEXAO] Erro no Build");
            Debug.LogError("[CONEXAO] Mensagem: " + ex.Message);
            Debug.LogError("[CONEXAO] Tipo: " + ex.GetType().FullName);
            Debug.LogError("[CONEXAO] Stack: " + ex.StackTrace);

            if (ex.InnerException != null)
            {
                Debug.LogError("[CONEXAO] Inner: " + ex.InnerException.Message);
                Debug.LogError("[CONEXAO]" + ex.InnerException.StackTrace);
                Debug.LogError("[CONEXAO]" + ex.InnerException.ToString());

            }

            return;
        }

        Debug.Log("[CONEXAO] 2 Iniciando conexão ao Hub");
        connection.On<List<string>>(
            "AudioGenerated",
            audios =>
            {
                MainThreadDispatcher.Enqueue(() =>
                {
                    AudioGenerated?.Invoke(audios);
                    Debug.Log("[CONEXAO] Chegou aqui");
                });
            });

        Debug.Log("[CONEXAO] 3 Iniciando conexão ao Hub");
        try
        {
            Debug.Log("[CONEXAO] Iniciando conexão ao Hub");

            await connection.StartAsync();

            Debug.Log("[CONEXAO] Conectado ao Hub");

            // await connection.InvokeAsync(
            //     "JoinOperation",
            //     operationId);

            Debug.Log("[CONEXAO] Entrou no grupo");
        }
        catch (Exception ex)
        {
            Debug.LogError("[CONEXAO] Erro ao conectar ao Hub");
            Debug.LogError($"[CONEXAO] Mensagem: {ex.Message}");
            Debug.LogError($"[CONEXAO] Tipo: {ex.GetType().FullName}");
            Debug.LogError($"[CONEXAO] StackTrace:\n{ex.StackTrace}");

            if (ex.InnerException != null)
            {
                Debug.LogError($"[CONEXAO] InnerException: {ex.InnerException.Message}");
                Debug.LogError(ex.InnerException.StackTrace);
            }
        }
    }


    public async Task Disconnect()
    {
        if (connection != null)
        {
            await connection.StopAsync();

            await connection.DisposeAsync();
        }
    }
}