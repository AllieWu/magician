using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell : MonoBehaviour
{
    float damage, cooldown, castTime;

    public Spell(float cd, float dam, float castTimer)
    {
        this.cooldown = cd;
        this.damage = dam;
        this.castTime = castTimer;
    }

    public abstract void Cast();
}
