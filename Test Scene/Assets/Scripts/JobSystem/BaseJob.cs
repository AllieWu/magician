using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface BaseJob
{
    string jobName { get; set; }
    int[] spellids { get; set; }

    void initialize();
}
