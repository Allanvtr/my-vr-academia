using System;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Networking;
using UnityEngine;

public class ApiClient
{
    private const string BaseUrl = "http://localhost:5116/Scene";

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