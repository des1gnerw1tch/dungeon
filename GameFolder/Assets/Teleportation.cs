using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{

    private Transform player;
    public bool HasbeenDestroyed;
    // Start is called before the first frame update
    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.position = FindObjectOfType<Teleport>().position1;
            FindObjectOfType<Teleport>().Counter += 1;
            Destroy(gameObject);
            
        }
    }
}
