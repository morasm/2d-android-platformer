using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    private float hSpeed = 25.0f;

    private float vSpeed = 15.0f;
    private float verticalRange = 0.70f;
    private float horizontalRange = 5.0f;

    private bool movingRight;
    private bool movingUp;


    private float startX;

    private float startY;

    private Rigidbody2D m_Body;

    // Start is called before the first frame update
    void Start()
    {
        m_Body = GetComponent<Rigidbody2D>();
        startX = m_Body.transform.position.x;
        startY = m_Body.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (hSpeed > 0){
            movingRight = true;
        }else{
            movingRight = false;
        }

        if (vSpeed > 0){
            movingUp = true;
        }else{
            movingUp = false;
        }

        m_Body.velocity = new Vector2(hSpeed * Time.fixedDeltaTime * 10f,
        vSpeed * Time.fixedDeltaTime * 5f);
        if((m_Body.transform.position.x > startX + horizontalRange  && movingRight) 
        ||(m_Body.transform.position.x < startX - horizontalRange  && !movingRight)){
            		hSpeed *= -1;
        }
        if((m_Body.transform.position.y > startY + verticalRange  && movingUp) 
        ||(m_Body.transform.position.y < startY - verticalRange  && !movingUp)){
            		vSpeed *= -1;
        }
    }
}
