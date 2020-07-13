using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeAlchemist : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
      PlayerProgress.alchemistFreed = true;
      FindObjectOfType<GameSaveManager>().SavePlayer();
    }

}
