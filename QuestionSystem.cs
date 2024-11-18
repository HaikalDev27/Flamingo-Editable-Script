using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionSystem : MonoBehaviour
{
    [System.Serializable]
    public class Question{
        public string questionText;
        public string[] options;
        public int CorrectAnswerIndex;
    }

    public Question[] questions;
    int currentQuestionIndex;

    public GameObject questionParent;
    public GameObject questionPanel;
    public GameObject MainPanel;
    public GameObject SuccessPanel;
    public GameObject FailedPanel;
    public Text questionText;
    public Button[] optionButtons;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        currentQuestionIndex = 0;
        FirsDisplay();
    }

    void FirsDisplay(){
        questionPanel.SetActive(true);
        MainPanel.SetActive(false);
    }

    void DisplayQuestions() {
        Question currentQuestion = questions[currentQuestionIndex];

        questionText.text = currentQuestion.questionText;

        for (int i=0;  i < optionButtons.Length; i++){
            if(i < currentQuestion.options.Length){
                optionButtons[i].GetComponentInChildren<Text>().text = currentQuestion.options[i];
                optionButtons[i].gameObject.SetActive(true);

                int optionIndex = i;
                optionButtons[i].onClick.RemoveAllListeners();
                optionButtons[i].onClick.AddListener(() => CheckAnswer(optionIndex));
            } else {
                optionButtons[i].gameObject.SetActive(false);
            }
        }
    }

    void CheckAnswer(int selectedOptionIndex){
        if (selectedOptionIndex == questions[currentQuestionIndex].CorrectAnswerIndex){
            Debug.Log("Betul");
        } else {
            StartCoroutine(FailedDelay());
        }

        currentQuestionIndex++;

        if(currentQuestionIndex < questions.Length){
            DisplayQuestions();
        } else {
            StartCoroutine(SuccessDelay());
        }
    }

    IEnumerator FailedDelay (){
        FailedPanel.SetActive(true);
        questionPanel.SetActive(false);
        yield return new WaitForSeconds(1.0f);
        questionParent.SetActive(false);
    }

    IEnumerator SuccessDelay (){
        SuccessPanel.SetActive(true);
        questionPanel.SetActive(false);
        yield return new WaitForSeconds(1.0f);
        questionParent.SetActive(false);
    }
}
