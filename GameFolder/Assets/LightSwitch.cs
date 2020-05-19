using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public GameObject Lights;
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player")){
            if (Input.GetKey("e"))
            {
                Lights.SetActive(true);
                Debug.Log("lights should turn on.");
            }
            Debug.Log("is working.");
        }
    }
}
