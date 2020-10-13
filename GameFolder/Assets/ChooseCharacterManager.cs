using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseCharacterManager : MonoBehaviour
{
    public void zachChose()  {
      PlayerSettings.character = "Zach";
      SaveSystem.SaveSettings();
      SceneManager.LoadScene("Start");
    }

    public void bobChose()  {
      PlayerSettings.character = "Bob";
      SaveSystem.SaveSettings();
      SceneManager.LoadScene("Start");
    }

    public void girlChose()  {
      PlayerSettings.character = "Girl";
      SaveSystem.SaveSettings();
      SceneManager.LoadScene("Start");
    }
}
