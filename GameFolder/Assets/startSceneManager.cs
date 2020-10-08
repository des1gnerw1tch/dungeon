using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startSceneManager : MonoBehaviour
{
    [SerializeField]
    private GameObject zachCharacter;
    [SerializeField]
    private GameObject bobCharacter;

    void Start()
    { // this will choose the character wanted for the scene
      if (PlayerSettings.character == "Zach") {
        zachCharacter.SetActive(true);
      }
      else if (PlayerSettings.character == "Bob") {
        bobCharacter.SetActive(true);
      }
    }

}
