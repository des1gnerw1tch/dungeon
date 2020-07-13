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
    [SerializeField] private bool tintOnStart = false;


    //scripts
    public Dissolve dissolve;
    public Tint tint;
    public Animator animator;
    public bool isBoss;
    [SerializeField] private bool stopMusicOnDeath = false;
    public GameObject[] objectsToEnable;
    private EnemyHealthBar EnemyHealthBarScript;
    private GameObject enemyhealthBarCanvasImage;

    //Damage Indicator
    public GameObject damagePopUp;

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

        //tints on start
        if (tintOnStart)  {
          tint.SetTintColor(new Color(1, 1, 1, 1f));
          tint.SetTintFadeSpeed(2f);
        }
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
       //as soon as shot, will tint. Makes sure to set tint fade speed to correctly
       tint.SetTintFadeSpeed(6f);
       tint.SetTintColor(new Color(1, 1, 1, 1f));
       /*when shot while idling, the enemy will move away (start patrolling). */
       if (animator != null)  {
         animator.SetBool("isPatrolling", true);
       }
       /*instantiates damage pop up*/
       Vector2 pos = new Vector2(transform.position.x + 49.6355f + Random.Range(-1f, 1f), transform.position.y -47.0451f + Random.Range(-1f, 1f));
       DamagePop popUp = Instantiate(damagePopUp, pos, Quaternion.identity).GetComponent<DamagePop>();
       popUp.SetDamage(damage);
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
          animator.SetTrigger("isDead");
          FindObjectOfType<DropManager>().Drop(enemyID, transform.position);
          FindObjectOfType<AudioManager>().Play(enemyID);
          if (isBoss) {
            killMinions();
            //kill music
              if (stopMusicOnDeath)
                FindObjectOfType<AudioManager>().Stop(FindObjectOfType<MusicPlayer>().themeName);
            //enemyhealthBarCanvasImage.GetComponent<CanvasGroup>().alpha = 0;
            //lets you go through door at the end
            if (objectsToEnable.Length != 0) {
              foreach(GameObject obj in objectsToEnable)  {
                obj.SetActive(true);
              }
            }

          }
        }

      }

    void killMinions()  {
      EnemyHealth[] minions = Object.FindObjectsOfType<EnemyHealth>();
      Spawner[] spawners = Object.FindObjectsOfType<Spawner>();
      MinionSpawn[] bossSpawners = GetComponents<MinionSpawn>();
      //kills all minions
      foreach (EnemyHealth minion in minions) {
        minion.Die();
      }

      //turns off spawners
      foreach (Spawner spawner in spawners) {
        spawner.enabled = false;
      }
      //turns off boss spawn minions
      foreach (MinionSpawn script in bossSpawners) {
        script.enabled = false;
      }

    }

    public float GetHealth()  {
      return curHealth;
    }





}
