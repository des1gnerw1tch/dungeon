using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tracyCaveBehavior : MonoBehaviour
{
    [SerializeField] private GameObject DropPrefab;
    [SerializeField] private BoxCollider2D DialogueCollider;

    [SerializeField] private int counter = 0;

    void Start()  {
      counter = 0;
    }

    void OnTriggerEnter2D(Collider2D other) {
      //disable movement when talking to NPC
      if (other.CompareTag("Player")) {
        other.GetComponent<PlayerMovement>().moveSpeed = 0f;
        DialogueCollider.size = new Vector2(10, 10);
      }

    }
    void OnTriggerStay2D(Collider2D other){

      if(other.CompareTag("Player"))  {
        //counter will go up whenever pressed space talking to homie
          if (Input.GetKeyDown("space"))  {
            counter += 1;

            //on 3rd dialogue
            if (counter == 3) {
              Instantiate(DropPrefab, other.transform.position, Quaternion.identity);
            }

            //on end of conversation, teleport to shop Scene
            if (counter == 4) {
              transform.GetChild(0).gameObject.SetActive(true);
              other.GetComponent<PlayerMovement>().moveSpeed = 5f;
              PlayerProgress.merchantFreed = true;
            }
          }
      }

    }

}
