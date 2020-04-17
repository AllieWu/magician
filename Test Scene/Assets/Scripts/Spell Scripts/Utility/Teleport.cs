using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : Spell
{
    public Teleport(float cd, float dm, float ct, bool ul, string ac, string sn, int id) : base(cd, dm, ct, ul, ac, sn, id)
    {
    }

    public override void Cast()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f);
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector3 deltaPosition = mousePosition - transform.position;
        transform.position += Vector3.ClampMagnitude(deltaPosition, 10f);
    }
}
