using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;
    public EquippedGun equippedGun;
    public string inventoryID;
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
    void OnTriggerEnter2D(Collider2D other){
        if  (other.CompareTag("Player")){
            bool isDuplicate = false;
            for(int j = 0; j < inventory.slots.Length; j ++){
                if(inventory.item[j] == inventoryID){
                    isDuplicate = true;
				}
			}
            for(int i = 0; i < inventory.slots.Length; i ++){

                if(inventory.isFull[i] == false && !isDuplicate){
                    inventory.isFull[i] = true;

                    Instantiate(itemButton, inventory.slots[i].transform,false);
                    Destroy(gameObject);
                    //inventory.item[i] = equippedGun.GunType;
                    inventory.item[i] = inventoryID;

                    break;
				}
		    }

	     }
	}

}
