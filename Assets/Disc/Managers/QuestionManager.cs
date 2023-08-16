using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestionManager : MonoBehaviour
{
    [SerializeField] GameObject losePanel;
    [SerializeField] GameObject nextPanel;

    [SerializeField] List<string> questions;
    [SerializeField] List<string> answer;
    [SerializeField] List<Button> answerBtns;
    [SerializeField] TMP_Text questionText;

    [SerializeField] GameManagerBehaviour gameManager;

    private int currentClickedAnswer = 0;
    private int currentQuestionAnswer = 0;

    private void Start()
    {
        UpdateQuestion();
    }

    public void UpdateQuestion()
    {
        foreach (var btn in answerBtns)
        {
            btn.transform.GetChild(1).GetComponent<TMP_Text>().text = "" + Random.Range(0, 20);
            answerBtns[currentQuestionAnswer].transform.GetChild(1).GetComponent<TMP_Text>().color = Color.black;
        }

        currentQuestionAnswer = Random.Range(0, 4);

        questionText.text = questions[currentQuestionAnswer];
        answerBtns[currentQuestionAnswer].transform.GetChild(1).GetComponent<TMP_Text>().text = answer[currentQuestionAnswer];
        answerBtns[currentQuestionAnswer].transform.GetChild(1).GetComponent<TMP_Text>().color = Color.green;
    }

    public void CheckAnswer(int value)
    {
        currentClickedAnswer = value;

        if (currentClickedAnswer == currentQuestionAnswer)
            Correct();
        else
            Wrong();
    }

    private void Correct()
    {
        losePanel.SetActive(false);
        nextPanel.SetActive(true);
        gameManager.ResetTime();
        this.transform.parent.gameObject.SetActive(false);
    }
    private void Wrong()
    {
        losePanel.SetActive(true);
        this.transform.parent.gameObject.SetActive(false);
    }
}
