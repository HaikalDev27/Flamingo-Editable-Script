using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public KeyCode pauseKey;
    public bool isActive;
    public bool canPause;

    void Update(){
        if(Input.GetKeyDown(pauseKey) && canPause){
            if(pauseMenu.activeInHierarchy){
                pauseMenu.SetActive(false);
                Time.timeScale = 1f;
            } else {
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
            }
        }

        if(isActive){
            canPause = false;
            return;
        }
    }

    public void Active(){
        isActive = true;
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
