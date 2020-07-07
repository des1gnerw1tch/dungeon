using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKey : MonoBehaviour
{
  [SerializeField] private string KeyColor;

    void OnTriggerEnter2D(Collider2D other) {

      if (other.CompareTag("Player")) {
        switch (KeyColor) {
          case "Blue" :
            PlayerProgress.hasBlueKey = true;
            break;
          case "Purple" :
            PlayerProgress.hasPurpleKey = true;
            break;
          case "Brown" :
            PlayerProgress.hasBrownKey = true;
            break;
          case "Crystal" :
            PlayerProgress.hasCrystalKey = true;
            break;
        }
        Destroy(this.gameObject);
      }
    }
}
