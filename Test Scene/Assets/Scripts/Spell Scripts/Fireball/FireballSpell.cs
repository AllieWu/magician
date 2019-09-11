using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSpell : Spell
{
    private Vector3 look;
    public GameObject fbPrefab;
    private Quaternion rotation;

    public FireballSpell(float cd, float dm, float ct) : base(cd, dm, ct)
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
