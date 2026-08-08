using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public GameObject[] personagens;

    private GameConfig config;

    private List<GazeAnimation> personagensAtivos = new();

    private void Start()
    {
        config = AndroidIntentReader.GetConfig();

        DefinirQuantidade(config.Publico);
    }

    public void DefinirQuantidade(int quantidade)
    {
        List<int> indicesPersonagens =
            SortearPersonagens(quantidade);

        personagensAtivos.Clear();

        // Primeiro desativa todos
        for (int i = 0; i < personagens.Length; i++)
        {
            personagens[i].SetActive(false);
        }

        // Depois ativa os sorteados
        for (int i = 0; i < indicesPersonagens.Count; i++)
        {
            GameObject personagem =
                personagens[indicesPersonagens[i]];

            personagem.SetActive(true);

            GazeAnimation gaze =
                personagem.GetComponent<GazeAnimation>();

            if (gaze == null)
            {
                Debug.LogError(
                    $"O personagem {personagem.name} " +
                    $"não possui GazeAnimation!"
                );

                continue;
            }

            // O índice da pergunta é definido aqui
            gaze.DefinirPergunta(i);

            personagensAtivos.Add(gaze);

            Debug.Log(
                $"[CHARACTER] {personagem.name} → " +
                $"Pergunta {i}"
            );
        }
    }

    public List<GazeAnimation> GetPersonagensAtivos()
    {
        return personagensAtivos;
    }

    public List<int> SortearPersonagens(int quantidade)
    {
        quantidade = Mathf.Clamp(
            quantidade,
            0,
            personagens.Length
        );

        List<int> indices = new();

        for (int i = 0; i < personagens.Length; i++)
        {
            indices.Add(i);
        }

        // Embaralha
        for (int i = 0; i < indices.Count; i++)
        {
            int randomIndex =
                Random.Range(i, indices.Count);

            int temp = indices[i];

            indices[i] = indices[randomIndex];
            indices[randomIndex] = temp;
        }

        return indices.GetRange(0, quantidade);
    }
}