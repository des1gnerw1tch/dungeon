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
        offset.Set(0, 2, 0);
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
            
            if(id == 1)
            {
                player.position = FindObjectOfType<Teleport>().position2 - offset;
            }
            if(id == 2)
            {
                player.position = FindObjectOfType<Teleport>().position1- offset;
            }
            
            FindObjectOfType<Teleport>().Counter += 1;
            //Destroy(gameObject);
            
        }
    }
}
