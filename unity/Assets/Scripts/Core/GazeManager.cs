using UnityEngine;
using System.Collections.Generic;

public class GazeManager : MonoBehaviour
{
    public Camera cam;
    public GameManager gameManager;

    [Header("Tuning")]
    [Range(0.02f, 0.3f)]
    public float raioTelaAceitavel = 0.1f; // % da tela até o centro (0 a 1)
    public float tempoDeOlhar = 1.5f;
    public float velocidadeDecaimento = 1.5f;

    public bool usarChecagemDeOclusao = true;
    public LayerMask layerObstrucao; // mesas, paredes, outros personagens na frente

    private readonly Dictionary<GazeAnimation, float> contadores = new();

    void Update()
    {
        List<GazeAnimation> candidatos = GetCandidatos();

        GazeAnimation melhorAlvo = null;
        float menorDistancia = float.MaxValue;

        foreach (var personagem in candidatos)
        {
            Vector3 viewportPos = cam.WorldToViewportPoint(personagem.PontoOlhar.position);

            bool dentroDaTela =
                viewportPos.z > 0 &&
                viewportPos.x >= 0 && viewportPos.x <= 1 &&
                viewportPos.y >= 0 && viewportPos.y <= 1;

            if (!dentroDaTela) continue;

            float distancia = Vector2.Distance(
                new Vector2(viewportPos.x, viewportPos.y),
                new Vector2(0.5f, 0.5f)
            );

            if (distancia > raioTelaAceitavel) continue;

            if (usarChecagemDeOclusao && EstaObstruido(personagem)) continue;

            if (distancia < menorDistancia)
            {
                menorDistancia = distancia;
                melhorAlvo = personagem;
            }
        }

        foreach (var personagem in candidatos)
        {
            if (!contadores.ContainsKey(personagem))
                contadores[personagem] = 0f;

            if (personagem == melhorAlvo)
            {
                contadores[personagem] += Time.deltaTime;

                if (contadores[personagem] >= tempoDeOlhar)
                {
                    contadores[personagem] = 0f;
                    gameManager.SelecionarPersonagem(personagem);
                }
            }
            else
            {
                contadores[personagem] = Mathf.Max(
                    0f, contadores[personagem] - Time.deltaTime * velocidadeDecaimento
                );
            }
        }
    }

    private bool EstaObstruido(GazeAnimation personagem)
    {
        Vector3 origem = cam.transform.position;
        Vector3 alvo = personagem.PontoOlhar.position;
        Vector3 direcao = alvo - origem;
        float distancia = direcao.magnitude;

        if (Physics.Raycast(origem, direcao.normalized, out RaycastHit hit, distancia, layerObstrucao))
        {
            GazeAnimation atingiu = hit.transform.GetComponentInParent<GazeAnimation>();
            return atingiu != personagem; // bateu em outra coisa/pessoa antes de chegar no alvo
        }

        return false;
    }

    private List<GazeAnimation> GetCandidatos()
    {
        GazeAnimation[] todos = FindObjectsByType<GazeAnimation>(
            FindObjectsInactive.Include, FindObjectsSortMode.None
        );

        List<GazeAnimation> ativos = new();
        foreach (var p in todos)
        {
            if (p.gameObject.activeInHierarchy && p.MaoLevantada && !p.PerguntaRespondida)
                ativos.Add(p);
        }
        return ativos;
    }
}