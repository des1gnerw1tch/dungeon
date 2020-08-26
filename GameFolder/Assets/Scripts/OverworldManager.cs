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

    public BoxCollider2D dialogueAlchemist;
    public BoxCollider2D portalAlchemist;

    public BoxCollider2D dialogueMansion;
    public BoxCollider2D portalCredits;
    //public PlayerProgress progress;
    // Start is called before the first frame update
    void Start()
    {
      /*turns off the power in the lava dungeon if turned on, this is here to make sure that
      when you die, lava dung progress is reset. */
      LavaDungManager.powerOn = false;
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

      //alchemist
      if (PlayerProgress.alchemistFreed)  {
        dialogueAlchemist.enabled = false;
        portalAlchemist.enabled = true;
      } else {
        dialogueAlchemist.enabled = true;
        portalAlchemist.enabled = false;
      }

      //the mansion
      if (PlayerProgress.blueCrystalDestroyed && PlayerProgress.redCrystalDestroyed && PlayerProgress.greenCrystalDestroyed)  {
        dialogueMansion.enabled = false;
        portalCredits.enabled = true;
      } else {
        dialogueMansion.enabled = true;
        portalCredits.enabled = false;
      }

      }

  }
