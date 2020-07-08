using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGameOnClick : MonoBehaviour
{
    public static bool newGame = false;
    public void Click() {
      SceneManager.LoadScene("Main");
      SaveSystem.DeletePlayer();
      newGame = true;
    }
}
