using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    private bool movingRight = true;

    public void Move(float hMove){
        if(hMove > 0 && !movingRight){
            Flip();
        }else if(hMove < 0 && movingRight){
            Flip();
        }
    }

    private void Flip() {
        movingRight = !movingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }
}
