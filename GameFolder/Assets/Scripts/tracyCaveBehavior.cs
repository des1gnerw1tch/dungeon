using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tracyCaveBehavior : MonoBehaviour
{
    [SerializeField] private GameObject DropPrefab;
    [SerializeField] private BoxCollider2D DialogueCollider;
    private GameObject Player;

    [SerializeField] private int counter = 0;
    public bool trig = false;

    void Start()  {
      Player = FindObjectOfType<PlayerMovement>().gameObject;
      counter = 0;
    }

    void OnTriggerEnter2D(Collider2D other) {
      //disable movement when talking to NPC
      if (other.CompareTag("Player")) {
        other.GetComponent<PlayerMovement>().moveSpeed = 0f;
        DialogueCollider.size = new Vector2(10, 10);
        trig = true;
      }

    }

    void Update() {
      if (trig) {
        if (Input.GetKeyDown(KeyCode.Space))  {
          counter += 1;

          //on 4th dialogue
          if (counter == 4) {
            Instantiate(DropPrefab, Player.transform.position, Quaternion.identity);
          }

          //on end of conversation, teleport to shop Scene
          if (counter == 5) {
            transform.GetChild(0).gameObject.SetActive(true);
            Player.GetComponent<PlayerMovement>().moveSpeed = 5f;
            PlayerProgress.merchantFreed = true;
          }
        }
    }
    }

}
