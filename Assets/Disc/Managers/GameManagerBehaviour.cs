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
    [SerializeField] GameObject notimePanel;
    [SerializeField] GameObject congratsPanel;
    [SerializeField] GameObject pausePanel;
    [SerializeField] Material timeBarMaterial;

    private bool inGame = false;
    private bool isPaused = false;
    private float max;
    public List<GameObject> levelObjects = new List<GameObject>();

    public int currentLevel = 0, totalLevels = 0;
    private bool questionMode;
    private ScreenOrientation targetOrientation = ScreenOrientation.LandscapeLeft;


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
        totalLevels = 7;
    }
    private void FixedUpdate()
    {
        if(!isPaused) { 
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
        
    }
    private void Update()
    {
        if (questionMode)
        {
            if (inGame && percentage <= 0)
                TimeMenu();
        }
    }
    // PUBLIC METHODS
    public void StartBtn()
    {
        startPanel.SetActive(false);
        resetPanel.SetActive(false);
        inGamePanel.SetActive(true);
        notimePanel.SetActive(false);
        isPaused = false;
        pausePanel.SetActive(false);
        LoadLevel(currentLevel);

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
    private void TimeMenu()
    {
        inGamePanel.SetActive(false);
        notimePanel.SetActive(true);
    }

    //LEVEL MANAGER
    public void NextLevel()
    {
        if (currentLevel < totalLevels - 1)
        {
            currentLevel++;
            LoadLevel(currentLevel);
            nextPanel.SetActive(false);
            StartBtn();
        }
        else
        {   
            Congratulation();
            
        }
    }
    public void LoadLevel(int level)
    {   
        levelObjects.ForEach(obj => obj.SetActive(false));
        levelObjects[level].SetActive(true);
        
    }
    public void ResetTime()
    {
        questionMode = false;
        timeBarMaterial.SetFloat("_percentage", 1);
        turnTimer = max;
    }

    public void Congratulation()
    {
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
    public void Pause()
    {
        isPaused = true;
        pausePanel.SetActive(true);
    }
    public void Resume()
    {
        isPaused = false;
        pausePanel.SetActive(false);
    }
    public void Exit()
    {
        resetPanel.SetActive(false);
        inGamePanel.SetActive(false);
        startPanel.SetActive(true);
        congratsPanel.SetActive(false);
        currentLevel= 0;
        
    }

}
