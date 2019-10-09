using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movemnt : MonoBehaviour
{

    public float runSpeed;
    public float moveLimiter;

    float horizontal;
    float vertical;

    private Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        body.freezeRotation = true;
    }

    void FixedUpdate()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        if (horizontal == 0 && vertical == 0)
        {
            body.velocity = new Vector2(0, 0);
        }
        else
        {
            if (horizontal != 0 && vertical != 0) // Check for diagonal movement
                body.velocity = new Vector2((horizontal * runSpeed) * moveLimiter, (vertical * runSpeed) * moveLimiter); // move at less speed 
            else // if not moving diagonally
                body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed); // move at normal speed
        }
        

    }
}