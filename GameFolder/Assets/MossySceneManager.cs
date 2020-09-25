using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossySceneManager : MonoBehaviour
{

    public GameObject[] Markers;
    public bool ShouldActivate = false;
    private bool hasDone = false;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerProgress.nurseFreed && !PlayerProgress.wizardFreed)
        {
            Markers[0].SetActive(false);
            hasDone = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerProgress.nurseFreed && !PlayerProgress.wizardFreed && !hasDone)
        {
            Markers[0].SetActive(false);
            if(ShouldActivate)
            {
                Markers[1].SetActive(true);
            }
        }
    }
}
