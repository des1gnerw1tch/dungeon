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
      /*dialogue does not end after time as expected, because there are bugs where
      you would get kicked out of dialouge when talking to somebody else.
      this new feature though just limits the amount of times you can get a duplicate warning message*/
      
      //FindObjectOfType<DialogueManager>().EndDialogue();
      item.dialogueIsTriggered = false;
    }
}
