using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSpellInfo : SpellInfo
{
    private void Awake()
    {
        spell = GameObject.Find("SpellManager").GetComponent<FireballSpell>();
        spellName = "Fireball";
        unlocked = true;
        materialsNeeded = new int[][,]
        {
            new int[,] {{1, 5}},
            new int[,] {{1, 10}, {2, 5} },
            new int[,] {{1, 25}, {2, 10}, { 3, 1 }}
        };
        spellStats = new float [3][,];
        modifiers = new int[3][];

        icon = Resources.Load("Fireball", typeof(Sprite)) as Sprite;
    }
    
    public FireballSpellInfo()
    {
        //spellName = "Fireball";
        //unlocked = true; //Need to change to an actual way to make it locked and unlocked eventually
        //spell = GameObject.Find("SpellManager").GetComponent<FireballSpell>();
    }
}
