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
  public PlayerMoney playerMoney;
  public Slot[] slots;
  public float saveInterval = 10f;
  private float counter;

//tries to load save
  void Start()  {
  //  Player is loaded in the INVENTORY script on start
    counter = 0;
  //loading settings data
    SettingsData data = SaveSystem.LoadSettings();
    PlayerSettings.music = data.music;
    PlayerSettings.soundEffects = data.soundEffects;
    PlayerSettings.fancyGraphics = data.fancyGraphics;
    Debug.Log("Music " + PlayerSettings.music + " Sound Effects " + PlayerSettings.soundEffects + " Fancy Lighting " + PlayerSettings.fancyGraphics);
  }

//saves file every so seconds
  void Update() {
    if (counter > 0f)  {
      counter -= Time.deltaTime;
    } else {
      counter = saveInterval;
      SavePlayer();
      //Debug.Log("Saved position and health");

    }
  }

  //this is what saves the player data
    public void SavePlayer()  {
      SaveSystem.SavePlayer(playerMovement, playerHealth, playerInventory, playerMoney);
    }

//Loads previous save
    public void LoadPlayer()  {
      PlayerData data = SaveSystem.LoadPlayer();
      //loads health
      playerHealth.currentHealth = data.health;
      //loads position
    /*  Vector3 position;
      position.x = data.position[0];
      position.y = data.position[1];
      position.z = data.position[2];
      playerMovement.transform.position = position;*/

      //loads inventory
      for(int i = 0; i < 26; i++)  {
        playerInventory.item[i] = data.item[i];

        //checks if item string is a gun, if so instantiate canvas image
        Gun gunInstance = Array.Find(itemManager.guns, gun => gun.name == playerInventory.item[i]);
        if (gunInstance != null) {
          Instantiate(gunInstance.canvasImage, playerInventory.slots[i].transform, false);
        } else { //checks if it is an item, if so instantiate
          Item itemInstance = Array.Find(itemManager.items, item => item.name == playerInventory.item[i]);
          if (itemInstance != null) {
            Instantiate(itemInstance.canvasImage, playerInventory.slots[i].transform, false);
          }
        }


        playerInventory.isFull[i] = data.isFull[i];

        //loads money
        playerMoney.coins = data.coins;

        //loads game progress
        PlayerProgress.wizardFreed = data.wizardFreed;
        PlayerProgress.merchantFreed = data.merchantFreed;
        PlayerProgress.nurseFreed = data.nurseFreed;
        PlayerProgress.alchemistFreed = data.alchemistFreed;

        PlayerProgress.hasBlueKey = data.hasBlueKey;
        PlayerProgress.hasPurpleKey = data.hasPurpleKey;
        PlayerProgress.hasBrownKey = data.hasBrownKey;
        PlayerProgress.hasCrystalKey = data.hasCrystalKey;
      }

    }
}
