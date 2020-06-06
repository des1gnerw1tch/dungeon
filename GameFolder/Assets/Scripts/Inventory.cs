using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    public string[] item;
    public OverworldManager overworldScene;


    void Start() {
      item = new string[26];

      //if it is a new game, do not load
      if (!NewGameOnClick.newGame)  {
        FindObjectOfType<GameSaveManager>().LoadPlayer();
        overworldScene.UpdateScene();
      } else {
        NewGameOnClick.newGame = false;
      }

    }

}
