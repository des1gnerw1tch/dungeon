using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendBehaviour : MonoBehaviour
{
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

        //on end of conversation, free up movement and destroy dialogue
        if (counter == 5) {
          Player.GetComponent<PlayerMovement>().moveSpeed = 5f;
          transform.GetChild(0).gameObject.SetActive(true);
        }
      }
  }
  }
}
