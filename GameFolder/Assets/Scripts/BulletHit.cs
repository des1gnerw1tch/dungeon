﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    public GameObject hitEffect;
    public int damage = 20;
    public int knockback = 1;
    public string hitSound;
    public bool isPiercing;
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
            enemy.TakeDamage(damage);
		     } else {
           if (isPiercing)  {
             Destroy(gameObject);
           }
         }
    if (hitEffect != null)  {
      GameObject effect = Instantiate(hitEffect, transform.position, transform.rotation);
      Destroy(effect, .2f);
    }
      if (!isPiercing)  {
        Destroy(gameObject);
      }



    }

    public int GetKnockback() {
      return(knockback);
    }

}
