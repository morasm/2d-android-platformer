using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeLeft;
    public Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        timeLeft = 300;
        timerText.text = "Time left: " + timeLeft.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.fixedDeltaTime;
        if(timeLeft > 0){
            timerText.text = "Time left: " + timeLeft.ToString("F1");
        }else{
            FindObjectOfType<GameManager>().OutOfTime();
        }
        
    }
}
