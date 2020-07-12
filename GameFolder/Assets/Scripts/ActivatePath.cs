using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePath : MonoBehaviour
{
    public GameObject TileMapActivate;
    public GameObject TileMapaDeactivate;
    public static bool hasDropped = false;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            TileMapActivate.SetActive(true);
            TileMapaDeactivate.SetActive(false);
            if (!hasDropped)
            {
                FindObjectOfType<DropManager>().Drop("WhiteGauntlet", transform.position);
                hasDropped = true;
            }
            
        }
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
