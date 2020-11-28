﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettings : MonoBehaviour
{
    public static bool soundEffects = true;
    public static bool music = true;
    public static bool fancyGraphics = true;
    public static bool invertScroll = false;
    public static bool gameCompleted = false;
    public static string character;

    public static void ResetStaticVariables() {
      soundEffects = true;
      music = true;
      fancyGraphics = true;
      invertScroll = false;
    }

}
