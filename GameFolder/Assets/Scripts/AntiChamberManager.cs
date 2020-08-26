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
    }
    private void Update()
    {
        if(PlayerProgress.redCrystalDestroyed && PlayerProgress.greenCrystalDestroyed && PlayerProgress.blueCrystalDestroyed)
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
        if (PlayerProgress.greenCrystalDestroyed && PlayerProgress.blueCrystalDestroyed)
        {
            
            FirstDialouge.SetActive(false);
            SecondDialouge.SetActive(false);
            ThirdDialouge.SetActive(true);
        }
    }
}
