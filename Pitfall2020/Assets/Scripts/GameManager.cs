using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject OutOfTimeMenuUI;
    public GameObject RIPMenuUI;
    public GameObject WinMenuUI;
    public AudioClip acGameOver;
    public AudioClip acRIP;
    public AudioClip acWinner;

    public AudioSource asMusic;
    public void EndGame(){
        asMusic.Pause();
        AudioSource.PlayClipAtPoint(acRIP, transform.position);
        Time.timeScale = 0f;
        RIPMenuUI.SetActive(true);
    }

    public void OutOfTime(){
        asMusic.Pause();
        AudioSource.PlayClipAtPoint(acGameOver, transform.position);
        Time.timeScale = 0f;
        OutOfTimeMenuUI.SetActive(true);
    }

    public void WinningGame(){
        asMusic.Pause();
        AudioSource.PlayClipAtPoint(acWinner, transform.position);
        Time.timeScale = 0f;
        WinMenuUI.SetActive(true);
    }
}
