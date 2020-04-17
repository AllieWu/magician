using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthPillarBehavior : MonoBehaviour
{
    public float timeLimit, knockback;
    private float spawnTime;
    private EarthPillar ep;
    private Vector2 dir;
    private ArrayList hit;

    private void Start()
    {
        spawnTime = Time.time;
        ep = GameObject.Find("Player").GetComponent<EarthPillar>();
        hit = new ArrayList();

        // Change color
        Renderer rend = GetComponent<Renderer>();
        Material mat = new Material(Shader.Find("Standard"));
        mat.color = new Color(140f/255f, 42f/255f, 42f/255f);
        //mat.color = Color.green;
        rend.material = mat;
    }

    private void FixedUpdate()
    {
        if(Time.time > spawnTime + timeLimit)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);
        }
        else if (col.gameObject.tag == "Enemy")
        {
            Rigidbody2D body = col.gameObject.GetComponent<Rigidbody2D>();
            if(!hit.Contains(body))
            {
                col.gameObject.GetComponent<Unit>().DealDamage(ep.damage);
                DoKnockback(body);
                hit.Add(body);
            }
        }
    }

    private void DoKnockback(Rigidbody2D body)
    {
        dir = body.position - (Vector2)gameObject.transform.position;
        body.AddForce(dir.normalized * Time.deltaTime * knockback * 25);
    }
}
