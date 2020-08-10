using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabController : MonoBehaviour
{
    private float hSpeed = 15.0f;

    private float horizontalRange = 4.0f;

    private bool movingRight;

    private float startX;

    private float startY;

    private Rigidbody2D crabBody;

    // Start is called before the first frame update
    void Start()
    {
        crabBody = GetComponent<Rigidbody2D>();
        startX = crabBody.transform.position.x;
        startY = crabBody.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (hSpeed > 0){
            movingRight = true;
        }else{
            movingRight = false;
        }

        crabBody.velocity = new Vector2(hSpeed * Time.fixedDeltaTime * 10f,
        0);
        if((crabBody.transform.position.x > startX + horizontalRange  && movingRight) 
        ||(crabBody.transform.position.x < startX - horizontalRange  && !movingRight)){
            		hSpeed *= -1;
        }
    }
}
