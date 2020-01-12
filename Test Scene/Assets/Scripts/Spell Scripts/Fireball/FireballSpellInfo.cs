using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballSpellInfo : SpellInfo
{
    private void Awake()
    {
        spell = GameObject.Find("SpellManager").GetComponent<FireballSpell>();
        spellName = "Fireball";
    }

    public FireballSpellInfo()
    {
        //spellName = "Fireball";
        //unlocked = true; //Need to change to an actual way to make it locked and unlocked eventually
        //spell = GameObject.Find("SpellManager").GetComponent<FireballSpell>();
    }
}
