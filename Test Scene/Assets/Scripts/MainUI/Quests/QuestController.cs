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
        quest = newQuest;

        if (newQuest == null)
            Debug.Log("newQuest is null");

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
        UpdateText();
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
            Debug.Log("QuestController UpdateText() called!, changing text to: empty quest");
            titleText.text = goldText.text = expText.text = "";
            return;
        }

        Debug.Log("QuestController UpdateText() called!, changing text to: " + quest.GetGoldReward());
        titleText.text = quest.GetQuestTitle();
        goldText.text = quest.GetGoldReward() + "Gold";
        expText.text = quest.GetExpReward() + "EXP";
        Debug.Log(Quests.instance.quests.Count);
    }

    public Quest GetQuest()
    {
        return quest;
    }
}