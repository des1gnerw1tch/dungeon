﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyOnContact : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)  {
      Destroy(gameObject);
    }
}