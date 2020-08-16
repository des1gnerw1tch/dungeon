﻿using System.Collections;
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
      }

      if (PlayerProgress.friendFreed) {
        friend.SetActive(false);
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
