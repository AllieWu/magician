using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spell : MonoBehaviour
{
    public float damage, cooldown, castTime;
    public int spellID;
    protected bool unlocked = false;
    public string availClass, spellName;

    public Spell(float cd, float dm, float ct, bool ul, string ac, string sn, int id)
    {
        cooldown = cd;
        damage = dm;
        castTime = ct;
        unlocked = ul;
        availClass = ac;
        spellID = id;
        spellName = sn;
    }

    public abstract void Cast();
}
