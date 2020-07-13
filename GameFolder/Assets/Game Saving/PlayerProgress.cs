using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgress : MonoBehaviour
{
    //NPC Progress
    public static bool wizardFreed = false;
    public static bool merchantFreed = false;
    public static bool nurseFreed = false;
    public static bool alchemistFreed = false;

    //key progress
    public static bool hasBlueKey;
    public static bool hasPurpleKey;
    public static bool hasBrownKey;
    public static bool hasCrystalKey;

    //when game is running, these variables will always stay. this resets them
    public static void ResetStaticVariables()  {
      wizardFreed = false;
      merchantFreed = false;
      nurseFreed = false;
      alchemistFreed = false;

      hasBlueKey = false;
      hasPurpleKey = false;
      hasBrownKey = false;
      hasCrystalKey = false;
    }
}
