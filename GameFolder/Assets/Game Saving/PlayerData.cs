using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData {

  public int health;
  public float[] position;
  //inventory
  public string[] item;
  public bool[] isFull;
  public int coins;

  //PlayerProgress saving
  public bool wizardFreed;
  public bool merchantFreed;
  public bool nurseFreed;
  public bool alchemistFreed;
  public bool friendFreed;
  public bool blueCrystalDestroyed;
  public bool greenCrystalDestroyed;
  public bool redCrystalDestroyed;
  //key progress
  public bool hasBlueKey;
  public bool hasPurpleKey;
  public bool hasBrownKey;
  public bool hasCrystalKey;

  public PlayerData (PlayerMovement playerMovement, PlayerHealth playerHealth, Inventory playerInventory, PlayerMoney playerMoney) {
    //player health
    health = playerHealth.currentHealth;

    //player position
    position = new float[3];
    position[0] = playerMovement.transform.position.x;
    position[1] = playerMovement.transform.position.y;
    position[2] = playerMovement.transform.position.z;

    //player inventory
    item = new string[26];
    isFull = new bool[26];
    for (int i = 0; i < 26; i++) {
      item[i] = playerInventory.item[i];
      isFull[i] = playerInventory.isFull[i];
    }
    //player money
    coins = playerMoney.coins;

    //player progress
    wizardFreed = PlayerProgress.wizardFreed;
    merchantFreed = PlayerProgress.merchantFreed;
    nurseFreed = PlayerProgress.nurseFreed;
    alchemistFreed = PlayerProgress.alchemistFreed;
    friendFreed = PlayerProgress.friendFreed;

    blueCrystalDestroyed = PlayerProgress.blueCrystalDestroyed;
    greenCrystalDestroyed = PlayerProgress.greenCrystalDestroyed;
    redCrystalDestroyed = PlayerProgress.redCrystalDestroyed;
    //key progress
    hasBlueKey = PlayerProgress.hasBlueKey;
    hasPurpleKey = PlayerProgress.hasPurpleKey;
    hasBrownKey = PlayerProgress.hasBrownKey;
    hasCrystalKey = PlayerProgress.hasCrystalKey;





  }
}
