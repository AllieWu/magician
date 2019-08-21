using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;             //Floating point variable to store the player's movement speed.
    private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.
    private float moveHorizontal, moveVertical, moveLimiter = Mathf.Sqrt(2)/2;

    // Use this for initialization
    void Start()
    {
        //Get and store a reference to the Rigidbody2D component so that we can access it.
        rb2d = GetComponent<Rigidbody2D>();
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        
        moveVertical = Input.GetAxisRaw("Vertical");
        
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        if(moveHorizontal != 0 && moveVertical != 0)
        {
            rb2d.velocity = (movement * speed * moveLimiter);
        }
        else
        {
            rb2d.velocity = (movement * speed);
        }

    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {

            //Destroy(col.gameObject);
        }
    }
}
