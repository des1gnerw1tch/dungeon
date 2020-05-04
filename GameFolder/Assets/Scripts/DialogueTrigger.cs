using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    
    public Dialogue dialogue;

    public void TriggerDialogue(){
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
	}
    public void EndTalk(){
        FindObjectOfType<DialogueManager>().EndDialogue();
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
