using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Druid : BaseJob
{
    public string jobName { get; set; }
    public string[] spellnames { get; set; } // required to initialize this inherited value

    public void initialize()
    {
        jobName = "Druid";
        spellnames = new string[] { "EarthPillar", "Teleport" }; 
    }

}
