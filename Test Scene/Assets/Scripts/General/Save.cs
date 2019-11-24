using System.Collections;
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

    public Dictionary<Item, int> itemsDict = new Dictionary<Item, int>();
    public List<Item> keys = new List<Item>();
    public int space = 25;
}
