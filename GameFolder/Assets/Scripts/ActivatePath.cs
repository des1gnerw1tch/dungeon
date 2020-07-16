using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePath : MonoBehaviour
{
    public GameObject TileMapActivate;
    public GameObject TileMapaDeactivate;
    public static bool hasDropped = false;
    public bool ShouldDrop;
    public bool IgnorePlayer;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !ShouldDrop && !IgnorePlayer)
        {
            TileMapActivate.SetActive(true);
            if(TileMapaDeactivate != null)
            {
                TileMapaDeactivate.SetActive(false);
            }
            
            /*if (TileMapaDeactivate != null) { 
                TileMapaDeactivate.SetActive(false);
            }
            
            if (!hasDropped && ShouldDrop)
            {
                FindObjectOfType<DropManager>().Drop("WhiteGauntlet", transform.position);
                hasDropped = true;
            }*/

        }if(other.CompareTag("CrystalShot") && !ShouldDrop && IgnorePlayer)
        {
            TileMapActivate.SetActive(true);
            TileMapaDeactivate.SetActive(false);
        }
        
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKey("e"))
            {
                TileMapActivate.SetActive(true);
                if (TileMapaDeactivate != null)
                {
                    TileMapaDeactivate.SetActive(false);
                }

                if (!hasDropped && ShouldDrop)
                {
                    FindObjectOfType<DropManager>().Drop("WhiteGauntlet", transform.position);
                    hasDropped = true;
                }
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
