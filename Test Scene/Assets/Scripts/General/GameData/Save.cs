﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Save
{
    public int _currentXP { get; set; }
    public int _nextLevelXP { get; set; }
    public int _previousLevelXP { get; set; }
    public int _playerLevel { get; set; }
    public float _maxHealth { get; set; }
    public float _currentHealth { get; set; }

    public Dictionary<(int, int, string, string, bool), int> _itemsDict { get; set; }
}