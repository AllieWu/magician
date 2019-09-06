using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{

    #region Singleton
    public static Player instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

    int Level { get; set; }
    string Name { get; set; }
    double ExperiencePoints { get; set; }
    double HitPoints { get; set; }
    double mastery_fire { get; set; }
    double mastery_water { get; set; }
    double mastery_earth { get; set; }
    double mastery_wind { get; set; }

    public Quest[] quests = { };
}