using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject OutOfTimeMenuUI;
    public GameObject RIPMenuUI;
    public GameObject WinMenuUI;
    public void EndGame(){
        Time.timeScale = 0f;
        RIPMenuUI.SetActive(true);
    }

    public void OutOfTime(){
        Time.timeScale = 0f;
        OutOfTimeMenuUI.SetActive(true);
    }

    public void WinningGame(){
        Time.timeScale = 0f;
        WinMenuUI.SetActive(true);
    }
}
