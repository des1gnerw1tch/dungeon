using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameOnClick : MonoBehaviour
{
    public static bool newGame = false;
    [SerializeField]
    private MenuManager menuManager;

    [SerializeField]
    private float delay;

    public void Click() {
      menuManager.NewGame(delay);
      SaveSystem.DeletePlayer();
      newGame = true;
    }
}
