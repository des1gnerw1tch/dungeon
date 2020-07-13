using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeNurse : MonoBehaviour
{

    void Start()
    {
        PlayerProgress.nurseFreed = true;
        FindObjectOfType<GameSaveManager>().SavePlayer();
    }


}
