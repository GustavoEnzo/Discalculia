using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class OpenCongratulationsPanel : MonoBehaviour
{

    public string Fases; 
    private bool isPaused;
    public GameObject congratulationsPanel; // Referência ao painel que será aberto
    private bool isNext;
    public void OnPauseButtonClicked()
    {


        if (isPaused)
        {
            isPaused = false;
            congratulationsPanel.SetActive(false);
            Time.timeScale = 0f;
        }
        else
        {
            isPaused = true;
            congratulationsPanel.SetActive(true);
            Time.timeScale = 1f;
        }



    }

    public void OnNextButtonClicked()
    {
        SceneManager.LoadScene(Fases);
    }
    public void OnRestartButtonClicked()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
        Time.timeScale = 1f;
    }
}