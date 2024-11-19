using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionSystem : MonoBehaviour {

    public string npcName;

    [System.Serializable]
    public class Question{
        public string questionText;
        public string[] options;
        public int CorrectAnswerIndex;
    }

    [SerializeField] public Question[] questions;
    [SerializeField] public bool IsCompleted = false;
    [SerializeField] public bool canStart = true;
    [SerializeField] public TextMesh indicator;

    public void StartQuiz(){

        if (QuestionPanel.Instance == null)
        {
            Debug.LogError("QuestionPanel.Instance belum diinisialisasi! Pastikan QuestionPanel ada di scene.");
            return;
        }

        if (questions == null || questions.Length == 0)
        {
            Debug.LogError("Tidak ada pertanyaan di QuestionSystem!");
            return;
        }

        if (IsCompleted == true){
            indicator.text = "Quiz ini telah selesai";
        }

        if (canStart == true){
            Debug.Log($"{npcName} mulai quiz!");
            QuestionPanel.Instance.ShowConfirmation(this);
        }
        indicator.text = "Tekan E untuk berinteraksi";
    }

    public void FirstQuestion(){
        QuestionPanel.Instance.DisplayQuestion(this);
    }
}
