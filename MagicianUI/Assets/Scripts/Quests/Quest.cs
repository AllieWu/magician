using UnityEngine;


[CreateAssetMenu(fileName = "New Quest", menuName = "Quest/New Quest")]
public class Quest : ScriptableObject
{
    public bool isActive;
    public string title;
    public string description;
    public int expReward;
    public int goldReward;

    public QuestGoal goal;

    public void Complete()
    {
        isActive = false;
        Debug.Log("Finished Quest!");
    }

    public string GetQuestInfo()
    {
        return ($"\tName: {title} || Description: {description} || Reward: {expReward}xp and {goldReward}g || Status: {isActive}");
    }
}

