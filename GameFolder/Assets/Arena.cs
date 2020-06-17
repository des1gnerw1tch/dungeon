using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arena : MonoBehaviour
{
    public GameObject[] Spawners;
    private int counter = 0;
    // Start is called before the first frame update
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKey("e"))
        {
            Spawners[counter].SetActive(true);
        }

    }
    void Update()
    {
        if(Spawners[counter].GetComponent<Spawner>().numAlive == Spawners[counter].GetComponent<Spawner>().max)
        {
            if(counter < Spawners.Length - 1)
            {
                Spawners[counter].SetActive(false);
                counter += 1;
                //Spawn loot at the tree
                //Spawners[counter].SetActive(true);
            }
            else
            {
                Debug.Log("end of Arena");
            }
            
        }
    }
}
