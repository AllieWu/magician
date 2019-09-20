using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuestController : MonoBehaviour
{
    public Quest quest = null;
    public Text titleText;
    public Text goldText;
    public Text expText;


    private void Start()
    {
        if (quest != null && quest.GetQuestStatus())
        {
            UpdateText();
            Debug.Log(quest.GetQuestInfo());
        }

    }

    public void AddQuest(Quest newQuest)
    {
        if (quest != null)
            return;

        quest = newQuest;
        UpdateText();
    }

    // Clear the slot
    public void ClearSlot()
    {
        if (quest != null)
        {
            quest = null;

            RemoveQuestFromQuests();
        }
    }


    // If the remove Quest is pressed, this function will be called.
    public void RemoveQuestFromQuests()
    {
        Debug.Log("quest slot RemoveQuestFromQuests() called");
        Quests.instance.Remove(quest);
        UpdateText();
    }


    public void UpdateText()
    {
        if (quest == null)
        {
            titleText.text = goldText.text = expText.text = "";
            return;
        }

        titleText.text = quest.GetQuestTitle();
        goldText.text = quest.GetGoldReward() + "Gold";
        expText.text = quest.GetExpReward() + "EXP";
    }

    public Quest GetQuest()
    {
        return quest;
    }
}