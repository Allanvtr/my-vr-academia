using UnityEngine;


public class ReceiveData : MonoBehaviour
{
    public Cronometro Cronometro;
    void Start()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        using (AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaObject intent = activity.Call<AndroidJavaObject>("getIntent");

            int tempo = intent.Call<int>("getIntExtra", "tempo", 0);
            string fase = intent.Call<string>("getStringExtra", "fase");

            Debug.Log("Tempo recebido: " + tempo);
            Debug.Log("Fase recebida: " + fase);

            Cronometro.SetTime(tempo);
        }
#endif
    }
}