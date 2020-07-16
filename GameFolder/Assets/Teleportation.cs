using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{

    private Transform player;
    public bool HasbeenDestroyed;
    public static int counterID;
    public int id;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset.Set(0, 1.2f, 0);
        counterID += 1;
        id = counterID;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        
        Debug.Log(id);
        if (other.gameObject.tag == "Player")
        {
            
            
            if(id % 2 == 0)
            {
                player.position = FindObjectOfType<Teleport>().position1- offset;
            }
            else
            {
                player.position = FindObjectOfType<Teleport>().position2 - offset;
            }
            
            
            //FindObjectOfType<Teleport>().Counter += 1;
            
            
            
        }
    }
}
