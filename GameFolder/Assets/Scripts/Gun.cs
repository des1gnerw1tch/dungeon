using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Gun {

    public string name;

    public GameObject objInHand;
    public GameObject bullet;
    public float shakeIntensity;

    public float reloadTime;
    public int maxAmmo;
    public int currentAmmo;
    public float bulletForce;
    public float RPS;
    public bool fullAuto;

    public void Use() {
      /*GameObject bullet = Instantiate(ARbulletPrefab, firePoint.position, firePoint.rotation);
      Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
      rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
      Destroy(bullet,1f);
      Camera.shake(2f, 1f, .1f);*/
    }
}
