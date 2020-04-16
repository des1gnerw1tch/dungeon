using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGun : MonoBehaviour
{
    private Shooting shootingScript;
    // Start is called before the first frame update
    void Start()
    {
        shootingScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Shooting>();
    }
    public void DropGun()
    {
        foreach(Transform child in transform){
            GameObject.Destroy(child.gameObject);
            shootingScript.ARshoot = false;
            shootingScript.RPGisShooting = false;
      }
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
