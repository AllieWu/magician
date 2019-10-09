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
            UpdateText(quest);
            Debug.Log(quest.GetQuestInfo());
        }

    }

    public void AddQuest(Quest newQuest)
    {
        if (quest != null)
            return;

        quest = newQuest;
        UpdateText(quest);
    }

    public void RemoveQuest()
    {
        if (quest == null)
            return;

        Quests.instance.Remove(quest);
        quest = null;
        UpdateText(null);
    }

    public void UpdateText(Quest quest)
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