using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    private Inventory inventory;
    public int i;
    private DestroyGun DropThing;
    [SerializeField] private scroll scrollScript;
    private Image image;
    [SerializeField] private Sprite uiBackboard;
    [SerializeField] private Sprite uiBackboardSelected;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        DropThing = GameObject.FindGameObjectWithTag("FirePoint").GetComponent<DestroyGun>();
        image = GetComponent<Image>();
    }
    private void Update(){
        if(transform.childCount <= 0){
            inventory.isFull[i]  = false;
		} else {
      inventory.isFull[i]  = true;
    }

    /*this makes the slot bigger when you are holding it*/
    if (i >= 0 && i <= 4) {
        if (scrollScript.activeSlot == i) {
          transform.localScale = new Vector3(.6f, .6f, .6f);
          image.sprite = uiBackboardSelected;
        } else {
          transform.localScale = new Vector3(.5f, .5f, .5f);
          image.sprite = uiBackboard;
        }
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
