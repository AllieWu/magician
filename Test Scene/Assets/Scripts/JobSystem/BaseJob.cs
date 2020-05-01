using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface BaseJob
{
    string jobName { get; set; }
    string[] spellnames { get; set; }

    void initialize();
}
