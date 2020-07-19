using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class DeathInventory : MonoBehaviour
{
    private Inventory inventory;
    private ItemManager itemManager;
    [SerializeField] private GameObject[] slots;
    [SerializeField] GameObject continueButton;
    public bool[] slotSelected;
    private int numSelected;
    public DontDestroy[] objects;
    // Start is called before the first frame update
    void Start()
    {

      inventory = FindObjectOfType<Inventory>();
      itemManager = FindObjectOfType<ItemManager>();
      PlaceInventoryUI();
      DisablePlayer();
      numSelected = 0;
    }

    /*places the inventory images on slots*/
    void PlaceInventoryUI() {

      for (int i = 0; i < 5; i++) {
        Gun gunInstance = Array.Find(itemManager.guns, gun => gun.name == inventory.item[i]);
        if (gunInstance != null) {
          GameObject instance = Instantiate(gunInstance.canvasImage, slots[i].transform, false);
          instance.GetComponent<ItemSpawn>().enabled = false;
        } else { //checks if it is an item, if so instantiate
          Item itemInstance = Array.Find(itemManager.items, item => item.name == inventory.item[i]);
          if (itemInstance != null) {
            GameObject instance = Instantiate(itemInstance.canvasImage, slots[i].transform, false);
            instance.GetComponent<ItemSpawn>().enabled = false;
          }
        }
      }

    }
    /*this temporarily disables all of the objects with "do not destroy" EXCEPT AudioManager*/
    void DisablePlayer()  {
      objects = FindObjectsOfType<DontDestroy>();
      foreach (DontDestroy obj in objects)  {
        if (obj.gameObject.GetComponent<AudioManager>() == null)  {
          obj.gameObject.SetActive(false);
        }
      }
    }

    public void SlotClick(int i)  {
      //new selection, max not reached
      if (numSelected < 2 && !slotSelected[i])  {
        slotSelected[i] = true;
        numSelected++;
        slots[i].GetComponent<Animator>().SetBool("SlotSelected", true);
        //play largining animation
      }

      //click old slot
      else if (slotSelected[i]) {
        slotSelected[i] = false;
        numSelected--;
        slots[i].GetComponent<Animator>().SetBool("SlotSelected", false);
        //play smalling animation
      } else {
        //two already clicked
      }

      if (numSelected == 2) {
        continueButton.SetActive(true);
      } else {
        continueButton.SetActive(false);
      }

      Debug.Log(numSelected);
    }
}
