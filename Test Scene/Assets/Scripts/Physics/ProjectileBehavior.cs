using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public float damage, speed;
    private Vector2 direction;
    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        direction = GameObject.Find("Player").GetComponent<PlayerController>().lookDirection;
    }

    private void FixedUpdate()
    {
        rb2d.AddForce(direction.normalized * speed * Time.deltaTime);
    }

    /*
    // What happens when the projectile hits another object with a collider
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Boundary")
        {
            //Debug.Log("Hit Wall");
            Destroy(this.gameObject);
        }
        else if(col.tag == "Enemy")
        {
            //Debug.Log("Hit Enemy");
            col.gameObject.GetComponent<EnemyController>().DealDamage(damage);
            Destroy(this.gameObject);
        }
    }
    */

    private void OnCollisionEnter2D(Collision2D col)
    {
        //Debug.Log("Collision");
        if (col.gameObject.tag == "Boundary")
        {
            //Debug.Log("Hit Wall");
            Destroy(this.gameObject);
        }
        else if (col.gameObject.tag == "Enemy")
        {
            //Debug.Log("Hit Enemy");
            col.gameObject.GetComponent<Unit>().DealDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
