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
        spellToDisplay.gameObject.SetActive(false);
        tierSelect.gameObject.SetActive(false);
        materialsContainer.gameObject.SetActive(false);
        statsController.gameObject.SetActive(false);
    }

    public void DisplaySpellInfo(SpellInfo spellIQ)
    {
        for(int i = 0; i < spellIQ.materialsNeeded.Length; i++)
        {
            spellToDisplay.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
