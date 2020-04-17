using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockbackPunch : Spell
{
    private Vector3 look;
    private Quaternion rotation;
    public float knockback;

    public KnockbackPunch(float cd, float dm, float ct, bool ul, string ac, string sn, int id) : base(cd, dm, ct, ul, ac, sn, id)
    {

    }

    public override void Cast()
    {
        look = GetComponent<PlayerController>().lookDirection.normalized;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, look, 1f, LayerMask.GetMask("Enemies"));
        Debug.DrawLine(transform.position, transform.position + look*10, Color.green, 2f, false);

        if(hit.transform != null)
        {
            hit.transform.gameObject.GetComponent<Unit>().DealDamage(damage);
            hit.rigidbody.AddForce(look * Time.deltaTime * knockback);
        }
        else
        {
            Debug.Log("No Hit");
        }
    }
}
