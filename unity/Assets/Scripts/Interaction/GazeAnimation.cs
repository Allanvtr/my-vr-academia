using UnityEngine;

public class GazeAnimation : MonoBehaviour
{
    [Tooltip("Ponto usado para medir o olhar (ideal: cabeça). Se vazio, usa a posição do objeto.")]
    public Transform pontoOlhar;

    private int perguntaIndex = -1;
    private Animator animator;

    private bool maoLevantada = false;
    private bool perguntaRespondida = false;

    public int PerguntaIndex => perguntaIndex;
    public bool MaoLevantada => maoLevantada;
    public bool PerguntaRespondida => perguntaRespondida;
    public Transform PontoOlhar => pontoOlhar != null ? pontoOlhar : transform;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        if (animator == null)
            Debug.LogError($"Animator não encontrado em {name}!");
    }

    public void DefinirPergunta(int index)
    {
        perguntaIndex = index;
        perguntaRespondida = false;
        maoLevantada = false;
        Debug.Log($"[GAZE] {name} recebeu a pergunta {index}");
    }

    public void LevantarMao()
    {
        if (perguntaRespondida || perguntaIndex < 0) return;
        maoLevantada = true;
        animator.SetTrigger("PlayAnim");
        Debug.Log($"[GAZE] {name} levantou a mão. Pergunta: {perguntaIndex}");
    }

    public void BaixarMao()
    {
        maoLevantada = false;
        animator.SetTrigger("BaixarMao");
        Debug.Log($"[GAZE] {name} baixou a mão.");
    }

    public void MarcarComoRespondida()
    {
        perguntaRespondida = true;
        maoLevantada = false;
    }

    public bool TemPergunta() => perguntaIndex >= 0 && !perguntaRespondida;
}