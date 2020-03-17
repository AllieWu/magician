using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell : MonoBehaviour
{
    public float damage, cooldown, castTime;
    public int spellID;
    protected bool unlocked = false;
    public string availClass;

    public Spell(float cd, float dm, float ct, bool ul, string ac, int id)
    {
        cooldown = cd;
        damage = dm;
        castTime = ct;
        unlocked = ul;
        availClass = ac;
        spellID = id;
    }

    public abstract void Cast();
}
