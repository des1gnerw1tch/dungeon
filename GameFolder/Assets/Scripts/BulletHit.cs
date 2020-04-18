using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    public GameObject hitEffect;
    public int damage = 20;
    //void OnCollisionEnter2D(Collision2D collision)
    //{
        //GameObject effect = Instantiate(hitEffect, transform.position, transform.rotation);
        //Destroy(effect, .2f);
        //Destroy(gameObject);
    //}

    /* when bullet hits enemy*/
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EnemyHealth enemy = hitInfo.GetComponent<EnemyHealth>();

        if(enemy != null) {
            enemy.TakeDamage(damage);
		}

        GameObject effect = Instantiate(hitEffect, transform.position, transform.rotation);
        Destroy(effect, .2f);
        Destroy(gameObject);
    }

}
