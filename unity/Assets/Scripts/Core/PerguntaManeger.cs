//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PerguntaManager : MonoBehaviour
//{
//    public CharacterManager characterManager;
//    public Cronometro cronometro;
//    public AudioSource audioSource;

//    public float tempoResposta = 20f;

//    private Dictionary<GazeAnimation, Queue<AudioClip>> filaPorPersonagem = new();
//    private List<GazeAnimation> personagensComPergunta = new();
//    private bool aguardandoResposta = false;

//    // Chame isso quando os áudios de perguntas chegarem do backend
//    public void IniciarPerguntas(List<AudioClip> perguntas)
//    {
//        DistribuirPerguntas(perguntas);
//        LevantarMaosPendentes();
//    }

//    private void DistribuirPerguntas(List<AudioClip> perguntas)
//    {
//        List<GazeAnimation> ativos = characterManager.GetPersonagensAtivos();
//        int qtdPersonagens = ativos.Count;

//        filaPorPersonagem.Clear();
//        personagensComPergunta.Clear();

//        if (qtdPersonagens == 0 || perguntas.Count == 0) return;

//        // distribui em round-robin: se tiver mais perguntas que personagens,
//        // os personagens já usados recebem outra pergunta na fila
//        for (int i = 0; i < perguntas.Count; i++)
//        {
//            GazeAnimation personagem = ativos[i % qtdPersonagens];

//            if (!filaPorPersonagem.ContainsKey(personagem))
//            {
//                filaPorPersonagem[personagem] = new Queue<AudioClip>();
//                personagensComPergunta.Add(personagem);
//            }

//            filaPorPersonagem[personagem].Enqueue(perguntas[i]);
//        }
//    }

//    private void LevantarMaosPendentes()
//    {
//        foreach (var personagem in personagensComPergunta)
//        {
//            if (filaPorPersonagem[personagem].Count > 0)
//                personagem.LevantarMao();
//        }
//    }

//    public void OnPersonagemSelecionado(GazeAnimation personagem)
//    {
//        if (aguardandoResposta) return;
//        if (!filaPorPersonagem.ContainsKey(personagem)) return;
//        if (filaPorPersonagem[personagem].Count == 0) return;

//        AudioClip pergunta = filaPorPersonagem[personagem].Dequeue();

//        // abaixa a mão de todo mundo que estava levantada
//        foreach (var p in personagensComPergunta)
//            if (p.MaoLevantada) p.BaixarMao();

//        audioSource.clip = pergunta;
//        audioSource.Play();

//        aguardandoResposta = true;
//        cronometro.Resetar(tempoResposta);

//        StartCoroutine(AguardarFimDaResposta());
//    }

//    private IEnumerator AguardarFimDaResposta()
//    {
//        yield return new WaitUntil(() => cronometro.GetTime() <= 0f);

//        aguardandoResposta = false;

//        bool aindaHaPerguntas = false;
//        foreach (var p in personagensComPergunta)
//        {
//            if (filaPorPersonagem[p].Count > 0)
//            {
//                aindaHaPerguntas = true;
//                break;
//            }
//        }

//        if (aindaHaPerguntas)
//            LevantarMaosPendentes();
//        else
//            Debug.Log("[PERGUNTAS] Não há mais perguntas.");
//    }
//}