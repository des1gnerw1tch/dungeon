using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotOnClick : MonoBehaviour
{

    public int slotNumber;
    private scroll scrollScript;
    void Start(){
        scrollScript = GameObject.FindGameObjectWithTag("Player").GetComponent<scroll>();
	}
    public void ClickToEquip(){

        scrollScript.activeSlot = slotNumber;
        Debug.Log("clicked");
	}
  
}
