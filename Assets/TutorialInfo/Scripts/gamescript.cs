using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EscolhaDaBola : MonoBehaviour
{
    private int escolha = 0; // Valor padrão para representar nenhuma escolha

    private void Quest1()
    {
        GUILayout.Label(" qual delas é a bola de fubebol?");
        
        if (GUILayout.Button("Bola (1)"))
        {
            escolha = 1;
        }

        if (GUILayout.Button("Bola (2)"))
        {
            escolha = 2;
        }

        if (GUILayout.Button("Bola (3)"))
        {
            escolha = 3;
        }

        if (escolha != 0)
        {
            MostrarEscolha();
        }
    }

    private void MostrarEscolha()
    {
        switch (escolha)
        {
            case 1:
                Debug.Log("Você escolheu a bola de futebol!");
                break;
            case 2:
                Debug.Log("quase! ela é menor");
                break;
            case 3:
                Debug.Log("quase! vamos tentar denovo");
                break;
            default:
                Debug.Log(" inválida.");
                break;
        }
    }
}
