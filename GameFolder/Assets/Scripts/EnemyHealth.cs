using System.Collections;
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
    Vector2 pos;
    public int deathOfObject;
    void Start()
    {
        curHealth = maxHealth;
        pos.Set(0f, 0f);
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
       curHealth -= damage;

       if(curHealth <= 0){
        Die();
	   }
    }
    void Die()
    {
        
        Debug.Log("Enemy number should decrease");
        num = Random.Range(0,11);
        if(num <= 1){
            Instantiate(gundropPrefab, transform.position, Quaternion.identity);
		}else if(num >= 8){
            Instantiate(HealthPrefab, transform.position, Quaternion.identity);
		}
            
        Destroy(gameObject);
        
        
      
	}
   
}
