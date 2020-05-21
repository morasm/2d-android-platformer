using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    bool jump = false;
    bool crouch = false;

    public bool isClimbing;
    public bool canClimb;
    public float climbingSpeed = 10.0f;
    public LayerMask whatIsLadder;
    public int climbDirection;
    public float runSpeed = 10.0f;
    float horizontalVelocity = 0f;
    // float verticalVelocity = 0f;

    public Joystick joystick;
    public float distanceRaycast;


    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(joystick.Horizontal) > 0.1f){
        horizontalVelocity = joystick.Horizontal * runSpeed;
        }else{horizontalVelocity = 0;}

        animator.SetFloat("Speed", Mathf.Abs(horizontalVelocity)); 

        if (joystick.Vertical >= 0.5f && !jump  && !isClimbing) {
            jump = true;
            animator.SetBool("IsJumping", true);
        } 

        if(joystick.Vertical <= -0.5f ){
            crouch = true;
        } else if(joystick.Vertical > -0.5f){
            crouch = false;
        }

    }

    public void OnLanding(){
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate()
    {
        
        controller.Move(horizontalVelocity * Time.fixedDeltaTime, crouch, jump);
        
        jump = false;
        
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distanceRaycast, whatIsLadder);
            

        if(hitInfo.collider != null){
            isClimbing = true;
        }else{
            isClimbing = false;
            animator.SetBool("IsClimbing", false);
        }

        if(isClimbing == true){
            animator.SetBool("IsClimbing",true);
            animator.SetFloat("ClimbSpeed", Mathf.Abs(joystick.Vertical));
             if(joystick.Vertical > 0.25f) {
                    climbDirection = 1;
                    
                }else if(joystick.Vertical < -0.25f){
                    climbDirection = -1;
                }else {
                    climbDirection = 0;
                    }
            controller.ChangeGravity(0);
            controller.Climb(horizontalVelocity * Time.fixedDeltaTime, (float)climbDirection * climbingSpeed);
        }else{
            controller.ChangeGravity(4);
        }
    }
}
