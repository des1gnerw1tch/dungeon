using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxHealth = 100;
    private float curHealth;
    void Start()
    {
        curHealth = maxHealth;
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
       curHealth -= damage;

       if(curHealth <= 0){
        Die();
	   }
    }
    void Die(){

      Destroy(gameObject);
	}
}
