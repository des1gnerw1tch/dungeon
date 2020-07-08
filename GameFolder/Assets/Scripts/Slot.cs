using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private Inventory inventory;
    public int i;
    private DestroyGun DropThing;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        DropThing = GameObject.FindGameObjectWithTag("FirePoint").GetComponent<DestroyGun>();
    }
    private void Update(){
        if(transform.childCount <= 0){
            inventory.isFull[i]  = false;
		} else {
      inventory.isFull[i]  = true;
    }
	}

    public void DropItem(){
        foreach(Transform child in transform){
            child.GetComponent<ItemSpawn>().SpawnDroppedItem();
            GameObject.Destroy(child.gameObject);
            DropThing.DropGun();
	    }


	}
    public void DestroyItem(){
        foreach(Transform child in transform){
            GameObject.Destroy(child.gameObject);
            }


	}
}
