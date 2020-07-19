using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathContinue : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    [SerializeField]
    private DeathInventory deathInventory;

    public void Continue() {
      EnablePlayer();
      player = GameObject.FindWithTag("Player");
      player.GetComponent<PlayerHealth>().currentHealth = 20;
      Vector3 reset = new Vector3(24.35f, 22.94f, 0f);
      player.transform.position = reset;
      Inventory inventory = player.GetComponent<Inventory>();
      for (int i = 0; i < 5; i++)  {
        if (!deathInventory.slotSelected[i])  {
          // destroy item
          inventory.item[i] = null;
          inventory.slots[i].GetComponent<Slot>().DestroyItem();
        }
      }
      SceneManager.LoadScene("Main");
      //player.GetComponent<PlayerHealth>().currentHealth = 20;
      //Debug.Log(player.GetComponent<PlayerHealth>().currentHealth);
      //currentHealth = maxHealth / 4;
      //SceneManager.LoadScene("Main");
      //Vector3 reset = new Vector3(24.35f, 22.94f, 0f);
      //transform.position = reset;
    }

    void EnablePlayer()  {

      foreach (DontDestroy obj in deathInventory.objects)  {
        obj.gameObject.SetActive(true);
      }
    }
}
