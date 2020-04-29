using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject ARbulletPrefab;
    public GameObject rocketPrefab;
    public GameObject sniperbulletPrefab;
    public shakeCamera Camera;
    //private EquippedGun isGunEquipped;
    [HideInInspector]public string whatGunIsEquippedString;

    public float bulletForce = 20f;
    public float rocketForce = 8f;
    public GameObject ARPrefab;
    public GameObject RPGPrefab;
    public GameObject SniperPrefab;
    public GameObject healthPrefab;
    public GameObject torchPrefab;
    private Transform firepointPos;
    [HideInInspector]public bool showGun = false;
    [HideInInspector]public GameObject gunInstance;
    //Creates firerates for each gun it would be good if all of these where one
    public float timeCounter;
    private float timeLeft;
    private float sniperFireRate = 0;
    private float RpgFireRate = 0;
    public float ARreloadTime = 2f;
    public float ARreloadcounter;
    private int ARclip;
    private int MaxARclip = 30;
    private int RPGclip;
    private int MaxRPGclip = 1;
    private int sniperClip;
    private int maxSniperClip = 2;
    public ReloadTimebarScript ReloadTimebar;

    public GameObject ReloadingText;
    public GameObject bulletsLeftsGameObject;
    public Text bulletsLeft;

    public PlayerHealth playerHealthScript;
    public bool hasHealed = false;
    void Start(){
        //isGunEquipped = GameObject.FindGameObjectWithTag("AR").GetComponent<EquippedGun>();
        timeLeft = timeCounter;
        ARclip = MaxARclip;
        ARreloadcounter = ARreloadTime;
        ReloadingText.SetActive(false);
        bulletsLeftsGameObject.SetActive(false);

        RPGclip = MaxRPGclip;
        sniperClip = maxSniperClip;
	}
    // Update is called once per frame
    void Update()
    {

    switch (whatGunIsEquippedString)  {
      //--------------------------------

      case "AR":

        bulletsLeftsGameObject.SetActive(true);
        bulletsLeft.text = "" + ARclip;
        if((Input.GetKey("r") && ARclip != MaxARclip)|| ARclip <= 0 ){
            if(ARreloadcounter > 0 ){
                ReloadingText.SetActive(true);
                ARclip = 0;
                bulletsLeftsGameObject.SetActive(false);
                ARreloadcounter -= Time.deltaTime;
                ReloadTimebar.SetTime(ARreloadcounter);
                if(ARreloadcounter <= 0){
                  ARclip = MaxARclip;
                  ARreloadcounter = ARreloadTime;
                  bulletsLeft.text = "" +ARclip;
                  ReloadingText.SetActive(false);
                  bulletsLeftsGameObject.SetActive(true);
                }
             }
		}
        if(!showGun){
            PlaceGunInPlayerHand(ARPrefab);
            showGun = true;
         }
        if (Input.GetButton("Fire1") && ARclip > 0)
        {

            if(timeLeft > 0 ){
                timeLeft -= Time.deltaTime;

                if(timeLeft <= 0){
                  ARShoot();
                  ARclip -= 1;
                  bulletsLeft.text = "" +ARclip;
                  Camera.shake(2f, 1f, .1f);
                  timeLeft = timeCounter;
                 }
             }
        }
        break;
        //------------------------------------------
      case "RPG":

        bulletsLeftsGameObject.SetActive(true);
        bulletsLeft.text = "" +RPGclip;
        if(!showGun){
            PlaceGunInPlayerHand(RPGPrefab);
            showGun = true;
        }


        if((Input.GetKey("r") && RPGclip != MaxRPGclip)|| RPGclip <= 0 ){
            if( RpgFireRate > 0 ){
              RpgFireRate -= Time.deltaTime;
              ReloadTimebar.SetTime(RpgFireRate);
              ReloadingText.SetActive(true);
              if(RpgFireRate <= 0){
                  ReloadingText.SetActive(false);
                  RPGclip = MaxRPGclip;
                  bulletsLeft.text = "" +RPGclip;
		      }

            }
        }
        if (Input.GetButtonDown("Fire1") && RPGclip > 0)
        {
            RPGshoot();
            Camera.shake(3f, .1f, .2f);
            RpgFireRate = 2;
            RPGclip -= 1;

        }
        break;
        //-----------------------------------
      case "Sniper":
        bulletsLeft.text = "" +sniperClip;
        bulletsLeftsGameObject.SetActive(true);
        if(!showGun){
            PlaceGunInPlayerHand(SniperPrefab);
            showGun = true;
        }

        if((Input.GetKey("r") && sniperClip != maxSniperClip)|| sniperClip <= 0 ){

            if( sniperFireRate > 0 ){
                    bulletsLeftsGameObject.SetActive(false);
                    sniperClip = 0;
                    sniperFireRate -= Time.deltaTime;
                    ReloadTimebar.SetTime(sniperFireRate);
                    ReloadingText.SetActive(true);
                    if(sniperFireRate <= 0){
                        ReloadingText.SetActive(false);
                        sniperClip = maxSniperClip;
                        bulletsLeft.text = "" +sniperClip;
                        bulletsLeftsGameObject.SetActive(true);
		            }
            }
        }
        if (Input.GetButtonDown("Fire1") && sniperClip > 0)
        {
            ReloadingText.SetActive(false);
            sniperShoot();
            Camera.shake(10f, .1f, .2f);
            sniperClip -= 1;
            sniperFireRate = 1.7f;
        }
        break;
      //------------------------------------------
      case "HealthPotion":
        bulletsLeftsGameObject.SetActive(false);
        ReloadingText.SetActive(false);
        ReloadTimebar.SetTime(0);
        if(!showGun){
            PlaceGunInPlayerHand(healthPrefab);
            showGun = true;
        }
        if (Input.GetButtonDown("Fire1"))
          {
              if(playerHealthScript.currentHealth < playerHealthScript.maxHealth){
                playerHealthScript.currentHealth += 20;
                Destroy(gunInstance);
                hasHealed = true;
		       }
          }

        break;
      case "Torch":
        bulletsLeftsGameObject.SetActive(false);
        ReloadingText.SetActive(false);
        ReloadTimebar.SetTime(0);
        if(!showGun){
            PlaceGunInPlayerHand(torchPrefab);
            showGun = true;
        }
        break;
      default:
        bulletsLeftsGameObject.SetActive(false);
        ReloadingText.SetActive(false);
        ReloadTimebar.SetTime(0);
        if(!showGun){

          Destroy(gunInstance);
          }
          if (Input.GetButtonDown("Fire1"))
          {
              pistolShoot();
              Camera.shake(1f, 1f, .1f);
          }
          break;

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
    void ARShoot()
    {
        GameObject bullet = Instantiate(ARbulletPrefab, firePoint.position, firePoint.rotation);
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
        ReloadingText.SetActive(false);
        ReloadTimebar.SetTime(0);
        firepointPos = GameObject.FindGameObjectWithTag("FirePoint").transform;
        Vector2 Pos = new Vector2(firepointPos.position.x, firepointPos.position.y);
        gunInstance = Instantiate(GunPrefab,firepointPos.transform,false);
	}
    /*int reloadGun(float reloadTime, int MaxClipSize){
     for(float i = reloadTime; i >= 0 ; i-= Time.deltaTime){
        if(i <= .1){
            return MaxClipSize;
            break;
		}
        return 0;

	 }
     return 0;
	}*/



}
