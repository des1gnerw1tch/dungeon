using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class itemUIHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject detailsWindow;
    public ItemManager itemManager;

    private float minFireRate = 10000;
    private float maxFireRate;
    [SerializeField]
    private Slider fireRateSlider;

    private float minDamage= 10000;
    private float maxDamage;
    [SerializeField]
    private Slider damageSlider;

    private float minImpact= 10000;
    private float maxImpact;
    [SerializeField]
    private Slider impactSlider;

    private float minReload= 10000;
    private float maxReload;
    [SerializeField]
    private Slider reloadSlider;

    void Start()  {
      //sorts through each gun and finds min and maxes for sliders
      foreach(Gun gun in itemManager.guns)  {

        //finding minimums
        if (gun.RPS < minFireRate)  {
          minFireRate = gun.RPS;
        }

        if (gun.bullet.GetComponent<BulletHit>().damage < minDamage)  {
          minDamage = gun.bullet.GetComponent<BulletHit>().damage;
        }

        if (gun.bullet.GetComponent<BulletHit>().knockback < minImpact)  {
          minImpact = gun.bullet.GetComponent<BulletHit>().knockback;
        }

        if (gun.reloadTime < minReload)  {
          minReload = gun.reloadTime;
        }

        //finding maximums
        if (gun.RPS > maxFireRate)  {
          maxFireRate = gun.RPS;
        }

        if (gun.bullet.GetComponent<BulletHit>().damage > maxDamage && gun.name != "Explorer's Shotgun")  {
          maxDamage = gun.bullet.GetComponent<BulletHit>().damage;
        }

        if (gun.bullet.GetComponent<BulletHit>().knockback > maxImpact && gun.name != "RPG")  {
          maxImpact = gun.bullet.GetComponent<BulletHit>().knockback;
        }

        if (gun.reloadTime > maxReload && gun.name != "PortalGun")  {
          maxReload = gun.reloadTime;
        }
      }

      //settings sliders min and max values
      fireRateSlider.minValue = minFireRate - (minFireRate/2);
      fireRateSlider.maxValue = maxFireRate;

      damageSlider.minValue = minDamage - (minDamage / 2);
      damageSlider.maxValue = maxDamage;

      impactSlider.minValue = minImpact - (minImpact / 2);
      impactSlider.maxValue = maxImpact;

      reloadSlider.minValue = minReload - (minReload / 2);
      reloadSlider.maxValue = maxReload;

      //printing out stuff
      Debug.Log("min fire rate " + minFireRate + "max fire rate " + maxFireRate + "min damage " + minDamage + " max damage " +
      maxDamage + " min impact " + minImpact + " max impact " + maxImpact + " min reload " + minReload + " max reload " + maxReload);
    }


    //showing detail window
    public void OnPointerEnter(PointerEventData eventData)  {
      if (itemManager.activeGun != null)  {
        detailsWindow.SetActive(true);
      }
      updateDetailWindow();

    }
    public void OnPointerExit(PointerEventData eventData)  {
      detailsWindow.SetActive(false);
    }

    public void updateDetailWindow()  {
      if (itemManager.activeGun != null)  {
        fireRateSlider.value = itemManager.activeGun.RPS;
        damageSlider.value = itemManager.activeGun.bullet.GetComponent<BulletHit>().damage;
        impactSlider.value = itemManager.activeGun.bullet.GetComponent<BulletHit>().knockback;
        reloadSlider.value =  (maxReload - itemManager.activeGun.reloadTime) + .4f;
      } else {
        detailsWindow.SetActive(false);
      }
    }
}
