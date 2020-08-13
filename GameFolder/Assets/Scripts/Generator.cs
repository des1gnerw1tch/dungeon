using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{

    [SerializeField]
    private DialogueTrigger onDialogue;

    [SerializeField]
    private BoxCollider2D collider;

    void Start()  {
      if (LavaDungManager.powerOn)  {
        collider.enabled = false;
      }
    }
    void OnTriggerStay2D(Collider2D other)  {
      if (other.CompareTag("Player")) {
        if (Input.GetKeyDown("e"))  {
          collider.enabled = false;
          onDialogue.TriggerDialogue();
          LavaDungManager.powerOn = true;
        }
      }
    }


}
