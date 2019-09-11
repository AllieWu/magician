using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RangedEnemyController : MonoBehaviour
{
    [Header("ID Settings")]
    private float maxHealth;
    private float currentHealth;
    private bool dead;
    public Image enemyHealthBar;
    private int xp, damage;
    public int level;

    [Header("Movement Settings")]
    private Transform target, enemy;
    private Rigidbody2D rb2d;
    private Vector2 direction, targetPosition;
    public int speed;

    void Start()
    {
        maxHealth = Mathf.Ceil(10 + level ^ (3 / 2));
        xp = 10 * level;
        damage = 2 * level;
        currentHealth = maxHealth;
        dead = false;
        enemyHealthBar.fillAmount = currentHealth / maxHealth;

        rb2d = GetComponent<Rigidbody2D>();
        target = GameObject.Find("Player").transform;
        enemy = GetComponent<Transform>();
    }

    // ENEMY MOVEMENT
    void FixedUpdate()
    {
        targetPosition = new Vector2(target.position.x, target.position.y);
        direction = targetPosition - rb2d.position;
        rb2d.AddForce(direction.normalized * speed * Time.deltaTime);
    }

    void FireProjectile()
    {
        // Fires a projectile similar to the player's
    }

    public void DealDamage(float damageDealt)
    {
        if (!dead)
        {
            currentHealth -= damageDealt;
            enemyHealthBar.fillAmount = currentHealth / maxHealth;

            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        currentHealth = 0;
        dead = true;
        Destroy(this.gameObject);
        GameObject.Find("Enemy Spawner").GetComponent<EnemySpawner>().enemiesKilled++;
        GameObject.Find("Player").GetComponent<PlayerController>().AddXP(xp);
    }

    // Deals damage every so often if the player if they stay in contact with the enemy
    // Ranged character won't attack on contact, but will if you stay in contact
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //implement this
        }
    }
}
