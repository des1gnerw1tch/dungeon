using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiChamberManager : MonoBehaviour
{
    [SerializeField]
    private GameObject blueCrystal;
    [SerializeField]
    private GameObject FirstDialouge;

    [SerializeField]
    private GameObject greenCrystal;
    [SerializeField]
    private GameObject SecondDialouge;

    [SerializeField]
    private GameObject redCrystal;
    [SerializeField]
    private GameObject ThirdDialouge;

    [SerializeField]
    private GameObject Cage;
    [SerializeField]
    private GameObject FinalDialouge;
    [SerializeField]
    private GameObject grandpa;

    private bool active = true;

    void Start()  {
      UpdateScene();
    }
    // Update is called once per frame
    void UpdateScene()
    {
      if (PlayerProgress.blueCrystalDestroyed)  {
            Destroy(blueCrystal);
            FirstDialouge.SetActive(false);
            SecondDialouge.SetActive(true);
            ThirdDialouge.SetActive(false);
        }
      if (PlayerProgress.greenCrystalDestroyed)  {
        Destroy(greenCrystal);
            FirstDialouge.SetActive(false);
            SecondDialouge.SetActive(false);
            ThirdDialouge.SetActive(true);
      }
      if (PlayerProgress.redCrystalDestroyed)  {
        Destroy(redCrystal);
      }

      if (PlayerProgress.blueCrystalDestroyed && PlayerProgress.redCrystalDestroyed && PlayerProgress.greenCrystalDestroyed)  {
        active = false;
        Cage.SetActive(false);
        FinalDialouge.SetActive(false);
        grandpa.SetActive(false);
        ThirdDialouge.SetActive(false);
      }
    }
    private void Update()
    {
        if(PlayerProgress.redCrystalDestroyed && PlayerProgress.greenCrystalDestroyed && PlayerProgress.blueCrystalDestroyed && active)
        {
            Cage.SetActive(false);
            FinalDialouge.SetActive(true);
        }
        if (PlayerProgress.blueCrystalDestroyed && !PlayerProgress.greenCrystalDestroyed)
        {

            FirstDialouge.SetActive(false);
            SecondDialouge.SetActive(true);
            ThirdDialouge.SetActive(false);
        }
        if (PlayerProgress.greenCrystalDestroyed && PlayerProgress.blueCrystalDestroyed && active)
        {

            FirstDialouge.SetActive(false);
            SecondDialouge.SetActive(false);
            ThirdDialouge.SetActive(true);
        }
    }
}
