using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralCollider : MonoBehaviour
{
    
    private Rigidbody2D body;
    public float defaultRunSpeed;
    private float currentRunSpeed;

    float horizontal;
    float vertical;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if(body.vector2D.x > 0)




        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up);

        if(hit.collider != null)
        {
            float distance = Mathf.Abs(hit.point.y - transform.position.y);
            Debug.Log("raycast hit");
        }

        
        playerMovement();
    }



    void playerMovement()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        body.velocity = new Vector2(0, 0);
    }
}
