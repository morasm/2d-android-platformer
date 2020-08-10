using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;
    public void PauseGame()
    {
        if(!isPaused){
            Time.timeScale = 0f;
            isPaused = true;
            pauseMenuUI.SetActive(true);
        }
    }

    public void Resume(){
        if(isPaused){
            Time.timeScale = 1f;
            isPaused = false;
            pauseMenuUI.SetActive(false);
        }
    }

    public void Quit(){
            SceneManager.LoadScene("Menu");
    }
}
