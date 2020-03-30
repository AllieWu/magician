using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monk : BaseJob
{
    public string jobName { get; set; }
    public int[] spellids { get; set; } // required to initialize this inherited value

    public void initialize()
    {
        jobName = "Monk";
        spellids = new int[] { 1 }; // 1 represents tsunami spell
    }

}
