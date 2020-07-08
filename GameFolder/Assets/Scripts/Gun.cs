using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Gun {

    public string name;
    public string rarity;

    public GameObject objInHand;
    public GameObject bullet;
    public GameObject canvasImage;
    public float shakeIntensity;

    public float reloadTime;
    public int maxAmmo;
    public int currentAmmo;
    public float bulletForce;
    public float RPS;
    public float bulletLifetime;
    public bool fullAuto;
    public float bulletSpread;
    public bool isShotgun;
    public bool HasAnimation;
    //public Animator animator;


}
