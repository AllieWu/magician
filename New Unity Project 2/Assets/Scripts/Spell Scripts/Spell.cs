using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell : MonoBehaviour
{
    public float damage, cooldown, castTime;

    public Spell(float cd, float dm, float ct)
    {
        this.cooldown = cd;
        this.damage = dm;
        this.castTime = ct;
    }

    public abstract void Cast();
}
