using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireArrowBehavior : MonoBehaviour
{
    public float DOT, speed;
    private Vector2 direction;
    private Rigidbody2D rb2d;
    private FireArrow fa;

    private void Start()
    {
        fa = GameObject.Find("Player").GetComponent<FireArrow>();
        rb2d = GetComponent<Rigidbody2D>();
        direction = GameObject.Find("Player").GetComponent<PlayerController>().lookDirection;

        // Change color
        Renderer rend = GetComponent<Renderer>();
        Material mat = new Material(Shader.Find("Standard"));
        mat.color = Color.red;
        rend.material = mat;
    }

    private void FixedUpdate()
    {
        rb2d.AddForce(direction.normalized * speed * Time.deltaTime);
    }

    // What happens when the projectile hits another object with a collider 
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Boundary")
        {
            Destroy(this.gameObject);
        }
        else if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<Unit>().DealDamage(fa.damage);
            col.gameObject.GetComponent<Unit>().StartDOT(5, DOT);
            Destroy(this.gameObject);
        }
    }
}