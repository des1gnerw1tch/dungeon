using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update!!
    public float maxHealth = 100;
    private float curHealth;
    public string enemyID;

    Vector2 pos;
    private bool hasDied = false;
    public float dissolveSpeed = 2f;

    //scripts
    public Dissolve dissolve;
    public Tint tint;
    public Animator animator;
    public bool isBoss;
    public GameObject portalToEnable;

    //boss stuff

    void Start()
    {
        curHealth = maxHealth;
        pos.Set(0f, 0f);
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
       curHealth -= damage;
       tint.SetTintColor(new Color(1, 1, 1, 1f));
       /*when shot while idling, the enemy will move away (start patrolling). */
       if (animator != null)  {
         animator.SetBool("isPatrolling", true);
       }
       if(curHealth <= 0 && !hasDied){

        Die();
	   }
    }
    public void Die()
    {
        if (!hasDied) {
          GetComponent<Collider2D>().enabled = false;
          hasDied = true;
          dissolve.play(dissolveSpeed);
          animator.SetBool("isDead", true);
          FindObjectOfType<DropManager>().Drop(enemyID, transform.position);
          FindObjectOfType<AudioManager>().Play(enemyID);
          if (isBoss) {
            killMinions();
            //lets you go through door at the end
            portalToEnable.SetActive(true);
          }
        }

      }

    void killMinions()  {
      EnemyHealth[] minions = Object.FindObjectsOfType<EnemyHealth>();
      Spawner[] spawners = Object.FindObjectsOfType<Spawner>();
      GetComponent<MinionSpawn>().enabled = false;
      foreach (EnemyHealth minion in minions) {
        minion.Die();
      }
      foreach (Spawner spawner in spawners) {
        spawner.enabled = false;
      }

    }





}
