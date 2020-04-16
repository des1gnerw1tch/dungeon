using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    //private EquippedGun isGunEquipped;
    [HideInInspector]public bool ARshoot =false;
    public float timeCounter;
    private float timeLeft;
    public float bulletForce = 20f;

    void Start(){
        //isGunEquipped = GameObject.FindGameObjectWithTag("AR").GetComponent<EquippedGun>();
        timeLeft = timeCounter;
	}
    // Update is called once per frame
    void Update()
    {   
        if(ARshoot){
            if (Input.GetButton("Fire1"))
            {
                if(timeLeft > 0){
                  timeLeft -= Time.deltaTime;
                  if(timeLeft <= 0){
                      timeLeft = timeCounter;
                      pistolShoot();
                  }
		        }
            }
        }else{
            if (Input.GetButtonDown("Fire1"))
            {
                pistolShoot();
            }  
		}

    }
    void pistolShoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        Destroy(bullet,1f);
    }


}
