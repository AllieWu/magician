using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellInfoPanel : MonoBehaviour
{
    public Text spellToDisplay, tierSelect, materialsContainer, statsController;
    public Text[] stats;
    public Button[] tiers;
    public Sprite[] mats;

    public void Awake()
    {
        spellToDisplay.text = "Please select a spell";
        DeactivateChildren();
    }

    public void DeactivateChildren()
    {
        //Deactivates children of mats, stats, and tiers
        tierSelect.GetComponent<ChildActivator>().AbleChildren(false);
        materialsContainer.GetComponent<ChildActivator>().AbleChildren(false);
        statsController.GetComponent<ChildActivator>().AbleChildren(false);
    }

    public void DisplaySpellInfo(SpellInfo spellIQ)
    {
        DeactivateChildren();

        //Activates appropriate children
        spellToDisplay.text = spellIQ.spellName;

        for (int i = 0; i < spellIQ.materialsNeeded.Length; i++)
        {
            tierSelect.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
