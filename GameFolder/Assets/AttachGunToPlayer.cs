using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachGunToPlayer : MonoBehaviour
{
    private Transform firepointPos;
    private EquippedGun GunScript;
    
    
    // Start is called before the first frame update
    void Start()
    {
        firepointPos = GameObject.FindGameObjectWithTag("FirePoint").transform;
        GunScript = GameObject.FindGameObjectWithTag("AR").GetComponent<EquippedGun>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(GunScript.isEquipped == true){
            firepointPos = GameObject.FindGameObjectWithTag("FirePoint").transform;
            GunScript.Gun.transform.position = firepointPos.position;
            GunScript.Gun.transform.rotation = firepointPos.rotation;
		//}
        
    }
}
