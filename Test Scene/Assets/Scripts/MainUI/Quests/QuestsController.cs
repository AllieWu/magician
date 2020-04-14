
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class QuestsController : MonoBehaviour
{
    public GameObject questsUI;
    public GameObject descContainer;
    public GameObject removeButton;
    public GameObject selectedQuestSlot;
    public Text selectedQuestTitle;
    public Text selectedQuestDesc;
    public Text selectedQuestGold;
    public Text selectedQuestExp;

    // Use this for initialization
    void Start()
    {
        UpdateQuestUI(); // load quests already in questbook
        ToggleDescriptionAndRemoveButton(null);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateQuestUI();
    }

    public void UpdateQuestUI()
    {
        QuestController[] questcontrollers = GetComponentsInChildren<QuestController>();

        for (int i = 0; i < questcontrollers.Length; i++)
        {
            if (Quests.instance.quests.Count > 0)
            { 
                if (i < Quests.instance.quests.Count)
                    questcontrollers[i].AddQuest(Quests.instance.quests[i]);
                else
                    questcontrollers[i].ClearSlot();
            }
            else if (Quests.instance.quests.Count == 0)
            {
                questcontrollers[0].ClearSlot();
            }
        }
    }
 

    private void UpdateQuestDescription(Quest quest)
    {
        selectedQuestTitle.text = quest.GetQuestTitle();
        selectedQuestDesc.text = quest.GetQuestDescription();
        selectedQuestGold.text = quest.GetGoldReward() + "G";
        selectedQuestExp.text = quest.GetExpReward() + "XP";
    }


    private void ToggleDescriptionAndRemoveButton(GameObject questSlot)
    {
        if (questSlot == null)
        {
            descContainer.SetActive(!descContainer.activeSelf);
            removeButton.SetActive(!removeButton.activeSelf);
            return;
        }

        if (questSlot.GetComponent<QuestController>().GetQuest() == null && !descContainer.activeSelf && !removeButton.activeSelf)
            return;

        descContainer.SetActive(!descContainer.activeSelf);
        removeButton.SetActive(!removeButton.activeSelf);
    }


    public void UpdateSelectedQuest(GameObject questSlot)
    {
        selectedQuestSlot = questSlot;

        if (questSlot.GetComponent<QuestController>().GetQuest() != null)
            UpdateQuestDescription(selectedQuestSlot.GetComponent<QuestController>().GetQuest());

        ToggleDescriptionAndRemoveButton(questSlot);
    }


    public void RemoveSelectedQuest()
    {
        Debug.Log("RemoveSelectedQuest called!");
        if (selectedQuestSlot.GetComponent<QuestController>().GetQuest() != null)
        {
            Debug.Log("Clicked quest != null... attempting to remove!");
            //selectedQuestSlot.GetComponent<QuestController>().RemoveQuestFromQuests();
            Quests.instance.Remove(selectedQuestSlot.GetComponent<QuestController>().GetQuest());
        }

        UpdateQuestUI();
        ToggleDescriptionAndRemoveButton(null);
    }
}





   
