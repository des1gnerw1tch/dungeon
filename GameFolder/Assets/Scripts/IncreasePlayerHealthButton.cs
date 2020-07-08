using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreasePlayerHealthButton : MonoBehaviour
{
    
    private PlayerHealth prefab;
    private Shooting ShootingScript;
    // Start is called before the first frame update
    public void IncreaseHealth()
    {
        prefab = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        ShootingScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Shooting>();
        if(prefab.currentHealth < prefab.maxHealth){
            prefab.currentHealth += 10;
            Destroy(gameObject);
		}
        
        
    }
   /* public void Update(){
        if(ShootingScript.hasHealed == true){
              Destroy(gameObject);
              ShootingScript.hasHealed = false;
		}
	}*/


   
}
