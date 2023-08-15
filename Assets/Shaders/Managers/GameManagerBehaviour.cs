using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerBehaviour : MonoBehaviour
{
    [SerializeField] float turnTimer;
    [SerializeField] float percentage = 1;

    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject inGamePanel;
    [SerializeField] GameObject resetPanel;
    [SerializeField] Material timeBarMaterial;

    private bool inGame = false;
    private float max;

    private void Start()
    {
        max = turnTimer;
    }
    private void FixedUpdate()
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

        // map turnTimer in range 0 - 1
        timeBarMaterial.SetFloat("_percentage", percentage);
    }
    private void Update()
    {
        if (inGame && percentage <= 0)
            ResetMenu();

    }
    // PUBLIC METHODS
    public void StartBtn()
    {
        startPanel.SetActive(false);
        resetPanel.SetActive(false);
        inGamePanel.SetActive(true);
        inGame = true;
        turnTimer = max;
    }
    private void ResetMenu()
    {
        inGamePanel.SetActive(false);
        resetPanel.SetActive(true);
    }
}
