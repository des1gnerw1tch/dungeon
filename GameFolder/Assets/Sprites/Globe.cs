using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Globe : MonoBehaviour
{
    public GameObject minion;
    public GameObject miniBoss;
    public int numMinions;
    public Light2D globeLight;
    //test
    private GameObject bossInstance;
    private EnemyHealth bossHealth;
    private Animator animator;

    private bool activated = false;
    private bool bossDefeated = false;
    // Start is called before the first frame update
    void Start()
    {
      animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      if (bossInstance != null) {
        if (activated && bossHealth.GetHealth() <= 0 && !bossDefeated)  {
          CompleteTask();
        }
      }
    }

    void OnTriggerStay2D(Collider2D other){
        if(other.CompareTag("Player")){
            if (Input.GetKey("e"))  {
              if (!activated){
                activated = true;
                Invoke("Summon", 2.0f);
              }
            }
		    }
      }

      void Summon() {
        bossInstance = Instantiate(miniBoss, transform.position, Quaternion.identity);
        for (int i = 0; i < numMinions; i++)  {
          Instantiate(minion, transform.position, Quaternion.identity);
        }

        bossHealth = bossInstance.GetComponent<EnemyHealth>();
        GetComponent<Collider2D>().enabled = false;
      }

      void CompleteTask() {
        animator.SetBool("Completed", true);
        Color purple = new Color(.75f, 0, 1);
        globeLight.color = purple;
        bossDefeated = true;
        LevelManager level = FindObjectOfType<LevelManager>();
        if (level != null)  {
          level.numCompleted++;
          if (level.numCompleted >= level.numOfGlobes)  {
            level.CompleteLevel();
          }
        }
      }
}
