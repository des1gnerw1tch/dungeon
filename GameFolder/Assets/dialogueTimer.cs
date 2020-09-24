using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueTimer : MonoBehaviour
{
    private float time = 2f;
    private PickUp item;

    public void endDialogue(float _time, PickUp _item)  {
      time = _time;
      StartCoroutine(endDialogue());
      item = _item;
    }
    IEnumerator endDialogue() {
      yield return new WaitForSeconds(time);
      FindObjectOfType<DialogueManager>().EndDialogue();
      item.dialogueIsTriggered = false;
    }
}
