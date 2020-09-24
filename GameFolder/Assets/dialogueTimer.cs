using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueTimer : MonoBehaviour
{
    private float time = 2f;

    public void endDialogue(float _time)  {
      time = _time;
      StartCoroutine(endDialogue());
    }
    IEnumerator endDialogue() {
      Debug.Log("Timer started");
      yield return new WaitForSeconds(time);
      FindObjectOfType<DialogueManager>().EndDialogue();
    }
}
