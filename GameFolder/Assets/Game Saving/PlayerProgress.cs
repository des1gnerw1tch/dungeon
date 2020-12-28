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
    public static bool friendFreed = false;

    //key progress
    public static bool hasBlueKey;
    public static bool hasPurpleKey;
    public static bool hasBrownKey;
    public static bool hasCrystalKey;

    //crystal dungeon progress
    public static bool blueCrystalDestroyed = false;
    public static bool greenCrystalDestroyed = false;
    public static bool redCrystalDestroyed = false;

    //other progress
    public static bool hadFirstMerchantVisit = false;

    //when game is running, these variables will always stay. this resets them
    public static void ResetStaticVariables()  {
      wizardFreed = false;
      merchantFreed = false;
      nurseFreed = false;
      alchemistFreed = false;
      friendFreed = false;

      hasBlueKey = false;
      hasPurpleKey = false;
      hasBrownKey = false;
      hasCrystalKey = false;

      blueCrystalDestroyed = false;
      greenCrystalDestroyed = false;
      redCrystalDestroyed = false;

      hadFirstMerchantVisit = false;
    }
}
