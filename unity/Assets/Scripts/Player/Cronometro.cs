using UnityEngine;
using TMPro;

public class Cronometro : MonoBehaviour
{
    public TextMeshProUGUI texto;

    private float tempo = 120f;
    private bool rodando = true;

    void Update()
    {
        if (rodando)
        {
            tempo -= Time.deltaTime;

            if (tempo <= 0f)
            {
                tempo = 0f;
                rodando = false;
            }
        }

        int minutos = Mathf.FloorToInt(tempo / 60f);
        int segundos = Mathf.FloorToInt(tempo % 60f);

        texto.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }

    public void Parar()
    {
        rodando = false;
    }

    public void Resetar(float time)
    {
        tempo = time;
        rodando = true;
    }

    public void SetTime(float time)
    {
        tempo = Mathf.Max(0f, time);
    }

    public float GetTime()
    {
        return tempo;
    }
}