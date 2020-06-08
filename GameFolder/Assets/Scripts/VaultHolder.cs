using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VaultHolder : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
      /*  Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Main") {
           transform.GetChild(0).gameObject.SetActive(true);
       } else {
         transform.GetChild(0).gameObject.SetActive(false);
       }*/
    }

    public void DisableVault()  {
      transform.GetChild(0).gameObject.SetActive(false);
    }

    public void EnableVault()  {
      transform.GetChild(0).gameObject.SetActive(true);
    }
}
