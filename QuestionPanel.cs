using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionPanel : MonoBehaviour
{
    public static QuestionPanel Instance;

    [Header("UI Components")]
    public GameObject confirmationPanel;
    public GameObject quizPanel;
    public Text confirmationText;
    public Text questionText;
    public Button[] optionButtons;

    public GameObject FailedPanel;
    public GameObject SuccessPanel;
    public GameObject questionParent;

    private QuestionSystem currentQuestionSystem;
    public int currentQuestionIndex = 0;
    public PlayerControl point;

    private void Awake(){
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Method untuk memunculkan panel konfirmasi
    public void ShowConfirmation(QuestionSystem questionSystem){
        currentQuestionSystem = questionSystem;
        confirmationPanel.SetActive(true);
        confirmationText.text = $"Apakah Anda siap menjawab quiz dari {questionSystem.npcName}?";
    }

    // Method untuk mengonfirmasi
    public void OnConfirmYes(){
        confirmationPanel.SetActive(false);
        currentQuestionSystem.FirstQuestion();
    }

    // Method untuk menutup panel konfirmasi
    public void OnConfirmNo(){
        confirmationPanel.SetActive(false);
    }

    // Method untuk menampilkan pertanyaan
    public void DisplayQuestion(QuestionSystem questionSystem){
        quizPanel.SetActive(true);
        currentQuestionSystem.canStart = false;

        // Pastikan index saat ini tidak melebihi jumlah pertanyaan
        if (currentQuestionIndex < questionSystem.questions.Length)
        {
            // Mengambil pertanyaan saat ini
            QuestionSystem.Question currentQuestion = questionSystem.questions[currentQuestionIndex];

            // Menampilkan teks pertanyaan
            questionText.text = currentQuestion.questionText;
            
            // Menampilkan opsi jawaban
            for (int i = 0; i < optionButtons.Length; i++)
            {
                if (i < currentQuestion.options.Length)
                {
                    optionButtons[i].GetComponentInChildren<Text>().text = currentQuestion.options[i];
                    optionButtons[i].gameObject.SetActive(true);

                    // Menambahkan listener untuk memeriksa jawaban
                    int answerIndex = i;
                    optionButtons[i].onClick.RemoveAllListeners();
                    optionButtons[i].onClick.AddListener(() => CheckAnswer(answerIndex, questionSystem));
                }
                else
                {
                    optionButtons[i].gameObject.SetActive(false);
                }
            }
        }
    }

    // Mengecek jawaban
    private void CheckAnswer(int index, QuestionSystem questionSystem){
        QuestionSystem.Question currentQuestion = questionSystem.questions[currentQuestionIndex];

        if (index == currentQuestion.CorrectAnswerIndex)
        {
            Debug.Log("Jawaban Benar!");
            point.point++;
            
            StartCoroutine(CorrectAnswerDelay(questionSystem));
        }
        else
        {
            Debug.Log("Jawaban Salah!");
            StartCoroutine(FailedDelay());
        }
    }

    private IEnumerator CorrectAnswerDelay(QuestionSystem questionSystem){
        yield return new WaitForSeconds(0.1f);

        currentQuestionIndex++;

        if (currentQuestionIndex < questionSystem.questions.Length)
        {
            DisplayQuestion(questionSystem); 
        }
        else
        {
            StartCoroutine(SuccessDelay()); 
        }
    }


    IEnumerator FailedDelay (){
        FailedPanel.SetActive(true);
        quizPanel.SetActive(false);
        currentQuestionSystem.canStart = true;
        currentQuestionIndex = 0;
        yield return new WaitForSeconds(5.0f);
        FailedPanel.SetActive(false);
    }

    IEnumerator SuccessDelay (){
        SuccessPanel.SetActive(true);
        quizPanel.SetActive(false);
        yield return new WaitForSeconds(5.0f);
        SuccessPanel.SetActive(false);
        currentQuestionSystem.IsCompleted = true;
        currentQuestionSystem.canStart = false;
        currentQuestionIndex = 0;
    }

    public void selfDestruct(){
        currentQuestionSystem.IsCompleted = true;
        currentQuestionSystem.canStart = false;
    }
}
