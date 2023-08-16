using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarTime : MonoBehaviour
{
    public float totalTime = 10f;
    public float timeSpeed = 5f;
    public Color timeColor = Color.green;
    public Color alertColor = Color.yellow;
    public Color warningColor = Color.red;
    private float initialWidth;
    private Image timeBarImage;
    // private RectTransform anchor;
    private bool isTimeUp = false;
    public GameObject congratulationsPanel; // refer�ncia ao painel de parab�ns
    private bool isPaused = false;

    void Start()
    {
        timeBarImage = GetComponent<Image>();
        initialWidth = timeBarImage.rectTransform.rect.width;
        // anchor = transform.Find("Anchor").GetComponent<RectTransform>();
    }

    void Update()
    {
        if (!isPaused && !isTimeUp)
        {
            float timeLeft = Mathf.Clamp(totalTime - Time.timeSinceLevelLoad * timeSpeed, 0f, totalTime);
            float percentLeft = timeLeft / totalTime;

            // Altera a cor para vermelho ao chegar em 50% de tempo restante
            float redPercent = 0.2f;
            float yellowPercent = 0.5f;
            if (percentLeft <= redPercent)
            {
                float t = (percentLeft - (redPercent - 0.01f)) / 0.01f;
                timeBarImage.color = Color.Lerp(warningColor, Color.red, t);
            }
            else if (percentLeft <= yellowPercent)
            {
                float t = (percentLeft - (yellowPercent - 0.01f)) / 0.01f;
                timeBarImage.color = Color.Lerp(alertColor, Color.yellow, t);

            }
            else
            {
                timeBarImage.color = Color.Lerp(Color.green, timeColor, percentLeft);
            }

            float newWidth = percentLeft * initialWidth;
            timeBarImage.rectTransform.sizeDelta = new Vector2(newWidth, timeBarImage.rectTransform.rect.height);

            // Calcula a nova posi��o da barra de tempo
            float newPosX = -(initialWidth / 2f) + (newWidth / 2f);
            timeBarImage.rectTransform.anchoredPosition = new Vector2(newPosX, timeBarImage.rectTransform.anchoredPosition.y);
            if (timeLeft <= 0f)
            {
                isTimeUp = true;
                congratulationsPanel.SetActive(true); // ativa o painel de parab�ns
            }
        }
    }
    public void PauseBar()
    {
        isPaused = true;
        Time.timeScale = 0f;
    }

    // Fun��o para retomar a barra de tempo
    public void ResumeBar()
    {
        isPaused = false;
        Time.timeScale = 1f;
    }
}
