using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    //public Quaternion rotation;
    private Transform target, enemy;
    private Rigidbody2D rb2d;
    private Vector2 direction, targetPosition;
    public int speed;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Player").transform;
        enemy = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        targetPosition = new Vector2(target.position.x, target.position.y);
        direction = targetPosition - rb2d.position;
        rb2d.AddForce(direction.normalized * speed * Time.deltaTime);
    }
}