using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeathTextDisplay : MonoBehaviour
{
    private static bool isDead;
    public Text deathText;

    // Start is called before the first frame update
    void Start()
    {
        deathText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        isDead = CharacterHealth.dead;

        if(isDead)
        {
            deathText.enabled = true;
            //Debug.Log("if statement read");
        }
    }
}
