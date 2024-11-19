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

    [SerializeField]public Question[] questions;

    public void StartQuiz()
    {
        Debug.Log($"{npcName} mulai quiz!");
        QuestionPanel.Instance.DisplayQuestion(this);
    }
}
