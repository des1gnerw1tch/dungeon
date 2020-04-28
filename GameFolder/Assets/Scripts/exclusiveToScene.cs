using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class exclusiveToScene : MonoBehaviour
{
    public string startScene;
    void Start()
    {

    }

    public string returnStartScene() {
      startScene = SceneManager.GetActiveScene().name;
      
      return startScene;
    }
}
