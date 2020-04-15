﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private Inventory inventory;
    public int i;
    private EquippedGun GunScript;
    
    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        //GunScript = GameObject.FindGameObjectWithTag("AR").GetComponent<EquippedGun>();
    }
    private void Update(){
        if(transform.childCount <= 0){
            inventory.isFull[i]  = false;   
		}
	}
    
    public void DropItem(){
        foreach(Transform child in transform){
            child.GetComponent<ItemSpawn>().SpawnDroppedItem();
            GameObject.Destroy(child.gameObject);
            
	    }
        
	}
}
