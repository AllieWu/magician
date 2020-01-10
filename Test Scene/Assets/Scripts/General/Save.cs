﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Save
{
    public int currentXP = 0;
    public int nextLevelXP = 0;
    public int previousLevelXP = 0;
    public int playerLevel = 0;
    public float maxHealth = 0f;
    public float currentHealth = 0f;

    public Dictionary<(int, int, string, string, bool), int> itemsDict = new Dictionary<(int, int, string, string, bool), int>();
    public List<(int, int, string, string, bool)> keys = new List<(int, int, string, string, bool)>();
    public int space = 25;
}
