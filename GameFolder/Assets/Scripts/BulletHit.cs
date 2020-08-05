using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    public GameObject hitEffect;
    public int damage = 20;
    public int damageUncertainty;
    [Range(0f, 1f)]
    public float criticalChance;
    public int knockback = 1;
    public string hitSound;
    public bool isPiercing;
    public bool IsTeleporter;
    public static int teleportationCounter;
    public Teleport TeleportScript;
    public Vector3[] positions;
    public float destoryEffectTime = .2f;
    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //GameObject effect = Instantiate(hitEffect, transform.position, transform.rotation);
    //Destroy(effect, .2f);
    //Destroy(gameObject);
    //}

    /* when bullet hits enemy*/
    void OnTriggerEnter2D(Collider2D hitInfo)
    {

        switch (hitSound) {
          case "RPG":
            FindObjectOfType<AudioManager>().Play("rocketLand");
            break;
          case null:
            return;
        }


        EnemyHealth enemy = hitInfo.GetComponent<EnemyHealth>();
        if(enemy != null) {
            int realDamage = damage + (Random.Range(-damageUncertainty, damageUncertainty + 1));
            float chance = Random.Range(0f, 1f);
            bool critical = false;
            if (chance < criticalChance) {
              realDamage = realDamage * 2;
              critical = true;
            }
            enemy.TakeDamage(realDamage, critical);
		     } else {
           if (isPiercing)  {
             Destroy(gameObject);
           }
         }
    if (hitEffect != null)  {
      
            if (IsTeleporter)
            {
                
                Quaternion rotation = Quaternion.Euler(-57.9f, 0, 180);
                GameObject portal = Instantiate(hitEffect, transform.position, rotation);
                Destroy(portal, 10f);
                if (teleportationCounter == 0) {
                    FindObjectOfType<Teleport>().position1 = transform.position;
                    
                }
                if (teleportationCounter == 1)
                {
                    FindObjectOfType<Teleport>().position2 = transform.position;
                   
                }
                teleportationCounter = teleportationCounter + 1;
                if(teleportationCounter >= 2)
                {
                    teleportationCounter = 0;
                }
                

            }
            else
            {
                GameObject effect = Instantiate(hitEffect, transform.position, transform.rotation);
                Destroy(effect, destoryEffectTime);
            }
    }
      if (!isPiercing)  {
        Destroy(gameObject);
      }



    }

    public int GetKnockback() {
      return(knockback);
    }
    void Update()
    {
        if (FindObjectOfType<Teleport>().Counter > 0)
        {
            teleportationCounter = 0;
            FindObjectOfType<Teleport>().Counter = 0;
        }
    }

}
