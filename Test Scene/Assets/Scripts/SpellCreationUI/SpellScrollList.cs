using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]

public class SpellScrollList : MonoBehaviour
{
    public List<SpellInfo> spellList;
    public Transform contentPanel;
    public SimpleObjectPool buttonObjectPool;

    private void Awake()
    {
        //adding spellInfos to the list on the inspector
    }

    // Start is called before the first frame update
    void Start()
    {
        //spellList = GameObject.Find('Whatever has the SpellCrafter Class');

        RefreshDisplay();
    }

    //If nothing gets added to this class other than AddButtons() then delete this method
    public void RefreshDisplay()
    {
        AddButtons();
    }

    private void AddButtons()
    {
        for (int i = 0; i < spellList.Count; i++)
        {
            //Debug.Log("AddButtons");
            SpellInfo spell = spellList[i];
            GameObject newButton = buttonObjectPool.GetObject();
            newButton.transform.SetParent(contentPanel);

            SpellListButton sampleSpelllButton = newButton.GetComponent<SpellListButton>();
            sampleSpelllButton.Setup(spell, this);
        }
    }
}
