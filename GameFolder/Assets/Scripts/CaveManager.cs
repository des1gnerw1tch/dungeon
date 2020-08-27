using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveManager : MonoBehaviour
{
    public GameObject merchantNPC;

    public GameObject PurpleDungeonPortal;
    public GameObject PurpleDungeonDialogue;

    [SerializeField]
    private BoxCollider2D blueDungeonPortal;
    [SerializeField]
    private BoxCollider2D blueDungeonDialogue;

    public GameObject LavaDungeonPortal;
    public GameObject LavaDungeonDialogue;

    public GameObject CrystalDungeonPortal;
    public GameObject CrystalDungeonDialogue;
    // Start is called before the first frame update
    void Start()
    {
      UpdateScene();
    }

    public void UpdateScene()  {

      if (PlayerProgress.merchantFreed) {
        merchantNPC.SetActive(false);
      } else {
        merchantNPC.SetActive(true);
      }

      //dungeon unlocks
      if (PlayerProgress.hasPurpleKey)  {
        PurpleDungeonPortal.SetActive(true);
        PurpleDungeonDialogue.SetActive(false);
      } else {
        PurpleDungeonPortal.SetActive(false);
        PurpleDungeonDialogue.SetActive(true);
      }

      if (PlayerProgress.hasBlueKey)  {
        blueDungeonPortal.enabled = true;
        blueDungeonDialogue.enabled = false;
      } else {
        blueDungeonPortal.enabled = false;
        blueDungeonDialogue.enabled = true;
      }

      if (PlayerProgress.hasBrownKey)  {
        LavaDungeonPortal.SetActive(true);
        LavaDungeonDialogue.SetActive(false);
      } else {
        LavaDungeonPortal.SetActive(false);
        LavaDungeonDialogue.SetActive(true);
      }

      if (PlayerProgress.hasCrystalKey)  {
        CrystalDungeonPortal.SetActive(true);
        CrystalDungeonDialogue.SetActive(false);
      } else {
        CrystalDungeonPortal.SetActive(false);
        CrystalDungeonDialogue.SetActive(true);
      }
    }
}
