using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monk : BaseJob
{
    public string jobName { get; set; }
    public string[] spellnames { get; set; } // required to initialize this inherited value

    public void initialize()
    {
        jobName = "Monk";
        spellnames = new string[] { "Tsunami", "KnockbackPunch" };
    }

}
