using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;

    public static bool dead;
    public Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = 200;
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
        dead = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            DealDamage(5);
        }
    }

    public void DealDamage(int damageDealt)
    {
        if(!dead)
        {
            currentHealth -= damageDealt;
            healthBar.value = currentHealth;

            if(currentHealth <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        currentHealth = 0;
        dead = true;
    }
}