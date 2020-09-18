using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : Spell
{
    public Laser(float cd, float dm, float ct, bool ul, string ac, string sn, int id) : base(cd, dm, ct, ul, ac, sn, id)
    {
        //fbPrefab = GameObject.Find("Fireball");

    }

    public override void Cast()
    {
        
    }
}
