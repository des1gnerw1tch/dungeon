﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueDungeonManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private BoxCollider2D completedDialogue;
    [SerializeField]
    private BoxCollider2D portal;
    [SerializeField]
    private GameObject Marker;
    void Start()
    {
      UpdateScene();
        if (PlayerProgress.alchemistFreed)
        {
            Marker.SetActive(false);
        }
    }

    // Update is called once per frame
    void UpdateScene()
    {
      if (PlayerProgress.alchemistFreed)  {
        completedDialogue.enabled = true;
        portal.enabled = false;
      } else {
        completedDialogue.enabled = false;
        portal.enabled = true;
      }
    }
}
