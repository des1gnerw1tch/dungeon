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
    public bool[] slotSelected;
    // Start is called before the first frame update
    void Start()
    {

      inventory = FindObjectOfType<Inventory>();
      itemManager = FindObjectOfType<ItemManager>();
      PlaceInventoryUI();
      DisablePlayer();
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
    /*this temporarily disables all of the objects with "do not destroy"*/
    void DisablePlayer()  {
      DontDestroy[] objects = FindObjectsOfType<DontDestroy>();
      foreach (DontDestroy obj in objects)  {
        obj.gameObject.SetActive(false);
      }
    }

    public void SlotClick(int i)  {
      Debug.Log(i);
    }
}
