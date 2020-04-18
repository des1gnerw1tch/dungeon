using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject rocketPrefab;
    public GameObject sniperbulletPrefab;
    public shakeCamera Camera;
    //private EquippedGun isGunEquipped;
    public string whatGunIsEquippedString;
    
    public float bulletForce = 20f;
    public float rocketForce = 8f;
    public GameObject ARPrefab;
    public GameObject RPGPrefab;
    public GameObject SniperPrefab;
    private Transform firepointPos;
    [HideInInspector]public bool showGun = false;
    [HideInInspector]public GameObject gunInstance;
    //Creates firerates for each gun it would be good if all of these where one
    public float timeCounter;
    private float timeLeft;
    private float sniperFireRate = 0;
    private float RpgFireRate = 0;
    public ReloadTimebarScript ReloadTimebar;
    void Start(){
        //isGunEquipped = GameObject.FindGameObjectWithTag("AR").GetComponent<EquippedGun>();
        timeLeft = timeCounter;
        
        
	}
    // Update is called once per frame
    void Update()
    {
        if(whatGunIsEquippedString == "AR"){
            if(!showGun){
                PlaceGunInPlayerHand(ARPrefab);
                showGun = true;
			}
            if (Input.GetButton("Fire1"))
            {   
                
                if(timeLeft > 0 ){
                    timeLeft -= Time.deltaTime;
                    
                    if(timeLeft <= 0){
                      pistolShoot();
                      Camera.shake(2f, 1f, .1f);
                      timeLeft = timeCounter;
					}
				}

            }
        }else if(whatGunIsEquippedString == "RPG"){
            if(!showGun){
                PlaceGunInPlayerHand(RPGPrefab);
                showGun = true;
			}
            if( RpgFireRate > 0 ){
                    
                    RpgFireRate -= Time.deltaTime;
                    ReloadTimebar.SetTime(RpgFireRate + .61f);
			}
            
            if (Input.GetButtonDown("Fire1") && RpgFireRate <= 0)
            {
                RPGshoot();
                Camera.shake(3f, .1f, .2f);
                RpgFireRate = 5;
            }
		}else if(whatGunIsEquippedString == "Sniper"){
            if(!showGun){
                PlaceGunInPlayerHand(SniperPrefab);
                showGun = true;
			}
            
            if( sniperFireRate > 0 ){
                    sniperFireRate -= Time.deltaTime;
                    ReloadTimebar.SetTime(sniperFireRate + .61f);
			}
            if (Input.GetButtonDown("Fire1") && sniperFireRate <= 0)
            {
                sniperShoot();
                Camera.shake(10f, .1f, .2f);
                sniperFireRate = 3;
            }
		}else{
            if (Input.GetButtonDown("Fire1"))
            {
                pistolShoot();
                Camera.shake(1f, 1f, .1f);
            }
		}

    }
    void pistolShoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        Destroy(bullet,1f);
        Camera.shake(2f, 1f, .1f);
        
    }
    void sniperShoot()
    {
        GameObject bullet = Instantiate(sniperbulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * (bulletForce * 2f) , ForceMode2D.Impulse);
        Destroy(bullet,1f);
        Camera.shake(2f, 1f, .1f);
        
    }
    void RPGshoot(){
        GameObject Rocket = Instantiate(rocketPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = Rocket.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        Destroy(Rocket,2f);
	}
    void PlaceGunInPlayerHand(GameObject GunPrefab){
        Destroy(gunInstance);
        firepointPos = GameObject.FindGameObjectWithTag("FirePoint").transform;
        Vector2 Pos = new Vector2(firepointPos.position.x, firepointPos.position.y);
        gunInstance = Instantiate(GunPrefab,firepointPos.transform,false);
	}
    


}
