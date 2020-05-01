using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// each job with contain its possible paths/abilities and the level of each ability 
public class Wizard : BaseJob 
{
    public string jobName { get; set; }
    public string[] spellnames { get; set; } // required to initialize this inherited value

    public void initialize()
    {
        jobName = "Wizard";
        spellnames = new string[]{ "Fireball", "FireArrow" }; 
    }
    
}

