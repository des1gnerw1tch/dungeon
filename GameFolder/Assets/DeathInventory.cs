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
    // Start is called before the first frame update
    void Start()
    {
      inventory = FindObjectOfType<Inventory>();
      itemManager = FindObjectOfType<ItemManager>();
      PlaceInventoryUI();
    }


    void PlaceInventoryUI() {

      for (int i = 0; i < 5; i++) {
        Gun gunInstance = Array.Find(itemManager.guns, gun => gun.name == inventory.item[i]);
        if (gunInstance != null) {
          Instantiate(gunInstance.canvasImage, slots[i].transform, false);
        } else { //checks if it is an item, if so instantiate
          Item itemInstance = Array.Find(itemManager.items, item => item.name == inventory.item[i]);
          if (itemInstance != null) {
            Instantiate(itemInstance.canvasImage, slots[i].transform, false);
          }
        }
      }

    }
}
