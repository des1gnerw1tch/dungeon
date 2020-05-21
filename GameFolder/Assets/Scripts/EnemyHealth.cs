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
    private EnemyHealthBar EnemyHealthBarScript;
    private GameObject enemyhealthBarCanvasImage;

    //boss stuff

    void Start()
    {
        EnemyHealthBarScript = GameObject.FindGameObjectWithTag("EnemyHealthBar").GetComponent<EnemyHealthBar>();
        enemyhealthBarCanvasImage = GameObject.FindGameObjectWithTag("EnemyHealthBar");
        curHealth = maxHealth;
        if (isBoss)
        {

            EnemyHealthBarScript.SetEnemyMaxHealth(maxHealth);


        }

        pos.Set(0f, 0f);
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
       curHealth -= damage;
       FindObjectOfType<AudioManager>().Play("enemyHurt");
       if (isBoss)
       {
           //enemyhealthBarCanvasImage.GetComponent<CanvasGroup>().alpha = 1;

           if (EnemyHealthBarScript != null)
           {
                EnemyHealthBarScript.SetEnemyHealth(curHealth);
           }
       }

       tint.SetTintColor(new Color(1, 1, 1, 1f));
       /*when shot while idling, the enemy will move away (start patrolling). */
       if (animator != null)  {
         animator.SetBool("isPatrolling", true);
       }
       if(curHealth <= 0 && !hasDied){
        //enemyhealthBarCanvasImage.GetComponent<CanvasGroup>().alpha = 0;
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
            //enemyhealthBarCanvasImage.GetComponent<CanvasGroup>().alpha = 0;
            //lets you go through door at the end
            if (portalToEnable != null)
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

    public float GetHealth()  {
      return curHealth;
    }





}
