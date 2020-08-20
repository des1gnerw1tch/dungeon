using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;
    public string inventoryID;
    public bool wasDropped = false;
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
    void OnTriggerEnter2D(Collider2D other){
        if  (other.CompareTag("Player") && !wasDropped){
            bool isDuplicate = false;
            for(int j = 0; j < inventory.slots.Length; j ++){
                if(inventory.item[j] == inventoryID && inventory.item[j] != "HealthPotion" && inventory.item[j] != "Torch" && inventory.item[j] != "EmptyBook")
                {
                    isDuplicate = true;
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

                    break;
				}
		    }

	     }
	}

  void OnTriggerExit2D(Collider2D other)  {
    if (other.CompareTag("Player")) {
      wasDropped = false;
    }
  }

}
