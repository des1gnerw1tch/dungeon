using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creditsPortal : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)  {
      if (other.CompareTag("Player")) {
        PlayerSettings.gameCompleted = true;
        SaveSystem.SaveSettings();
      }
    }
}
