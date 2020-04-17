using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireArrow : Spell
{
    private Vector3 look;
    public GameObject faPrefab;
    private Quaternion rotation;

    public FireArrow(float cd, float dm, float ct, bool ul, string ac, string sn, int id) : base(cd, dm, ct, ul, ac, sn, id)
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
