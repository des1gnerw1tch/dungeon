using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadOnClick : MonoBehaviour
{
    public static bool loadFromSave = false;
    public void Click()  {
      SceneManager.LoadScene("Main");
      loadFromSave = true;
    }
}
