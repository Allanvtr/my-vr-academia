using UnityEngine;

public static class AndroidIntentReader
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
                }
#endif

        Debug.Log($"Tempo recebido = {config.Tempo}");
        Debug.Log($"Fase recebida = {config.Fase}");

        return config;
    }
}