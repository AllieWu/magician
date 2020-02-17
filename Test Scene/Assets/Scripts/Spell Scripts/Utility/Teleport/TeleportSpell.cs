using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportSpell : Spell
{
    private Vector3 point, look;
    public GameObject epPrefab;
    private Quaternion rotation;
    private Camera cam;

    public TeleportSpell(float cd, float dm, float ct) : base(cd, dm, ct)
    {
        //
    }

    private void Start()
    {
        cam = Camera.main;
    }

    public override void Cast()
    {
        point = cam.ScreenToWorldPoint(Input.mousePosition);
        look = GetComponent<PlayerController>().lookDirection.normalized;
        rotation = Quaternion.LookRotation(Vector3.forward, look);
        StartCoroutine(WaitAndCast(castTime));
    }

    private IEnumerator WaitAndCast(float castTimer)
    {
        yield return new WaitForSecondsRealtime(castTimer);
        Instantiate(epPrefab, new Vector2(point.x, point.y), rotation);
    }
}
