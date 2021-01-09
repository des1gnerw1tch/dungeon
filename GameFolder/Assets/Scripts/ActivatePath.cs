using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ActivatePath : MonoBehaviour
{
    public GameObject TileMapActivate;
    public GameObject TileMapaDeactivate;
    public static bool hasDropped = false;
    public bool ShouldDrop;
    public bool IgnorePlayer;
    public string sound = null;
    public bool shouldDestroy;
    public bool isBlueCrystal;
    public bool isRedCrystal;
    public bool isGreenCrystal;
    public string bulletTag = "CrystalShot";
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
            Debug.Log("Scanned Path");
            AstarPath.active.Scan();
            /*if (TileMapaDeactivate != null) {
                TileMapaDeactivate.SetActive(false);
            }

            if (!hasDropped && ShouldDrop)
            {
                FindObjectOfType<DropManager>().Drop("WhiteGauntlet", transform.position);
                hasDropped = true;
            }*/

        }if(other.CompareTag(bulletTag) && !ShouldDrop && IgnorePlayer)
        {
            TileMapActivate.SetActive(true);
            TileMapaDeactivate.SetActive(false);
            if (sound != null)
              //FindObjectOfType<AudioManager>().Play(sound);

            //saving variables
            if (isBlueCrystal)  {
              PlayerProgress.blueCrystalDestroyed = true;
              FindObjectOfType<AudioManager>().Play("crystalBreak");
              FindObjectOfType<GameSaveManager>().SavePlayer();
              AstarPath.active.Scan();
              }
            if (isGreenCrystal)  {
              PlayerProgress.greenCrystalDestroyed = true;
              FindObjectOfType<AudioManager>().Play("crystalBreak");
              FindObjectOfType<GameSaveManager>().SavePlayer();
            }
            if (isRedCrystal)  {
              PlayerProgress.redCrystalDestroyed = true;
              FindObjectOfType<AudioManager>().Play("crystalBreak");
              FindObjectOfType<GameSaveManager>().SavePlayer();
            }


            if (shouldDestroy)  {
              Destroy(this. gameObject);
            }
        }

    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !IgnorePlayer)
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
                    /*white WhiteGauntlet should always drop. otherwise, if someone misses it the first time, they
                    would not be able to get it again...*/
                    hasDropped = true;
                }
            }


        }
    }
    void Start()
    {
      hasDropped = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
