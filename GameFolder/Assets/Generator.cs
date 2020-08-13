using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{

    void Start()  {
      if (LavaDungManager.powerOn)  {
        Destroy(this.gameObject);
      }
    }
    [SerializeField]
    private DialogueTrigger onDialogue;
    void OnTriggerStay2D(Collider2D other)  {
      if (other.CompareTag("Player")) {
        if (Input.GetKeyDown("e"))  {
          LavaDungManager.powerOn = true;
          onDialogue.TriggerDialogue();
          Destroy(this.gameObject);
        }
      }
    }
}
