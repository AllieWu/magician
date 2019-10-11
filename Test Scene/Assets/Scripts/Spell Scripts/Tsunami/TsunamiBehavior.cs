using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TsunamiBehavior : MonoBehaviour
{
    public float knockback, speed, timeLimit;
    private float spawnTime;
    private Vector2 direction;
    private Rigidbody2D rb2d;
    private TsunamiSpell t;
    private ArrayList hit;

    private void Start()
    {
        t = GameObject.Find("Player").GetComponent<TsunamiSpell>();
        rb2d = GetComponent<Rigidbody2D>();
        direction = GameObject.Find("Player").GetComponent<PlayerController>().lookDirection;
        spawnTime = Time.time;
        hit = new ArrayList();

        // Change color
        Renderer rend = GetComponent<Renderer>();
        Material mat = new Material(Shader.Find("Standard"));
        mat.color = Color.cyan;
        rend.material = mat;
    }

    private void FixedUpdate()
    {
        if(Time.time > spawnTime + timeLimit)
        {
            Destroy(gameObject);
        }
        
        rb2d.AddForce(direction.normalized * speed * Time.deltaTime);
    }

    // What happens when the projectile hits another object with a collider
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);
        }
        else if (col.gameObject.tag == "Enemy")
        {
            if (!hit.Contains(col.otherRigidbody))
            {
                col.gameObject.GetComponent<EnemyController>().DealDamage(t.damage);
                DoKnockback(col.otherRigidbody);
                hit.Add(col.otherRigidbody);
            }
        }
    }

    private void DoKnockback(Rigidbody2D body)
    {
        body.AddForce(direction.normalized * Time.deltaTime * knockback * (2 * (Time.time - spawnTime) + 1.5f) * 25);
    }
}