using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    public GameObject playerObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("collided kids");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Usable")
        {
            Debug.Log("damage taken: " + playerObject.GetComponent<CharacterHealth>().currentHealth);
            playerObject.GetComponent<CharacterHealth>().DealDamage(5);
            Destroy(col.gameObject);
        }
    }
}