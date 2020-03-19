using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool onGround;
    public float runSpeed = 10.0f;
    float horizontalVelocity = 0f;
    float verticalVelocity = 0f;

    public Joystick joystick;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalVelocity = joystick.Horizontal * runSpeed;
        verticalVelocity = joystick.Vertical;

        rb.velocity = new Vector2(horizontalVelocity, rb.velocity.y);
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        if (verticalVelocity >= 0.5f && onGround) {
            rb.velocity = new Vector2(rb.velocity.x, 5);
        }

    }
}
