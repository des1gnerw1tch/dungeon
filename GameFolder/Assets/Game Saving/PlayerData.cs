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

    //player money
    coins = playerMoney.coins;
    }




  }
}
