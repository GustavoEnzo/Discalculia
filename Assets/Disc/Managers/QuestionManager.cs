using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class QuestionManager : MonoBehaviour
{
    [SerializeField] GameObject losePanel;
    [SerializeField] GameObject nextPanel;
    [SerializeField] GameObject congratsPanel;
    [SerializeField] GameObject nottimePanel;

    [SerializeField] List<string> questions;
    [SerializeField] List<string> helps;
    [SerializeField] List<string> answer;
    [SerializeField] List<Button> answerBtns;
    [SerializeField] TMP_Text questionText;
    [SerializeField] TMP_Text helpText;

    [SerializeField] GameManagerBehaviour gameManager;

    private int currentClickedAnswer = 0;
    private int currentQuestionAnswer = 0;
    private int currentHelpAnswer = 0;
    private int correctAnswer = 0;

    private void Start()
    {
        UpdateQuestion();
    }

    public void UpdateQuestion()
    {
        int[] respostas= new int[4];
        foreach (var btn in answerBtns)
        {
            int.TryParse(answer[GameManagerBehaviour.Instance.currentLevel], out int parsedAnswer);
            do
            {
                correctAnswer = Random.Range(1, 10);
            } while (correctAnswer == parsedAnswer);
            btn.transform.GetChild(1).GetComponent<TMP_Text>().text = "" + correctAnswer;
            answerBtns[currentQuestionAnswer].transform.GetChild(1).GetComponent<TMP_Text>().color = Color.black;
        }

        //currentQuestionAnswer = Random.Range(0, 4);//
        if (GameManagerBehaviour.Instance.currentLevel < 4)
        {
            currentQuestionAnswer = GameManagerBehaviour.Instance.currentLevel;

        }
        else
        {   
            currentQuestionAnswer= GameManagerBehaviour.Instance.currentLevel- (4 * (int)(GameManagerBehaviour.Instance.currentLevel / 4));
            
            Debug.Log(currentQuestionAnswer); 
        }
      
        currentHelpAnswer = GameManagerBehaviour.Instance.currentLevel;
       

        questionText.text = questions[GameManagerBehaviour.Instance.currentLevel];
        helpText.text = helps[currentHelpAnswer];

        answerBtns[currentQuestionAnswer].transform.GetChild(1).GetComponent<TMP_Text>().text = answer[GameManagerBehaviour.Instance.currentLevel];
        


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

        if (GameManagerBehaviour.Instance.currentLevel < questions.Count - 1)
        {
            nextPanel.SetActive(true);
        }
        else
        {
            nextPanel.SetActive(false);
            congratsPanel.SetActive(true);
        }

        gameManager.ResetTime();
        this.transform.parent.gameObject.SetActive(false);
    }

    private void Wrong()
    {
        losePanel.SetActive(true);
        this.transform.parent.gameObject.SetActive(false);
    }
}
