using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement3 : MonoBehaviour
{
    public float speed, moveHorizontal, moveVertical, 
                    moveLimiter = Mathf.Sqrt(2) / 2;                       // Player's movement speed, x input, y input, speed restrictor.
    public Vector3 movement;                                               // Where the player wants to move, where the player does move based on obstacles, where the obstacles are
    public Transform body;                                                 // The object being moved
    public Quaternion rotation;                                            // Controls the rotation of the body

    void Start()
    {
        body = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
        movement = new Vector3(moveHorizontal, moveVertical);

        if (moveHorizontal != 0 && moveVertical != 0)
        {
            body.position += (movement * speed * moveLimiter * Time.deltaTime);
        }
        else
        {
            body.position += (movement * speed * Time.deltaTime);
        }
    }
}