using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manage : MonoBehaviour
{
    public GameObject Marker;

    private void Update()
    {
        if (PlayerProgress.alchemistFreed)
        {
            Marker.SetActive(true);
        }
    }
}
