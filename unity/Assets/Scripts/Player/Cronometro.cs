using UnityEngine;
using TMPro;

public class Cronometro : MonoBehaviour
{
    public TextMeshProUGUI texto;

    private float tempo;
    private bool rodando = false;

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

        AtualizarTexto();
    }

    private void AtualizarTexto()
    {
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
        tempo = Mathf.Max(0f, time);
        rodando = true;
    }

    public void SetTime(float time)
    {
        tempo = Mathf.Max(0f, time);
        rodando = true;
    }

    public float GetTime()
    {
        return tempo;
    }

    public bool Terminou()
    {
        return tempo <= 0f;
    }

    public bool EstaRodando()
    {
        return rodando;
    }
}