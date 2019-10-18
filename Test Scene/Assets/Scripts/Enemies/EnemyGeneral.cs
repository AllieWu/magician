﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyGeneral : MonoBehaviour
{
    public Image enemyHealthBar;
    public int level;
    public float speed;


    [HideInInspector]
    public float generalvariabletest = 20;
    [HideInInspector]
    public float maxHealth;
    [HideInInspector]
    public float currentHealth;
    [HideInInspector]
    public bool dead;
    [HideInInspector]
    public int xp, damage;

    public void Die()
    {
        currentHealth = 0;
        dead = true;
        Destroy(this.gameObject);
        GameObject.Find("Enemy Spawner").GetComponent<EnemySpawner>().enemiesKilled++;
        GameObject.Find("Player").GetComponent<PlayerController>().AddXP(xp);
    }
}
