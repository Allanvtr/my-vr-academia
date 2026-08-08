using UnityEngine;
using System;
using UnityEngine;

public class AndroidIntentReader : MonoBehaviour
{
    public static GameConfig GetConfig()
    {
        GameConfig config = new();

#if UNITY_ANDROID && !UNITY_EDITOR
                using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
                {
                    AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
                    AndroidJavaObject intent = activity.Call<AndroidJavaObject>("getIntent");

                    config.Tempo = intent.Call<int>("getIntExtra", "tempo", 0);
                    config.Fase = intent.Call<string>("getStringExtra", "fase");
                    string operacaoIdString = intent.Call<string>("getStringExtra", "operationId");

                    if (Guid.TryParse(operacaoIdString, out Guid operationId))
                    {
                        config.OperationId = operationId;
                    }
                    else
                    {
                        Debug.LogError($"[CONFIG] OperacaoId inválido: {operacaoIdString}");
                    }

                    config.Publico = intent.Call<int>("getIntExtra", "publico", 10);
                }
#endif

        Debug.Log($"[CONFIG] Tempo recebido = {config.Tempo}");
        Debug.Log($"[CONFIG] Fase recebida = {config.Fase}");
        Debug.Log($"[CONFIG] OperacaoId recebido = {config.OperationId}");
        Debug.Log($"[CONFIG] Publico recebido = {config.Publico}");

        return config;
    }
}