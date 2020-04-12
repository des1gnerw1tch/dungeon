using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float spiderMaxHealth = 100;
    private float spiderCurrentHealth;
    void Start()
    {
        spiderCurrentHealth = spiderMaxHealth;
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
       spiderCurrentHealth -= damage;

       if(spiderCurrentHealth <= 0){
        Die();
	   }
    }
    void Die(){
        Destroy(gameObject);
	}
}
