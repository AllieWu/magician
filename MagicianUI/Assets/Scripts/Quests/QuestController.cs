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
        if (quest != null)
        {
            UpdateText(quest.title, quest.goldReward.ToString(), quest.expReward.ToString());
            Debug.Log(quest.GetQuestInfo());
        }

    }

    public void AddQuest(Quest newQuest)
    {
        if (quest != null)
            return;

        quest = newQuest;
        UpdateText(quest.title, quest.goldReward.ToString(), quest.expReward.ToString());
    }

    public void RemoveQuest(Quest quest)
    {
        if (quest == null)
            return;

        quest = null;
        UpdateText("", "", "");
    }

    private void UpdateText(string title, string gold, string exp)
    {
        titleText.text = title;
        goldText.text = gold + "g";
        expText.text = exp + "Xp";
    }
}