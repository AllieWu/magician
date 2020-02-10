using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class quickPlayerr : MonoBehaviour
{

    public float speed;                                             // Player's Movement Speed
    private float moveHorizontal, moveVertical;                     // x input, y input
    private Vector3 movement;                                        // Where the player wants to move, where the player does move based on obstacles, where the obstacles are
    public Rigidbody2D body;  

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
        movement = new Vector3(moveHorizontal, moveVertical);

        body.AddForce(movement.normalized * speed * Time.deltaTime);
    }
}
