﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballBehavior : MonoBehaviour
{
    public float splashDamage, speed, splashRadius;
    private Vector2 direction;
    private Rigidbody2D rb2d;
    private FireballSpell fb;

    private void Start()
    {
        fb = GameObject.Find("Player").GetComponent<FireballSpell>();
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