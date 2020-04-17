using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : Spell
{
    private Vector3 look;
    public GameObject fbPrefab;
    private Quaternion rotation;

    public Fireball(float cd, float dm, float ct, bool ul, string ac, string sn, int id) : base(cd, dm, ct, ul, ac, sn, id)
    {
        //fbPrefab = GameObject.Find("Fireball");
        
    }

    public override void Cast()
    {
        look = GetComponent<PlayerController>().lookDirection.normalized;
        rotation = Quaternion.LookRotation(Vector3.forward, look);
        Instantiate(fbPrefab, gameObject.transform.position + look, rotation);
    }
}
