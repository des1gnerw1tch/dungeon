using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arena : MonoBehaviour
{
    public GameObject[] Spawners;
    // Start is called before the first frame update
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKey("e"))
        {
            Spawners[0].SetActive(true);
        }

    }
}
