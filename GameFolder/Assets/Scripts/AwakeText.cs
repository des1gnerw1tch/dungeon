using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeText : MonoBehaviour
{
    public DialogueTrigger DialogueTriggerScript;
    void Awake()
    {
        DialogueTriggerScript.TriggerDialogue();
    }

}
