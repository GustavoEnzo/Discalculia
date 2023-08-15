using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class OpenErrorPanel : MonoBehaviour
{

    public string Fases; 
    private bool isPaused;
    public GameObject ErrorPanel; // Referência ao painel que será aberto
    private bool isNext;
    public void OnPauseButtonClicked()
    {


        if (isPaused)
        {
            isPaused = false;
            ErrorPanel.SetActive(false);
            Time.timeScale = 0f;
        }
        else
        {
            isPaused = true;
            ErrorPanel.SetActive(true);
            Time.timeScale = 1f;
        }


    }

    public void OnNextButtonClicked()
    {
        SceneManager.LoadScene(Fases);
    }
}