using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiChamberManager : MonoBehaviour
{
    [SerializeField]
    private GameObject blueCrystal;

    [SerializeField]
    private GameObject greenCrystal;

    [SerializeField]
    private GameObject redCrystal;

    void Start()  {
      UpdateScene();
    }
    // Update is called once per frame
    void UpdateScene()
    {
      if (PlayerProgress.blueCrystalDestroyed)  {
        Destroy(blueCrystal);
      }
      if (PlayerProgress.greenCrystalDestroyed)  {
        Destroy(greenCrystal);
      }
      if (PlayerProgress.redCrystalDestroyed)  {
        Destroy(redCrystal);
      }
    }
}
