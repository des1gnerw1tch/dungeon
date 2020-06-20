using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldManager : MonoBehaviour
{
  [Header("Dialogue is the vacant dialogue, portal is CaveToMain")]
    public BoxCollider2D dialogueCollider;
    public BoxCollider2D portalCollider;

    public BoxCollider2D dialogueGunShop;
    public BoxCollider2D portalGunShop;

    public BoxCollider2D dialogueHospital;
    public BoxCollider2D portalHospital;
    //public PlayerProgress progress;
    // Start is called before the first frame update
    void Start()
    {
      UpdateScene();
    }

    public void UpdateScene()
    {
      //wizard
      if (PlayerProgress.wizardFreed) {
        dialogueCollider.enabled = false;
        portalCollider.enabled = true;
      } else {
        dialogueCollider.enabled = true;
        portalCollider.enabled = false;
      }

      //gun shop
      if (PlayerProgress.merchantFreed) {
        dialogueGunShop.enabled = false;
        portalGunShop.enabled = true;
      } else {
        dialogueGunShop.enabled = true;
        portalGunShop.enabled = false;
      }

      //hospital
      if (PlayerProgress.nurseFreed) {
        dialogueHospital.enabled = false;
        portalHospital.enabled = true;
      } else {
        dialogueHospital.enabled = true;
        portalHospital.enabled = false;
      }

      }

  }
