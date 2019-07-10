﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballBehavior : MonoBehaviour
{
    public float damage, splashDamage, speed, splashRadius;
    private Vector2 direction;
    private Rigidbody2D rb2d;
    private FireballSpell fb;

    private void Start()
    {
        fb = GameObject.Find("Player Body").GetComponent<FireballSpell>();
        //GetComponent<Material>().color = new Color(1, 0, 0, 1);
        rb2d = GetComponent<Rigidbody2D>();
        direction = GameObject.Find("Player Body").GetComponent<PlayerController>().lookDirection;
        //Debug.Log(direction);
    }

    private void FixedUpdate()
    {
        rb2d.AddForce(direction.normalized * speed * Time.deltaTime);
    }

    // What happens when the projectile hits another object with a collider
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Boundary")
        {
            Destroy(this.gameObject);
        }
        else if (col.tag == "Enemy")
        {
            col.gameObject.GetComponent<EnemyController>().DealDamage(fb.damage);
            DoSplash(rb2d.position, splashRadius);
            Destroy(this.gameObject);
        }
    }

    private void DoSplash(Vector3 center, float radius)
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(center, radius);
        for (int i = 0;  i < hitColliders.Length; i++)
        {
            if(hitColliders[i].gameObject.tag == "Enemy")
            {
                hitColliders[i].gameObject.GetComponent<EnemyController>().DealDamage(splashDamage);
            }
        }
    }
}
