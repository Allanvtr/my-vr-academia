using UnityEngine;
using TMPro;

public class Cronometro : MonoBehaviour
{
    public TextMeshProUGUI texto;
    private float tempo = 120;
    private bool rodando = true;

    void Update()
    {
        if (rodando)
        {
            tempo -= Time.deltaTime;

            int minutos = Mathf.FloorToInt(tempo / 60);
            int segundos = Mathf.FloorToInt(tempo % 60);

            texto.text = string.Format("{0:00}:{1:00}", minutos, segundos);
        }
    }

    public void Parar()
    {
        rodando = false;
    }

    public void Resetar()
    {
        tempo = 0f;
    }

    public void SetTime(float time)
    {
        tempo = time;
    }
}