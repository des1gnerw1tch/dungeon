using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgress : MonoBehaviour
{
    [Header("NPC Progress")]
    public static bool wizardFreed = false;
    public static bool merchantFreed = false;

    //when game is running, these variables will always stay. this resets them
    public static void ResetStaticVariables()  {
      wizardFreed = false;
      merchantFreed = false;
    }
}
