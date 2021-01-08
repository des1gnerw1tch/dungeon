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
    private GameObject[] skellyKnightSpawners;
    [SerializeField]
    private GameObject bigChest;
    [SerializeField]
    private GameObject happyMusicPlayer;
    [SerializeField]
    private GameObject friend;
    [SerializeField]
    private GameObject Markers;
    [SerializeField]
    private GameObject[] Marker;

    [SerializeField]
    private DialogueTrigger noPowerDialogue;
    [SerializeField]
    private DialogueTrigger poweredDialogue;
    public static bool powerOn = false;

    void Start()  {

      if (!powerOn) {
        //sirens not going off
        if (!PlayerProgress.friendFreed)
          panCam.SetActive(true);
        happyMusicPlayer.SetActive(true);
        bigChest.SetActive(false);
      } else {
          //if power is on turn off all lights and turn on warning light
          Light2D[] lights = FindObjectsOfType<Light2D>();
          foreach (Light2D light in lights) {
            light.gameObject.SetActive(false);
          }
          warningLight.SetActive(true);
          //turn on skelly knight spawners
          foreach (GameObject spawner in skellyKnightSpawners)  {
            spawner.SetActive(true);
          }

          bigChest.SetActive(true);
          Marker[1].SetActive(false);
          Marker[0].SetActive(true);
          StartCoroutine(StopSiren());
        }

      if (PlayerProgress.friendFreed) {
        friend.SetActive(false);
        Markers.SetActive(false);
      }



    }
    public void BuildBridge() {
      if (powerOn)  {
        Marker[2].SetActive(true);
        removableLava.SetActive(false);
        poweredDialogue.TriggerDialogue();
        switchAnimator.SetTrigger("flip");
      }
      else  {
        noPowerDialogue.TriggerDialogue();
        FindObjectOfType<AudioManager>().Play("negative");
        Marker[0].SetActive(false);
        Marker[1].SetActive(true);
      }

    }

    IEnumerator StopSiren() {
      yield return new WaitForSeconds(20f);
      //FindObjectOfType<AudioManager>().Stop("siren");
    }
}
