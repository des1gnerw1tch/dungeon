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
        eathOfObject();
        Debug.Log("Enemy number should decrease");
        Instantiate(gundropPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
        
        
      
	}
    public void eathOfObject(){
        
        num += 1;
        
       
	}
}
