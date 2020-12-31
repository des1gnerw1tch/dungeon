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
    [SerializeField] private GameObject pistol;



    void Start() {
      item = new string[26];
      //if it is a new game, do not load
      if (!NewGameOnClick.newGame)  {
        FindObjectOfType<GameSaveManager>().LoadPlayer();
        overworldScene.UpdateScene();
      } else {
        NewGameOnClick.newGame = false;
        PlayerProgress.ResetStaticVariables();
        overworldScene.UpdateScene();
        Instantiate(pistol, new Vector2(-7.33f, 26.38f), Quaternion.identity);
      }

      /*this checks for a red gauntlet, and only lets the player keep it if
      they has destroyed the red crystal. this makes sure that people don't quit
      the game and restart to keep the red gauntlet and cheese the last level.*/
      for (int i = 0; i < item.Length; i++) {
          if (item[i] == "Ruby Gauntlet" && !PlayerProgress.redCrystalDestroyed)
          {
              slots[i].GetComponent<Slot>().DestroyItem();
              item[i] = null;
              Debug.Log("Destroyed illegal ruby gauntlet");
          }
      }


    }

}
