using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellListButton : MonoBehaviour
{
    public Button button;
    public Text spellName;
    public Image spellIcon;

    private SpellSlot spellSlot;
    private SpellScrollList scrollList;

    void Start()
    {
        
    }

    public void Setup(SpellSlot currentSpell, SpellScrollList currentScrollList)
    {
        spellSlot = currentSpell;
        spellName.text = spellSlot.spellName;
        spellIcon.sprite = spellSlot.icon;

        scrollList = currentScrollList;
    }
}
