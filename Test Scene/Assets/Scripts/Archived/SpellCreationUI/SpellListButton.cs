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
        spellIcon = transform.Find("Image").GetComponent<Image>();
        spellIcon.sprite = spellSlot.icon;
        scrollList = currentScrollList;
    }

    public void HandleClick()
    {
        GameObject.Find("SpellInfo").GetComponent<SpellInfoPanel>().DisplaySpellInfo(spellSlot);
        //Debug.Log("Clicked");
    }
}
