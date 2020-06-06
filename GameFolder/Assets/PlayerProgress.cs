using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgress : MonoBehaviour
{
    [Header("NPC Progress")]
    public static bool wizardFreed = false;
    public static void ResetStaticVariables()  {
      wizardFreed = false;
    }
}
