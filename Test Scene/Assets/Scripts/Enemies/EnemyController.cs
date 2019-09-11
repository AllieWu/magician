using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    /*
     * BIG NOTES:
     * - add info scripts to every enemy to add things like level, health, dmg reduction, etc
     * - a different controller will be needed for each type of enemy
     * 
     */

    private float maxHealth;
    private float currentHealth;
    private bool dead;
    public Image enemyHealthBar;
    private int xp, damage;
    public int level;

    /*
     * Variables to be read from infoScript
     * - level
     *
     * 
     */

    
    void Start()
    {
        //level = gameObject.GetComponent<InforScript>().level;
        // ^^ example of how info script information could work
        // info script information would be calc'd in info script to remove clutter

        //level = 2;
        maxHealth = Mathf.Ceil(10 + level ^ (3/2));
        xp = 10 * level;
        damage = 2 * level;
        currentHealth = maxHealth;
        dead = false;
        enemyHealthBar.fillAmount = currentHealth / maxHealth;
    }
    
    void Update()
    {
        
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

    // Deals damage to the player if they come into contact with the enemy
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //Debug.Log("Hit Player");
            col.gameObject.GetComponent<PlayerController>().DealDamage(damage);
        }
    }

    // Deals damage every so often if the player if they stay in contact with the enemy
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //implement this
        }
    }
}
