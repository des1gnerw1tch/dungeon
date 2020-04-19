﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxHealth = 100;

    private float curHealth;
    public int num;
    public GameObject gundropPrefab;
    public GameObject HealthPrefab;

    public Dissolve dissolve;
    public Tint tint;

    Vector2 pos;
    public int deathOfObject;
    public bool hasDroppedGun = false;

    //scripts

    public mobDrop gunDrop;
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
       if(curHealth <= 0 && !hasDroppedGun){
        Die();
	   }
    }
    void Die()
    {

        hasDroppedGun = true;
        /*num = Random.Range(0,11);
        if(num <= 1 && !hasDroppedGun){
            Instantiate(gundropPrefab, transform.position, Quaternion.identity);
            hasDroppedGun = true;
		}else if(num >= 8){
            Instantiate(HealthPrefab, transform.position, Quaternion.identity);
		}*/
        //disolves the enemy
        dissolve.play(2f);
        gunDrop.SpiderDrop(transform.position);


	}

}
