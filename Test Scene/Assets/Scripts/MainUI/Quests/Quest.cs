using UnityEngine;


[CreateAssetMenu(fileName = "New Quest", menuName = "Quest/New Quest")]
public class Quest : ScriptableObject
{
    public bool isActive = false;
    public string title = "";
    public string description = "";
    public int expReward = 0;
    public int goldReward = 0;

    public QuestGoal goal;

    private void OnEnable()
    {
        System.Random rnd = new System.Random();
        isActive = true;
        title = "New Quest";
        description = "This Quest is new. Wow. Awesome.";
        expReward = rnd.Next(0, 100);
        goldReward = rnd.Next(0, 100);
        goal = CreateInstance<QuestGoal>();
    }

    public void Complete()
    {
        isActive = false;
        Quests.instance.Remove(this);
        Debug.Log("Finished Quest!");
    }

    public string GetQuestInfo()
    {
        return ($"\tName: {title} || Description: {description} || Reward: {expReward}xp and {goldReward}g || Status: {isActive}");
    }

    public bool GetQuestStatus()
    {
        return isActive;
    }

    public string GetQuestTitle()
    {
        return title;
    }

    public string GetQuestDescription()
    {
        return description;
    }

    public string GetExpReward()
    {
        return expReward.ToString();
    }

    public string GetGoldReward()
    {
        return goldReward.ToString();
    }
}

