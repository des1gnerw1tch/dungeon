using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Animator NPC;
    public Dialogue dialogue;
    public bool isStart = false;

    public void Start()
    {
        if (isStart)
        {
            TriggerDialogue();
        }
    }
    public void TriggerDialogue(){
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        if (NPC != null)  {
          NPC.SetBool("Talking", true);
        }
	}
    public void EndTalk(){
        FindObjectOfType<DialogueManager>().EndDialogue();
        if (NPC != null)  {
          NPC.SetBool("Talking", false);
        }
	}
    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            TriggerDialogue();
		}

	}
    void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player")){
            EndTalk();
		}

	}
}
