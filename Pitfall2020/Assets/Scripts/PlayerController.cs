using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(1, rb.velocity.y);

        if (Input.GetMouseButtonDown(0)) {
            rb.velocity = new Vector2(rb.velocity.x, 5);
        }
    }
}
