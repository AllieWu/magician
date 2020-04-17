using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tsunami : Spell
{
    private Vector3 look;
    public GameObject tPrefab;
    private Quaternion rotation;

    public Tsunami(float cd, float dm, float ct, bool ul, string ac, string sn, int id) : base(cd, dm, ct, ul, ac, sn, id)
    {
        //tPrefab = GameObject.Find("Tsunami");
    }

    public override void Cast()
    {
        look = GetComponent<PlayerController>().lookDirection.normalized;
        rotation = Quaternion.LookRotation(Vector3.forward, look);
        Instantiate(tPrefab, gameObject.transform.position + look, rotation);
    }
}
