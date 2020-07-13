using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinBossDialogue : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private int counter = 0;
    [SerializeField]
    private GameObject dialogue;
    [SerializeField]
    private Animator[] goblinControllers;
    [SerializeField]
    private MinionSpawn[] bossSpawners;

    void Start()
    {
      counter = 0;
      FindObjectOfType<PlayerMovement>().moveSpeed = 0f;

      //disabling goblin boss and minions during dialogue
      foreach (Animator gController in goblinControllers) {
        gController.enabled = false;
      }
      foreach (MinionSpawn spawner in bossSpawners) {
        spawner.enabled = false;
      }

    }

    void Update() {
      if (Input.GetKeyDown(KeyCode.Space))  {
        counter++;
      }
      if (counter >= 3) {
        //re enables player speed, goblins animators, and spawners while destroying dialogue
        FindObjectOfType<PlayerMovement>().moveSpeed = 5f;
        foreach (Animator gController in goblinControllers) {
          gController.enabled = true;
        }
        foreach (MinionSpawn spawner in bossSpawners) {
          spawner.enabled = true;
        }
        Destroy(dialogue, 2f);
        Destroy(this.gameObject);
      }
    }
}
