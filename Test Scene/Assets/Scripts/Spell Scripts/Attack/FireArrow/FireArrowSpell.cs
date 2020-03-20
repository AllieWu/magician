using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireArrowSpell : Spell
{
    private Vector3 look;
    public GameObject faPrefab;
    private Quaternion rotation;

    public FireArrowSpell(float cd, float dm, float ct, bool ul, string ac, int id) : base(cd, dm, ct, ul, ac, id)
    {
        //
    }

    public override void Cast()
    {
        look = GetComponent<PlayerController>().lookDirection.normalized;
        rotation = Quaternion.LookRotation(Vector3.forward, look);
        Instantiate(faPrefab, gameObject.transform.position + look, rotation);
    }
}
