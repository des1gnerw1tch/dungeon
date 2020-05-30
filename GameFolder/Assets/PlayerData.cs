using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData {

  public int health;
  public float[] position;

  public string[] item;
  public bool[] isFull;

  public PlayerData (PlayerMovement playerMovement, PlayerHealth playerHealth, Inventory playerInventory) {
    //player health
    health = playerHealth.currentHealth;

    //player position
    position = new float[3];
    position[0] = playerMovement.transform.position.x;
    position[1] = playerMovement.transform.position.y;
    position[2] = playerMovement.transform.position.z;

    //player inventory
    item = new string[5];
    isFull = new bool[5];
    for (int i = 0; i < 5; i++) {
      item[i] = playerInventory.item[i];
      isFull[i] = playerInventory.isFull[i];
    }




  }
}
