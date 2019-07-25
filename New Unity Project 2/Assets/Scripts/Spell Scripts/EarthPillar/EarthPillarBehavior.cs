using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarthPillarBehavior : MonoBehaviour
{
    public float timeLimit;
    private float spawnTime;

    private void Start()
    {
        spawnTime = Time.time;
    }

    private void FixedUpdate()
    {
        if(Time.time > spawnTime +timeLimit)
        {
            Destroy(gameObject);
        }
    }
}
