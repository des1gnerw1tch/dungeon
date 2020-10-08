using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettings : MonoBehaviour
{
    public static bool soundEffects = true;
    public static bool music = true;
    public static bool fancyGraphics = true;
    public static string character = "Zach";

    public static void ResetStaticVariables() {
      soundEffects = true;
      music = true;
      fancyGraphics = true;
    }

}
