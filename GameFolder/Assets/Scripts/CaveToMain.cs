using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class CaveToMain : MonoBehaviour
{
    public string sceneToLoad;
    private Transform player;
    //private Shooting playerShootingScript;
    private Inventory inventory;
    public bool teleportToSetPosition = false;
    public float posX;
    public float posY;
    public bool NeedsKey;
    public string neededKey;
    public bool playSound;
    public Animator transition;
    public float transitionTime = 1f;
    // Start is called before the first frame update

    void Start()  {
      player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
      inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
      //playerShootingScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Shooting>();
    }
    void OnTriggerEnter2D(Collider2D hitInfo) {

        if(hitInfo.gameObject.tag == "Player"){
          if(NeedsKey){
            //finds the index of the needed key, if not found, it wont let you through the door
            int index = Array.IndexOf(inventory.item, neededKey);
              if(index > -1){
                if (playSound)
                  FindObjectOfType<AudioManager>().Play("door");

                if (teleportToSetPosition)  {
                Vector2 newPosition = new Vector2(posX, posY);
                player.position = newPosition;
                }

                FindObjectOfType<DialogueManager>().EndDialogue();
                StartCoroutine(LoadLevel(sceneToLoad));
		           }else{
                 /*executed when key is not found!*/
			         }

		  }else{
            FindObjectOfType<DialogueManager>().EndDialogue();
            StartCoroutine(LoadLevel(sceneToLoad));
            if (playSound)
              FindObjectOfType<AudioManager>().Play("door");
            if (teleportToSetPosition){
            Vector2 newPosition = new Vector2(posX, posY);
                player.position = newPosition;
		    }

          }
        }

    }
    IEnumerator LoadLevel(string levelIndex){
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
	}
}
