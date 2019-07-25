﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TsunamiSpell : Spell
{
    private Vector3 look;
    public GameObject tPrefab;
    private Quaternion rotation;

    public TsunamiSpell(float cd, float dm, float ct) : base(cd, dm, ct)
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
