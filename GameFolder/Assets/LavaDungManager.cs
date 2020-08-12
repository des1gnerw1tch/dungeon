using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaDungManager : MonoBehaviour
{
    [SerializeField]
    private GameObject removableLava;

    [SerializeField]
    private DialogueTrigger noPowerDialogue;
    [SerializeField]
    private DialogueTrigger poweredDialogue;
    public static bool powerOn = false;

    public void BuildBridge() {
      if (powerOn)  {
        removableLava.SetActive(false);
        poweredDialogue.TriggerDialogue();
      }
      else  {
        noPowerDialogue.TriggerDialogue();
        FindObjectOfType<AudioManager>().Play("negative");
      }

    }
}
