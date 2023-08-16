using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerBehaviour : MonoBehaviour
{
    public static GameManagerBehaviour Instance { get; private set; }

    [SerializeField] QuestionManager questionManager;

    public float turnTimer;
    [SerializeField] float percentage = 1;

    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject nextPanel;
    [SerializeField] GameObject inGamePanel;
    [SerializeField] GameObject resetPanel;
    [SerializeField] GameObject congratsPanel;
    [SerializeField] Material timeBarMaterial;

    private bool inGame = false;
    private float max;

    public int currentLevel = 0, totalLevels = 0;
    private bool questionMode;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Init();
    }
    private void Init()
    {
        max = turnTimer;
        totalLevels = 3;
    }
    private void FixedUpdate()
    {
        if (questionMode)
        {
            if (inGame && turnTimer >= 0)
            {
                turnTimer = turnTimer >= 0 ? turnTimer - Time.fixedDeltaTime : 0;
                percentage = ((turnTimer == 0) ? 0 : turnTimer) / max;
            }
            else
            {
                percentage = 1;
                turnTimer = 0;
                inGame = false;
            }
            timeBarMaterial.SetFloat("_percentage", percentage);
        }
    }
    private void Update()
    {
        if (questionMode)
        {
            if (inGame && percentage <= 0)
                ResetMenu();
        }
    }
    // PUBLIC METHODS
    public void StartBtn()
    {
        startPanel.SetActive(false);
        resetPanel.SetActive(false);
        inGamePanel.SetActive(true);

        inGame = true;

        turnTimer = max;
        questionMode = true;
        questionManager.UpdateQuestion();
    }
    private void ResetMenu()
    {
        inGamePanel.SetActive(false);
        resetPanel.SetActive(true);
    }

    //LEVEL MANAGER
    public void NextLevel()
    {
        if (currentLevel < totalLevels - 1)
        {
            currentLevel++;
            SceneManager.LoadScene(currentLevel);
            nextPanel.SetActive(false);
            StartBtn();
        }
        else
            Congratulation();
    }
    public void ResetTime()
    {
        questionMode = false;
        timeBarMaterial.SetFloat("_percentage", 1);
        turnTimer = max;
    }
    public void Congratulation()
    {
        nextPanel.SetActive(false);
        congratsPanel.SetActive(true);
        Debug.Log("in last level.");
    }
    public void BackToStartGame()
    {
        currentLevel = 0;
        SceneManager.LoadScene(0);
        Instance.StartBtn();
        congratsPanel.SetActive(false);
    }
}
