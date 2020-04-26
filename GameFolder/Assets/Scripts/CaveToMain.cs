using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CaveToMain : MonoBehaviour
{
    public string sceneToLoad;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D hitInfo) {

    if(hitInfo.gameObject.tag == "Player"){
          SceneManager.LoadScene(sceneToLoad);
      }

    }
}
