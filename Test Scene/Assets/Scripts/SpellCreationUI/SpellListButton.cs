using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellListButton : MonoBehaviour
{
    public Button button;
    public Text spellName;
    public Image spellIcon;

    private SpellInfo spellSlot;
    private SpellScrollList scrollList;

    void Start()
    {
        button.onClick.AddListener(HandleClick);
    }

    public void Setup(SpellInfo currentSpell, SpellScrollList currentScrollList)
    {
        spellSlot = currentSpell;
        spellName.text = spellSlot.spellName;
        spellIcon.sprite = spellSlot.icon;
        scrollList = currentScrollList;
    }

    public void HandleClick()
    {
        //should be something along the lines of scrollList.DisplaySpellInfo(spellSlot);
        //need to make a DisplaySpellInfo() function first
        //
        //Need to make a SpellInfoScreen class that gets attached to specific spell info canvas
        //  which has the DisplaySpellInfo() function attached
        //Specific spell info canvas should show the different tiers
        //  locked is black and unclickable
        //  unlocked but not craftable is grey and clickable
        //    will show stats and what materials are necessary
        //    necessary to see which materials you need more of and which you already have
        //  unlocked and craftable will be completely opaque
        //    will also show stats and necessary 
        //  should only have the number of tiers that that spell has 
        //Eventually want to implement something similar into the spell scroll list that has the color codes for
        //  unlocked, but not creatable and also unlocked and creatable
        //Also want to make scroll list sortable by 2 levels:
        //  1. craftable
        //  2. type
        //       element
        //       etc
        //
        //Should have a child object called MaterialsContainer which will have all the slots
        //  for materials and they will activate and deactivate as needed
        //Should also have a similar thing for stats, but instead of activating and deactivating
        //  they will just populate and depopulate
        //
        //Similar DisplayAnimation and DisplayModifiers classes/functions will have to be created
        //
        //Obviously need to add art to this whole UI
        //Make sure the UI pauses the game
    }
}
