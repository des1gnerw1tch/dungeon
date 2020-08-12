using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeSwitch : MonoBehaviour
{
    [SerializeField]
    private LavaDungManager dungeonManager;
    
    void OnTriggerStay2D(Collider2D other)  {
      if (other.CompareTag("Player")) {
        if (Input.GetKeyDown("e"))  {
          dungeonManager.BuildBridge();
        }
      }
    }
}
