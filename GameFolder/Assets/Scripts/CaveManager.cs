using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveManager : MonoBehaviour
{
    public GameObject merchantNPC;
    // Start is called before the first frame update
    void Start()
    {
      UpdateScene();
    }

    void UpdateScene()  {
      if (PlayerProgress.merchantFreed) {
        merchantNPC.SetActive(false);
      } else {
        merchantNPC.SetActive(true);
      }
    }
}
