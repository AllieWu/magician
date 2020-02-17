using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBehaviour : MonoBehaviour
{
    float colliderRadius;
    void Start()
    {
        colliderRadius = GetComponent<CapsuleCollider>().radius;
    }
    void Blink()
    {
        Vector3 blinkDirection = transform.forward; 
        float blinkLength = 15.0f;
        if (Physics.Raycast(transform.position, blinkDirection, out hit, blinkLength + colliderRadius) {
            blinkLength = hit.distance - colliderRadius;
        }

        transform.position = transform.position + (blinkDirection * blinkLength);
    }


}
