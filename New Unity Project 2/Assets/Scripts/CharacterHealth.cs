using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterHealth : MonoBehaviour
{
    // MOVE TO PLAYER CONTROLLER FOR FINAL SCRIPT
    public float maxHealth; 
    private float currentHealth;
    public static bool dead;
    public Slider healthBar;
    
    void Start()
    {
        //maxHealth = 20.0f;
        currentHealth = maxHealth;
        dead = false;
        healthBar.value = CalculateHealth();
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            DealDamage(5);
        }
    }

    public void DealDamage(float damageDealt)
    {
        if(!dead)
        {
            currentHealth -= damageDealt;
            healthBar.value = CalculateHealth();

            if(currentHealth <= 0)
            {
                Die();
            }
        }
    }

    private float CalculateHealth()
    {
        return currentHealth / maxHealth;
    }

    private void Die()
    {
        currentHealth = 0;
        dead = true;
    }
}
