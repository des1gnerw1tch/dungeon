using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CaveToMain : MonoBehaviour
{
    public string sceneToLoad;
    private Transform player;
    private Shooting playerShootingScript;
    public bool teleportToSetPosition = false;
    public float posX;
    public float posY;
    public bool NeedsKey;
    public string neededKey;
    // Start is called before the first frame update

    void Start()  {
      player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
      playerShootingScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Shooting>();
    }
    void OnTriggerEnter2D(Collider2D hitInfo) {

        if(hitInfo.gameObject.tag == "Player"){
          if(NeedsKey){
              if(neededKey == playerShootingScript.whatGunIsEquippedString){
                FindObjectOfType<AudioManager>().Play("door");
                SceneManager.LoadScene(sceneToLoad);
                if (teleportToSetPosition)  {
                Vector2 newPosition = new Vector2(posX, posY);
                player.position = newPosition;
                }
		      }else{

			  }

		  }else{
            SceneManager.LoadScene(sceneToLoad);
            if (teleportToSetPosition){
            Vector2 newPosition = new Vector2(posX, posY);
                player.position = newPosition;
		    }

          }
        }

    }
}
