using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class NewGameOnClick : MonoBehaviour
{
    public static bool newGame = false;
    [SerializeField]
    private MenuManager menuManager;
    [SerializeField]
    private GameObject areYouSureUI;

    [SerializeField]
    private float delay;

    public void Click() {
      string path = Application.persistentDataPath + "/player.fun";
      if (File.Exists(path))  {
        areYouSureUI.SetActive(true);
      } else {
        StartNewGame();
      }

    }

    public void StartNewGame()  {
      menuManager.NewGame(delay);
      SaveSystem.DeletePlayer();
      newGame = true;
    }

}
