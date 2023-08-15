using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    private bool isPaused;
    [Header("Painel De Pause")]
    public GameObject pausePanel;
    public GameObject ResumeButton;
    private bool isResume;
    public Button Pause;

    private void Start()
    {
        // Obt�m o componente Button do bot�o no in�cio do jogo
        Pause = GetComponent<Button>();
    }

    public void OnPauseButtonClicked()
    {
        if (isPaused)
        {
            isPaused = false;
            pausePanel.SetActive(false);
            Pause.interactable = true; // Ativar o bot�o de pausa quando o painel de pausa for desativado
        }
        else
        {
            isPaused = true;
            pausePanel.SetActive(true);
            Pause.interactable = false; // Desativar o bot�o de pausa quando o painel de pausa for ativado
        }
    }

    public void OnResumeButtonClicked()
    {
        if (isResume)
        {
            isResume = false; // Definir a vari�vel isResume como false para ativar o bot�o de pausa novamente
            pausePanel.SetActive(true);
            Pause.interactable = true; // Ativar o bot�o de pausa ao retomar o jogo
        }
        else
        {
            isPaused = false;
            pausePanel.SetActive(false);
        }
    }
}
