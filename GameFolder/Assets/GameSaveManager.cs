using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameSaveManager : MonoBehaviour
{

  public PlayerMovement playerMovement;
  public PlayerHealth playerHealth;
  public Inventory playerInventory;
  public ItemManager itemManager;
  public Slot[] slots;
  public float saveInterval = 10f;
  private float counter;

//tries to load save
  void Start()  {
    //LoadPlayer();
    if (LoadOnClick.loadFromSave) {
      LoadPlayer();
    }
    counter = saveInterval;
  }

//saves file every so seconds
  void Update() {
    if (counter > 0f)  {
      counter -= Time.deltaTime;
    } else {
      counter = saveInterval;
      SavePlayer();
      Debug.Log("Saved position and health");

    }
  }

  //this is what saves the player data
    public void SavePlayer()  {
      SaveSystem.SavePlayer(playerMovement, playerHealth, playerInventory);
    }

//this is what loads the player data
    public void LoadPlayer()  {
      PlayerData data = SaveSystem.LoadPlayer();
      //loads health
      playerHealth.currentHealth = data.health;
      //loads position
      Vector3 position;
      position.x = data.position[0];
      position.y = data.position[1];
      position.z = data.position[2];
      playerMovement.transform.position = position;

      //loads inventory
      for(int i = 0; i < 5; i++)  {
        playerInventory.item[i] = data.item[i];

        //checks if item string is a gun
        Gun gunInstance = Array.Find(itemManager.guns, gun => gun.name == playerInventory.item[i]);
        if (gunInstance != null) {
          Instantiate(gunInstance.canvasImage, playerInventory.slots[i].transform, false);
        } else {
          Item itemInstance = Array.Find(itemManager.items, item => item.name == playerInventory.item[i]);
          if (itemInstance != null) {
            Instantiate(itemInstance.canvasImage, playerInventory.slots[i].transform, false);
          }
        }
        //checks if it is an item, if so instantiate

        playerInventory.isFull[i] = data.isFull[i];
      }

    }
}
