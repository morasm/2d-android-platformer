using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    float health = 100f;

    public Joystick joystick;
    public float distanceRaycast;

    public CollectedCoins cc;
    public CollectedDiamonds collectedDiamonds;
    public Text txt;
    public Text diamondTxt;

    public Text healthTxt;
    void Start(){
        txt.text = "Scores: " + cc.points.ToString();
        diamondTxt.text = collectedDiamonds.diamonds.ToString() + "/5";
        healthTxt.text = health.ToString();
    }

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

        txt.text = "Scores: " + cc.points.ToString();
        diamondTxt.text = collectedDiamonds.diamonds.ToString() + "/5";

        if(health > 0){
            healthTxt.text = health.ToString();
        }else{
            FindObjectOfType<GameManager>().EndGame();
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

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Enemy"){
            health -= 10f;
        }else if(other.gameObject.tag == "Medicine" && health <=50){
            health += 30f;
            Destroy(gameObject);
        }
    }

}
