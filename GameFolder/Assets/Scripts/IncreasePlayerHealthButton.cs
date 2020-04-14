using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreasePlayerHealthButton : MonoBehaviour
{
    
    private PlayerHealth prefab;
    // Start is called before the first frame update
    public void IncreaseHealth()
    {
        prefab = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        if(prefab.currentHealth < prefab.maxHealth){
            prefab.currentHealth += 10;
            Destroy(gameObject);
		}
        
        
    }


   
}
