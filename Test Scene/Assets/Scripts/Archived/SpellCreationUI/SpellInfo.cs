using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpellInfo : MonoBehaviour
{
    public Spell spell;
    public string spellName;
    public bool unlocked;
    public int[][,] materialsNeeded;
    public float[][,] spellStats;
    public int[][] modifiers; //might just be able to make it [,] if its num of modifiers allowed, but would have to 
                              //keep it the way it is if it is which modifiers are allowed
    public Sprite icon; //set in inspector

    /*
     * Ways to implement this class:
     * 
     * option 1:
     *   hard code a spellInfo for every spell in the awake of spellCrafter
     *   
     * option 2:
     *   make this class abstract and give every spell it's own spellInfo and hard code it that way
     *   Looking like I'm going to go in this direction
     *   
     * option 3: (but prob not)
     *   make the spellList in spellCrafter or SpellScrollList public and set everything up in the inspector
     */
    
    /*
    public SpellInfo(Spell spellInQuestion,
                     bool isUnlocked,
                     int[][,] materialsRequired,
                     float[][,] stats,
                     int[][] allowedModifiers)
    {
        spell = spellInQuestion;
        unlocked = isUnlocked;
        materialsNeeded = materialsRequired;
        spellStats = stats;
        modifiers = allowedModifiers;
    }
    */
}
