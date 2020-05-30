using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSaveManager : MonoBehaviour
{

  public PlayerMovement playerMovement;
  public PlayerHealth playerHealth;
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
      SaveSystem.SavePlayer(playerMovement, playerHealth);
    }

//this is what loads the player data
    public void LoadPlayer()  {
      PlayerData data = SaveSystem.LoadPlayer();
      playerHealth.currentHealth = data.health;
      Vector3 position;
      position.x = data.position[0];
      position.y = data.position[1];
      position.z = data.position[2];
      playerMovement.transform.position = position;

    }
}
