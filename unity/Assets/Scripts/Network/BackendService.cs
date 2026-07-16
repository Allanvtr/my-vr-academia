using System.Threading.Tasks;
using UnityEngine;

public class BackendService
{
    private readonly ApiClient api = new();

    public async Task<StatusResponse> BuscarStatus(string id)
    {
        string json = await api.Get($"status/{id}");

        Debug.Log("Json Retornado" + json);

        return JsonUtility.FromJson<StatusResponse>(json);
    }
}