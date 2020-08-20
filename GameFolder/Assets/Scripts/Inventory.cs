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
    [SerializeField] private DialogueTrigger beginningDialogue;
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
        beginningDialogue.TriggerDialogue();
        Instantiate(pistol, new Vector2(3.683f, -17.4382f), Quaternion.identity);
      }

    }

}
