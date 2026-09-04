using System.Threading.Tasks;
using UnityEngine;
using System;

public class BackendService
{
    private readonly ApiClient api = new();

    public async Task<StatusResponse> BuscarStatus(Guid? id)
    {
        string json = await api.Get($"Scene/status/{id}");

        Debug.Log("Json Retornado" + json);

        return JsonUtility.FromJson<StatusResponse>(json);
    }

    public async Task<AudioClip> DownloadAudio(String url)
    {
        return await api.GetAudioClip(url);
    }
}