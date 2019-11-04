using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SpellSlot
{
    public string spellName;
    public Sprite icon;
}

public class SpellScrollList : MonoBehaviour
{
    public List<SpellSlot> spellList;
    public Transform contentPanel;
    public SimpleObjectPool buttonObjectPool;

    // Start is called before the first frame update
    void Start()
    {
        RefreshDisplay();
    }

    private void RefreshDisplay()
    {
        AddButtons();
    }

    private void AddButtons()
    {
        for (int i = 0; i < spellList.Count; i++)
        {
            SpellSlot spell = spellList[i];
            GameObject newButton = buttonObjectPool.GetObject();
            newButton.transform.SetParent(contentPanel);

            SpellListButton sampleSpelllButton = newButton.GetComponent<SpellListButton>();
            sampleSpelllButton.Setup(spell, this);
        }
    }
}
