using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEditor.MemoryProfiler;
using UnityEngine;

public class SignalRService
{
    private HubConnection connection;
    public event Action<List<string>> AudioGenerated;

    public async Task ConnectAsync(/*Guid operationId*/)
    {
        connection = new HubConnectionBuilder()
            .WithUrl("http://localhost:5116/sceneHub")
            .WithAutomaticReconnect()
            .Build();


        connection.On<List<string>>(
            "AudioGenerated",
            audios =>
            {
                MainThreadDispatcher.Enqueue(() =>
                {
                    AudioGenerated?.Invoke(audios);
                    Debug.Log("Chegou aqui");
                });
            });

        await connection.StartAsync();

        Debug.Log("Conectado ao Hub");

        //await connection.InvokeAsync(
        //    "JoinOperation",
        //    operationId);

        Debug.Log("Entrou no grupo");
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