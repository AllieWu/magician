using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;
    //public Player player;

    public Text titleText;
    public Text descText;
    public Text expText;
    public Text goldText;


    public void UpdateQuestWindow()
    {
        titleText.text = quest.title;
        descText.text = quest.description;
        expText.text = (quest.expReward).ToString();
        goldText.text = (quest.goldReward).ToString();
    }

}