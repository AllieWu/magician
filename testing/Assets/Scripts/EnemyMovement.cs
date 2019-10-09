using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        body.freezeRotation = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        body.velocity = new Vector2(-.05f, 0); // move at normal speed
    }
}
