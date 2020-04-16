using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPG_Equipped : MonoBehaviour
{
    private Transform firepointPos;
    private Shooting shootingScript;
    public GameObject GunPrefab;
    private DestroyGun DestroyGunScript;
    [HideInInspector]public GameObject gunInstance;
    
    public void RPGAttach()
    {
        //DestroyGunScript = GameObject.FindGameObjectWithTag("Player").GetComponent<DestroyGun>();
        //DestroyGunScript.DropGun();
        
        shootingScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Shooting>();
        firepointPos = GameObject.FindGameObjectWithTag("FirePoint").transform;
        Vector2 Pos = new Vector2(firepointPos.position.x, firepointPos.position.y);
        gunInstance = Instantiate(GunPrefab,firepointPos.transform,false);
        shootingScript.RPGisShooting = true;
        
        
    }

    // Update is called once per frame
   
}
