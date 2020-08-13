using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LavaDungManager : MonoBehaviour
{
    [SerializeField]
    private GameObject removableLava;
    [SerializeField]
    private GameObject panCam;
    [SerializeField]
    private GameObject warningLight;
    [SerializeField]
    private Animator switchAnimator;

    [SerializeField]
    private DialogueTrigger noPowerDialogue;
    [SerializeField]
    private DialogueTrigger poweredDialogue;
    public static bool powerOn = false;

    void Start()  {
      if (!powerOn) {
        panCam.SetActive(true);
      } else {
        //if power is on
        Light2D[] lights = FindObjectsOfType<Light2D>();
        foreach (Light2D light in lights) {
          light.gameObject.SetActive(false);
        }
        warningLight.SetActive(true);

      }
    }
    public void BuildBridge() {
      if (powerOn)  {
        removableLava.SetActive(false);
        poweredDialogue.TriggerDialogue();
        switchAnimator.SetTrigger("flip");
      }
      else  {
        noPowerDialogue.TriggerDialogue();
        FindObjectOfType<AudioManager>().Play("negative");
      }

    }
}
