using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    [Header("Death Text")]
    private static bool isDead;
    public Text deathText;

    [Header("Player Level")]
    public Text xpInfo;
    public int level, currentXP, nextLevelXP;

    void Start()
    {
        deathText.enabled = false;

        level = GameObject.Find("Player Body").GetComponent<PlayerController>().playerLevel;
        nextLevelXP = GameObject.Find("Player Body").GetComponent<PlayerController>().nextLevelXP;
        currentXP = GameObject.Find("Player Body").GetComponent<PlayerController>().currentXP;
        xpInfo.enabled = true;
        xpInfo.text = "Level" + level + "     XP: " + currentXP + "/" + nextLevelXP;
    }
    
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
