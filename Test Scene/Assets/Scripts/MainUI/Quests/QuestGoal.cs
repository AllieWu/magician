using UnityEngine;
using System.Collections;


public enum GoalType
{
    Kill,
    Gather,
    Deliver,
    Main
}


[CreateAssetMenu(fileName = "New Quest Goal", menuName = "Quest/New Quest Goal")]
public class QuestGoal : ScriptableObject
{
    public GoalType goalType;
    public int requiredAmt;
    public int currentAmt;


    private void OnEnable()
    {
        System.Random rnd = new System.Random();
        goalType = GoalType.Kill;
        requiredAmt = rnd.Next(0, 50);
        currentAmt = 0;
    }

    public bool IsReached()
    {
        return (currentAmt >= requiredAmt);
    }

    public void EnemyKilled()
    {
        if (goalType == GoalType.Kill)
            currentAmt++;
    }

    public void ItemCollected()
    {
        if (goalType == GoalType.Gather)
            currentAmt++;
    }

    public void DeliveryFinished()
    {
        if (goalType == GoalType.Deliver)
            currentAmt++;
    }

    public void MainFinished()
    {
        if (goalType == GoalType.Main)
            currentAmt++;
    }
}