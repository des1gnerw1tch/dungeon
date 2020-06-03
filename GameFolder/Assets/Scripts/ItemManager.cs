using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class ItemManager : MonoBehaviour
{


    public Inventory inventory;
    public scroll scrollScript;
    public shakeCamera Camera;
    public PlayerHealth playerHealthScript;
    public ItemBackboard itemBackboard;
    //canvas stuff
    public GameObject ReloadingText;
    public GameObject bulletsLeftsGameObject;
    public Text bulletsLeft;
    public Text maxAmmoText;
    public Text UIName;

    [HideInInspector]public string itemString;
    [HideInInspector]public GameObject itemInstance;


    public Gun[] guns;
    public Item[] items;
    Gun activeGun;
    Item activeItem;
    private Coroutine reload;

    private bool isWaiting = false;
    private bool deSlomo;
    private int currentAmmo;
    void Start()
    {
      ReloadingText.SetActive(false);
      bulletsLeft.text = null;
      maxAmmoText.text = null;
    }

    // Update is called once per frame
    void Update()
    {

      //equips the gun
      if (itemString != inventory.item[scrollScript.activeSlot]) {

          if (inventory.item[scrollScript.activeSlot] != null)  {

            itemString = inventory.item[scrollScript.activeSlot];
            activeGun = Array.Find(guns, gun => gun.name == itemString);
            if(activeGun != null){
                PlaceGunInPlayerHand(activeGun.objInHand);
			}

            activeItem = Array.Find(items, item => item.name == itemString);
            if(activeItem != null){
                ItemInPlayerHand(activeItem.item);
			}


        }else {
          //if no gun is equipped
          itemString = null;
          ReloadingText.SetActive(false);
          itemBackboard.UpdateImage(null);
          Destroy(itemInstance);
          bulletsLeft.text = null;
          maxAmmoText.text = null;
          UIName.text = null;
          activeGun = null;
          activeItem = null;
          if (reload != null)
            StopCoroutine(reload);
        }
      }

      //handles shoot calling and slomo
      if (itemString != null && activeGun != null) {
        //full auto
        if (activeGun.fullAuto) {

          if (Input.GetButton("Fire1") && !isWaiting) {
                StartCoroutine(Shoot());
                    if (activeGun.HasAnimation){
                        //activeGun.animator.SetBool("IsShooting", true);
                        //start animation;
                    }
          }
          else
          {
                    if (activeGun.HasAnimation)
                    {
                        //activeGun.animator.SetBool("IsShooting", false);
                        //start animation;
                    }
          }
          //semi auto
        } else {

          if (Input.GetButtonDown("Fire1") && !isWaiting) {
            StartCoroutine(Shoot());
                    if (activeGun.HasAnimation)
                    {
                        //activeGun.animator.SetBool("IsShooting", true);
                        //start animation;
                    }
          }
          else
          {
                    if (activeGun.HasAnimation)
                    {
                        //activeGun.animator.SetBool("IsShooting", false);
                        //start animation;
                    }
          }

        }

        //focus mode (slomo) ?
        if(Input.GetMouseButton(1)) {

          deSlomo = false;
          Time.timeScale = 0.5f;
        } else {
            if (!deSlomo) {
              Time.timeScale = 1f;
              deSlomo = true;
            }
        }

        if(Input.GetMouseButtonDown(1)) {
          FindObjectOfType<AudioManager>().Stop("focusEnd");
          FindObjectOfType<AudioManager>().Play("focusStart");
        }

        if(Input.GetMouseButtonUp(1)) {
          FindObjectOfType<AudioManager>().Stop("focusStart");
          FindObjectOfType<AudioManager>().Play("focusEnd");
        }

    }
    if (itemString != null && activeItem != null) {
        //is a health potion
        if (activeItem.isHealthPotion) {

          if (Input.GetButton("Fire1")) {
            UseHealthPotion();
          }
        }
    }

    //handles reload button
    if (itemString != null && activeGun != null) {
      if ((Input.GetKeyDown("r") && !isWaiting && activeGun.currentAmmo != activeGun.maxAmmo) || (Input.GetButtonDown("Fire1") && activeGun.currentAmmo <= 0 && !isWaiting )) {
        reload = StartCoroutine(Reload());
      }
    }

    }

    void PlaceGunInPlayerHand(GameObject GunPrefab){
        Destroy(itemInstance);
        ReloadingText.SetActive(false);
      //  ReloadTimebar.SetTime(0);
        Transform  firepointPos = GameObject.FindGameObjectWithTag("FirePoint").transform;
        Vector2 Pos = new Vector2(firepointPos.position.x, firepointPos.position.y);
        itemInstance = Instantiate(GunPrefab,firepointPos.transform,false);
        itemBackboard.UpdateImage(activeGun);
        bulletsLeft.text = "" + activeGun.currentAmmo;
        maxAmmoText.text = "" + activeGun.maxAmmo;
        UIName.text = activeGun.name;
        isWaiting = false;
        if (reload != null)
          StopCoroutine(reload);
	}
    void ItemInPlayerHand(GameObject ItemPrefab){
        Destroy(itemInstance);
        ReloadingText.SetActive(false);
        Transform  firepointPos = GameObject.FindGameObjectWithTag("FirePoint").transform;
        Vector2 Pos = new Vector2(firepointPos.position.x, firepointPos.position.y);
        itemInstance = Instantiate(ItemPrefab,firepointPos.transform,false);
        bulletsLeft.text = null;
        maxAmmoText.text = null;
        UIName.text = activeItem.name;
        itemBackboard.ShowItemBackboard(activeItem);
        isWaiting = false;
        if (reload != null)
          StopCoroutine(reload);
	}



  IEnumerator Shoot()  {
    if (activeGun.currentAmmo > 0)  {
      activeGun.currentAmmo -= 1;
      bulletsLeft.text = "" + activeGun.currentAmmo;
      isWaiting = true;
      Transform  firepointPos = GameObject.FindGameObjectWithTag("FirePoint").transform;

      //Type of gun, and instantiates bullet/bullets
      if (!activeGun.isShotgun) {
        GameObject bullet = Instantiate(activeGun.bullet, firepointPos.position, firepointPos.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.AddForce(bullet.transform.up * activeGun.bulletForce, ForceMode2D.Impulse);
        FindObjectOfType<AudioManager>().Play(activeGun.name);
        Destroy(bullet, activeGun.bulletLifetime);
      } else {
        for (int i = -2; i <= 2; i++)  {
          //Vector3 offsetRot = new Vector3(0, 0, i);
          GameObject bullet = Instantiate(activeGun.bullet, firepointPos.position, firepointPos.rotation);
          bullet.transform.Rotate(0, 0, i * activeGun.bulletSpread, Space.Self);
          Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

          rb.AddForce(bullet.transform.up * activeGun.bulletForce, ForceMode2D.Impulse);
          Destroy(bullet, activeGun.bulletLifetime);
        }
        FindObjectOfType<AudioManager>().Play(activeGun.name);
      }

      Camera.shake(activeGun.shakeIntensity, 1f, .1f);
      if (activeGun.currentAmmo <= 0) {
        reload = StartCoroutine(Reload());
      } else {
        yield return new WaitForSeconds(1/activeGun.RPS);
        isWaiting = false;
      }
    }

  }

  IEnumerator Reload() {
    FindObjectOfType<AudioManager>().Play("reload");
    string initial = activeGun.name;
    ReloadingText.SetActive(true);
    isWaiting = true;
    yield return new WaitForSeconds(activeGun.reloadTime);
    if (activeGun != null)  {
        FindObjectOfType<AudioManager>().Play("reloadComplete");
        activeGun.currentAmmo = activeGun.maxAmmo;
        isWaiting = false;
        ReloadingText.SetActive(false);
        bulletsLeft.text = "" + activeGun.currentAmmo;
    }

  }
  void UseHealthPotion(){
      if(playerHealthScript.currentHealth < playerHealthScript.maxHealth){
        FindObjectOfType<AudioManager>().Play("gulp");
        playerHealthScript.currentHealth += 50;
        Destroy(itemInstance);
        scrollScript.activeCanvasSlot.DestroyItem();
        inventory.item[scrollScript.activeSlot] = null;
      }
  }

}
