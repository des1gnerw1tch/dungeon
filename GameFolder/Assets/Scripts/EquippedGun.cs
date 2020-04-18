using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquippedGun : MonoBehaviour
{
    private Transform firepointPos;
    private Shooting shootingScript;
    public GameObject GunPrefab;
    public string GunType;
    //public SpriteRenderer RPG;
    [HideInInspector]public GameObject gunInstance;
    
    public void use()
    {   
        //RPG.sortingOrder = 0;
        shootingScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Shooting>();
        //firepointPos = GameObject.FindGameObjectWithTag("FirePoint").transform;
        //Vector2 Pos = new Vector2(firepointPos.position.x, firepointPos.position.y);
        //gunInstance = Instantiate(GunPrefab,firepointPos.transform,false);
        shootingScript.whatGunIsEquippedString = GunType;
        shootingScript.showGun = false;
    }

    // Update is called once per frame
    public void Update()
    {
        
    }
}
