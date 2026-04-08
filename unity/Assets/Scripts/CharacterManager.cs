using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public int quantidade;
    public GameObject[] personagens;

    public void DefinirQuantidade(int quantidade)
    {
        List<int> indices_personagens = SortearPersonagens(quantidade);

        for (int i = 0; i < personagens.Length; i++)
        {
            personagens[i].SetActive(false);
        }

        for (int i = 0; i < indices_personagens.Count; i++)
            personagens[indices_personagens[i]].SetActive(true);
        }

    public List<int> SortearPersonagens(int quantidade)
    {
        List<int> indices = new List<int>();

        // cria lista com todos os índices possíveis
        for (int i = 0; i < personagens.Length; i++)
        {
            indices.Add(i);
        }

        // embaralha a lista
        for (int i = 0; i < indices.Count; i++)
        {
            int randomIndex = Random.Range(i, indices.Count);
            int temp = indices[i];
            indices[i] = indices[randomIndex];
            indices[randomIndex] = temp;
        }

        // pega só os N primeiros
        return indices.GetRange(0, quantidade);
    }

    void Start()
    {
        DefinirQuantidade(quantidade);
    }
}