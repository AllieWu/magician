using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Druid : BaseJob
{
    public string jobName { get; set; }
    public int[] spellids { get; set; } // required to initialize this inherited value

    public void initialize()
    {
        jobName = "Druid";
        spellids = new int[] { 2 }; // 3 represents earthpillar spell 
    }

}
