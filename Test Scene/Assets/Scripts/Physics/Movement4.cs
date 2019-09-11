using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement4 : MonoBehaviour
{
    public float speed;                                             // Player's Movement Speed
    private float moveHorizontal, moveVertical;                     // x input, y input
    public Vector3 movement;                                        // Where the player wants to move, where the player does move based on obstacles, where the obstacles are
    public Rigidbody2D body;                                        // The object being moved

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
        movement = new Vector3(moveHorizontal, moveVertical);

        body.AddForce(movement.normalized * speed * Time.deltaTime);
    }
}