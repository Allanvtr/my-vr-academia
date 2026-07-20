using System;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Networking;
using UnityEngine;

public class ApiClient
{
    private const string BaseUrl = "http://localhost:5116";

    public async Task<string> Get(string endpoint)
    {
        using UnityWebRequest request = UnityWebRequest.Get($"{BaseUrl}/{endpoint}");
        Debug.Log($"{BaseUrl}/{endpoint}");

        var operation = request.SendWebRequest();

        while (!operation.isDone)
            await Task.Yield();

        if (request.result == UnityWebRequest.Result.ConnectionError ||
            request.result == UnityWebRequest.Result.DataProcessingError)
            {
                throw new Exception(request.error);
            }

        return request.downloadHandler.text;
    }

    public async Task<AudioClip> GetAudioClip(string endpoint)
    {
        string url = $"{BaseUrl}/{endpoint}";

        Debug.Log($"1 - URL: {url}");

        UnityWebRequest request = null;

        try
        {
            request = UnityWebRequestMultimedia.GetAudioClip(
                url,
                AudioType.WAV);

            Debug.Log("2 - Request criada");
        }
        catch (Exception e)
        {
            Debug.LogError($"Erro criando request: {e}");
            throw;
        }

        var operation = request.SendWebRequest();

        Debug.Log("3 - Request enviada");

        while (!operation.isDone)
        {
            await Task.Yield();
        }

        Debug.Log($"4 - Terminou: {request.result}");

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError($"Erro: {request.error}");
            throw new Exception(request.error);
        }

        Debug.Log("5 - Pegando AudioClip");

        var clip = DownloadHandlerAudioClip.GetContent(request);

        Debug.Log($"6 - AudioClip criado: {clip.length}");

        return clip;
    }

    public async Task<string> Post(string endpoint, string json)
    {
        using UnityWebRequest request =
            new UnityWebRequest($"{BaseUrl}/{endpoint}", "POST");

        byte[] body = Encoding.UTF8.GetBytes(json);

        request.uploadHandler = new UploadHandlerRaw(body);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        var operation = request.SendWebRequest();

        while (!operation.isDone)
            await Task.Yield();

        if (request.result != UnityWebRequest.Result.Success)
            throw new Exception(request.error);

        return request.downloadHandler.text;
    }
}