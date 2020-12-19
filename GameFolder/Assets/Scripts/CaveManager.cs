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

    public GameObject[] Markers;

    [SerializeField] private GameObject musicPlayerAmbience;
    [SerializeField] private GameObject musicPlayerMusic;
    // Start is called before the first frame update
    void Start()
    {
      UpdateScene();

      //choose between ambience and music
      int rand = Random.Range(0,2);
      if (rand == 0 || !PlayerProgress.merchantFreed)  {
        //enable music
        musicPlayerMusic.SetActive(true);
      } else {
        //enable ambience
         musicPlayerAmbience.SetActive(true);
      }
    }

    public void UpdateScene()  {

      if (PlayerProgress.merchantFreed) {
        merchantNPC.SetActive(false);
      } else {
        merchantNPC.SetActive(true);
      }
        if (!PlayerProgress.nurseFreed)
        {
            Markers[0].SetActive(true);
        }

        if (PlayerProgress.nurseFreed && !PlayerProgress.wizardFreed)
        {
            Markers[1].SetActive(true);
        }

        if (PlayerProgress.wizardFreed && !PlayerProgress.alchemistFreed)
        {
            Markers[2].SetActive(true);
        }
        if (PlayerProgress.alchemistFreed && !PlayerProgress.friendFreed)
        {
            Markers[3].SetActive(true);
        }
        if (PlayerProgress.friendFreed &&( !PlayerProgress.blueCrystalDestroyed || !PlayerProgress.redCrystalDestroyed || !PlayerProgress.greenCrystalDestroyed))
        {
            Markers[4].SetActive(true);
        }
        if(PlayerProgress.blueCrystalDestroyed && PlayerProgress.redCrystalDestroyed && PlayerProgress.greenCrystalDestroyed)
        {
            Markers[5].SetActive(true);
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
