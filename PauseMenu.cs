using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public KeyCode pauseKey;

    void Update(){
        if(Input.GetKeyDown(pauseKey)){
            if(pauseMenu.activeInHierarchy){
                pauseMenu.SetActive(false);
                Time.timeScale = 1f;
            } else {
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }

    public void Back(){
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

    public void Resume(){
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Quit(){
        Application.Quit();
    }

    public void Pronoun(){
        SceneManager.LoadScene("Sunny Scene (Pronoun)");
    }
    public void SimplePastTense(){
        SceneManager.LoadScene("Morning Scene (Simple Past Tense)");
    }
    public void PresentContinous(){
        SceneManager.LoadScene("Night Scene (Present Continuous tense)");
    }
    public void SingularPlural(){
        SceneManager.LoadScene("Midnight Scene (Singular Plural)");
    }
    public void SImpleFuture(){
        SceneManager.LoadScene("Evening Scene (Future Tense)");
    }
}
