using System.Collections.Generic;
using UnityEngine;


public class Quests : MonoBehaviour
{

    #region Singleton
    public static Quests instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Duplicate Quests");
            return;
        }
        instance = this;
    }
    #endregion


    public delegate void OnQuestChanged();
    public OnQuestChanged OnQuestChangedCallBack;

    public List<Quest> quests = new List<Quest>(); // Our current list of items in the inventory
    public int space = 25;  // Amount of item spaces


    private void Start()
    {
        //Debug.Log("Quests.cs Start()");
    }


    // Add a new quest if enough room
    public void Add(Quest quest)
    {
        if (quest.isActive)
        {
            if (quests.Count >= space)
            {
                Debug.Log("Not enough room.");
                return;
            }

            Debug.Log("Adding Quest:");
            Debug.Log(quest.GetQuestInfo());
            quests.Add(quest);

            //if (OnQuestChangedCallBack != null)
            //   OnQuestChangedCallBack.Invoke();
        }
    }


    // Remove an quest
    public void Remove(Quest quest)
    {
        quests.Remove(quest);

        //if (OnQuestChangedCallBack != null)
        //    OnQuestChangedCallBack.Invoke();
    }


}