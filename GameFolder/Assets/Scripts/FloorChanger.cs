using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorChanger : MonoBehaviour
{
    // Start is called before the first frame update
    //public int counter = 0;
    public GameObject[] floors;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            floors[0].SetActive(false);
            floors[1].SetActive(true);
            
        }
    }
}
