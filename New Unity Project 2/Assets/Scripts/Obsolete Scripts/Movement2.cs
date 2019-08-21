using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{
    public float speed, moveHorizontal, moveVertical, moveLimiter = Mathf.Sqrt(2)/2;                    // Player's movement speed, x input, y input, speed restrictor.
    public RaycastHit2D hit, tlhit, trhit, blhit, brhit, chit;                                                // RaycastHit2D to detect if the intended motion is allowed (center, top left, top right, bottom left, bottom right
    public Vector2 movement, movementProjected, boundary;                                               // Where the player wants to move, where the player does move based on obstacles, where the obstacles are
    public Transform body;                                                                              // The object being moved
    public bool movementAllowedx, movementAllowedy;                                                     // If movement is allowed in a certain direction based on the raycast

    void Start()
    {
        body = GetComponent<Transform>();
        movementAllowedx = true;
        movementAllowedy = true;
    }

    void FixedUpdate()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        moveVertical = Input.GetAxisRaw("Vertical");
        movement = new Vector2(moveHorizontal, moveVertical);

        if (movement != Vector2.zero)
        {
            chit = Physics2D.CircleCast(body.position, 25, movement, Mathf.Infinity, 1280);
            //Debug.Log("Hit: " + chit.transform.tag);
            //Debug.Log("Dist: " + chit.distance + ", circle");
        }
        else
        {
            chit = Physics2D.BoxCast(body.position, body.localScale, 0, Vector2.up, Mathf.Infinity, 1280);
            //Debug.Log("Hit: " + chit.transform.tag);
            //Debug.Log("Dist: " + chit.distance + ", box");
        }
        



        /* Must Add:
         * @Raycast has to find where you can and cant go (circlecast or boxcast probably) (look into layermasks)
         * @Have to compare movement to boundaries to see if movement is allowed in x and y
         * @Make a boundary vector on restricted axis for projection
        */



        if (movementAllowedx && movementAllowedy)
        {
            //Debug.Log("movement: " + movement + ", Time: " + Time.deltaTime);

            if (moveHorizontal != 0 && moveVertical != 0)
            {
                body.position += (Vector3)(movement * speed * moveLimiter * Time.deltaTime);
            }
            else
            {
                body.position += (Vector3)(movement * speed * Time.deltaTime);
            }

            Debug.Log("x: " + movementAllowedx + ", y: " + movementAllowedy);
        }
        else if (!movementAllowedx && !movementAllowedy)
        {
            Debug.Log("Cant Move");
        }
        else if (!movementAllowedx || !movementAllowedy)
        {
            movementProjected = Vector3.Project(movement, boundary);

            if (moveHorizontal != 0 && moveVertical != 0)
            {
                body.position += (Vector3)(movementProjected * speed * moveLimiter * Time.deltaTime);
            }
            else
            {
                body.position += (Vector3)(movementProjected * speed * Time.deltaTime);
            }

            //Debug.Log("x: " + movementAllowedx + ", y: " + movementAllowedy);
        }
        else
        {
            Debug.Log("Movement_Allowed_Error");
        }
        
    }
}