﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickUp : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;
    public string inventoryID;
    public bool wasDropped = false;
    private bool isDuplicate = false;
    private int duplicateSlot;
    private DialogueTrigger pickUpDialogue;
    private DialogueTrigger fullDialogue;
    private dialogueTimer dialogueTimerScript;
    [HideInInspector]public bool dialogueIsTriggered = false;

    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        pickUpDialogue = GameObject.FindWithTag("pickUpDialogue").GetComponent<DialogueTrigger>();
        fullDialogue = GameObject.FindWithTag("duplicateDialogue").GetComponent<DialogueTrigger>();
        dialogueTimerScript = FindObjectOfType<dialogueTimer>();
    }
    void OnTriggerEnter2D(Collider2D other){
        if  (other.CompareTag("Player") && !wasDropped){

          //check for duplicates
            isDuplicate = false;
            for(int j = 0; j < inventory.slots.Length; j ++){
                if(inventory.item[j] == inventoryID && inventory.item[j] != "Health Potion" && inventory.item[j] != "Torch" && inventory.item[j] != "EmptyBook"
                && inventory.item[j] != "Speed Potion" && inventory.item[j] != "Restoration Potion" && inventory.item[j] != "Focus Potion")
                {
                    isDuplicate = true;
                    duplicateSlot = j;
				        }
			       }
            for(int i = 0; i < inventory.slots.Length; i ++){

                if(inventory.isFull[i] == false && !isDuplicate && i < 5){
                    inventory.isFull[i] = true;

                    Instantiate(itemButton, inventory.slots[i].transform,false);
                    Destroy(gameObject);
                    inventory.item[i] = inventoryID;
                    FindObjectOfType<AudioManager>().Play("pickUpItem");
                    FindObjectOfType<GameSaveManager>().SavePlayer();

                    //Pick up dialogue
                    Scene scene = SceneManager.GetActiveScene();
                    if (scene.name != "GunShop" && scene.name != "Hospital" && scene.name != "AlchemistHome") {
                      if(inventoryID == "Glick" && scene.name == "Main")
                        {
                            pickUpDialogue.dialogue.sentances[0] = "You found a " + inventoryID + "! point and click to shoot.";
                        }
                        else
                        {
                            pickUpDialogue.dialogue.sentances[0] = "You found a " + inventoryID + "!";
                        }
                      pickUpDialogue.TriggerDialogue();
                      dialogueTimerScript.endDialogue(3f, this);
                    }
                    break;
				}
		    }

        //triggers duplicate dialogue
        if (isDuplicate && !dialogueIsTriggered) {
          if (duplicateSlot <=4)
            fullDialogue.dialogue.sentances[0] = "You already have a " + inventoryID + " in your hotbar. You may only have 1 of each weapon.";
          else
            fullDialogue.dialogue.sentances[0] = "You have an " + inventoryID + " in your vault. You may only have 1 of each weapon.";
          fullDialogue.TriggerDialogue();
          dialogueTimerScript.endDialogue(2f, this);
          dialogueIsTriggered = true;
        }

	     }


	}

  void OnTriggerExit2D(Collider2D other)  {
    if (other.CompareTag("Player")) {
      wasDropped = false;

      /*We want it to end dialogue when you drop a weapon and get out of its radius
      but not when you have a duplicate */
      Scene scene = SceneManager.GetActiveScene();
      if (!isDuplicate && scene.name != "GunShop" && scene.name != "Hospital" && scene.name != "AlchemistHome") {
        pickUpDialogue.EndTalk();
      }
    }
  }


}
