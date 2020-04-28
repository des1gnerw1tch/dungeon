using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSavedObjects : MonoBehaviour
{
//hh
    private GameObject[] savedObjs;
    private exclusiveToScene[] exclusiveToSceneClass;
    public string[] startScene;
    public string currentScene;
    void Start()
    {
      //savedObjs = GameObject.FindGameObjectsWithTag("Drops");
      savedObjs = GameObject.FindGameObjectsWithTag("Interactable");
      //exclusiveToSceneClass = GameObject.FindGameObjectsWithTag("Interactable").GetComponent<exclusiveToScene>();
      for (int i = 0; i < savedObjs.Length ; i++) {
        if (savedObjs[i].GetComponent<exclusiveToScene>() != null)  {
          exclusiveToSceneClass[i] = savedObjs[i].GetComponent<exclusiveToScene>();
          Debug.Log(exclusiveToSceneClass[i].returnStartScene());
          startScene[i] = exclusiveToSceneClass[i].returnStartScene();
      }

      }
    }

    // Update is called once per frame
    void Update()
    {


      /*
      for (int j = 0; j < savedObjs.Length ; j++) {
        currentScene = SceneManager.GetActiveScene().name;
        if (currentScene == startScene[j]) {
          savedObjs[j].SetActive (true);
        } else {
          savedObjs[j].SetActive (false);
        }
      }*/

    }
}
