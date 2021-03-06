﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item {
    public string name;
    public string type;
    public GameObject item;
    public GameObject canvasImage;
    public bool isHealthPotion;
    public bool isSpeedPotion;
    public bool isRegenPotion;
    public bool isFocusPotion;
}
