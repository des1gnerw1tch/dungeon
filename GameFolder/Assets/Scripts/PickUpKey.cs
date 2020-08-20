using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpKey : MonoBehaviour
{
  [SerializeField] private string KeyColor;
  private Transform player;
  [SerializeField] private GameObject keyReceivedText;

    void Start()  {
      player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

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

        Vector2 pos = new Vector2(player.position.x + 49.6355f + Random.Range(-1f, 1f), player.position.y -47.0451f + Random.Range(-1f, 1f));
        Instantiate(keyReceivedText, pos, Quaternion.identity);
        Destroy(this.gameObject);
      }
    }
}
