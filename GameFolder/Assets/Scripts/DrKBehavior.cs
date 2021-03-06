﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrKBehavior : MonoBehaviour
{
  [SerializeField] private BoxCollider2D DialogueCollider;
  private GameObject Player;

  [SerializeField] private int counter = 0;
  public bool trig = false;

  [SerializeField] private GameObject[] objectsToEnable;

  void Start()  {
    Player = FindObjectOfType<PlayerMovement>().gameObject;
    counter = 0;
  }

  void OnTriggerEnter2D(Collider2D other) {
    //disable movement when talking to NPC
    if (other.CompareTag("Player")) {
      other.GetComponent<PlayerMovement>().moveSpeed = 0f;
      DialogueCollider.size = new Vector2(10, 10);
      trig = true;
    }

  }

  void Update() {
    if (trig) {
      if (Input.GetKeyDown(KeyCode.Space))  {
        counter += 1;

        //on 3rd dialogue
        if (counter == 3) {
          //start boss fight
          Player.GetComponent<PlayerMovement>().moveSpeed = 5f;
          DialogueCollider.enabled = false;
          if (PlayerSettings.music)
            FindObjectOfType<AudioManager>().Play("MDBoss");
            MusicPlayer.songPlaying = "MDBoss";
          foreach (GameObject obj in objectsToEnable)  {
            obj.SetActive(true);
          }
        }



      }
  }
  }
}
