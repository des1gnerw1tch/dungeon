﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameFrameRate : MonoBehaviour
{
    public int maxFrameRate = 60;
    // Start is called before the first frame update
    void Start()
    {
      Application.targetFrameRate = maxFrameRate;
    }

}
