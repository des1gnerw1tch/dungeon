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

    //canvas stuff
    public GameObject ReloadingText;
    public GameObject bulletsLeftsGameObject;
    public Text bulletsLeft;

    private string itemString;
    [HideInInspector]public GameObject itemInstance;

    public Gun[] guns;
    public Item[] items;
    Gun activeGun;

    private bool isWaiting = false;

    private int currentAmmo;
    void Start()
    {
      ReloadingText.SetActive(false);
      bulletsLeft.text = null;
    }

    // Update is called once per frame
    void Update()
    {

      //equips the gun
      if (itemString != inventory.item[scrollScript.activeSlot]) {

          if (inventory.item[scrollScript.activeSlot] != null)  {

            itemString = inventory.item[scrollScript.activeSlot];
            activeGun = Array.Find(guns, gun => gun.name == itemString);
            PlaceGunInPlayerHand(activeGun.objInHand);

        } else {
          //if no gun is equipped
          itemString = null;
          ReloadingText.SetActive(false);
          Destroy(itemInstance);
          bulletsLeft.text = null;
        }
      }
      //handles shoot calling

      if (itemString != null) {
        //full auto
        if (activeGun.fullAuto) {

          if (Input.GetButton("Fire1") && !isWaiting) {
            StartCoroutine(Shoot());
          }
          //semi auto
        } else {

          if (Input.GetButtonDown("Fire1") && !isWaiting) {
            StartCoroutine(Shoot());
          }

        }
    }

    //handles reload button
    if (itemString != null) {
      if ((Input.GetKeyDown("r") && !isWaiting && activeGun.currentAmmo != activeGun.maxAmmo) || (Input.GetButtonDown("Fire1") && activeGun.currentAmmo <= 0 && !isWaiting )) {
        StartCoroutine(Reload());
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
        bulletsLeft.text = "" + activeGun.currentAmmo;
        isWaiting = false;
	}



  IEnumerator Shoot()  {
    if (activeGun.currentAmmo > 0)  {
      activeGun.currentAmmo -= 1;
      bulletsLeft.text = "" + activeGun.currentAmmo;
      isWaiting = true;
      Transform  firepointPos = GameObject.FindGameObjectWithTag("FirePoint").transform;
      GameObject bullet = Instantiate(activeGun.bullet, firepointPos.position, firepointPos.rotation);
      Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

      rb.AddForce(firepointPos.up * activeGun.bulletForce, ForceMode2D.Impulse);
      Destroy(bullet,1f);
      Camera.shake(activeGun.shakeIntensity, 1f, .1f);
      if (activeGun.currentAmmo <= 0) {
        StartCoroutine(Reload());
      } else {
        yield return new WaitForSeconds(1/activeGun.RPS);
        isWaiting = false;
      }
    }

  }

  IEnumerator Reload() {

    string initial = activeGun.name;
    ReloadingText.SetActive(true);
    isWaiting = true;
    yield return new WaitForSeconds(activeGun.reloadTime);
    if (initial == activeGun.name) {
      activeGun.currentAmmo = activeGun.maxAmmo;
      isWaiting = false;
      ReloadingText.SetActive(false);
      bulletsLeft.text = "" + activeGun.currentAmmo;
    }

  }

}
