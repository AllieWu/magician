using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class LaserBehavior : MonoBehaviour
{
    private Laser ls;
    private Vector2 direction;
    private Rigidbody2D rb2d;

    public void Start()
    {
        ls = GameObject.Find("Player").GetComponent<Laser>();
    }

    public void FixedUpdate()
    {
        direction = GameObject.Find("Player").GetComponent<PlayerController>().lookDirection;
        
    }

    // What happens when the projectile hits another object with a collider
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Boundary")
        {
            //end the laser's path
        }
        else if (col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<Unit>().DealDamage(ls.damage);
            //end the laser's path
        }
    }
}