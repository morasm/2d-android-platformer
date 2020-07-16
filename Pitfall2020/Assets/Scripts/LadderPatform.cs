using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderPatform : MonoBehaviour
{
    public PlatformEffector2D effector;
    public float waitTime;
    public Joystick joystick;
    public PlayerController playerController;

    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();

    }

    void Update()
    {
        if(joystick.Vertical > -0.20f ){
            waitTime = 0.5f;
            
        }

        if(joystick.Vertical < -0.20f && playerController.isClimbing){
            if(waitTime <= 0){
                effector.rotationalOffset = 180;
                waitTime = 0.5f;
            }else{
                waitTime -= Time.deltaTime;
            }
        }else if(!playerController.isClimbing || joystick.Vertical > 0.2f){//joystick.Vertical > 0.2f
            effector.rotationalOffset = 0;
        }
    
    }
}
