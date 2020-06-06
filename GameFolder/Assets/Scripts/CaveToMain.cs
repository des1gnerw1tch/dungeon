using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class CaveToMain : MonoBehaviour
{
    public string sceneToLoad;
    private Transform player;
    private GameObject playerObject;
    private VaultHolder vaultHolder;
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
    public bool continueMusic;
    // Start is called before the first frame update

    void Start()  {
      player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
      playerObject =   GameObject.FindGameObjectWithTag("Player");
      inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
      vaultHolder = FindObjectOfType<VaultHolder>();
    }
    void OnTriggerEnter2D(Collider2D hitInfo) {

        if(hitInfo.gameObject.tag == "Player"){
          if(NeedsKey){
            //finds the index of the needed key, if not found, it wont let you through the door
            int index = Array.IndexOf(inventory.item, neededKey);
              if(index > -1){
                if (playSound)
                  FindObjectOfType<AudioManager>().Play("door");

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

          }
        }

    }
    IEnumerator LoadLevel(string levelIndex){
        //vault bug solution
        if (levelIndex == "Main") {
          vaultHolder.EnableVault();
        } else {
          vaultHolder.DisableVault();
        }
        transition.SetTrigger("Start");
        playerObject.GetComponent<PlayerHealth>().enabled = false;
        playerObject.GetComponent<PlayerMovement>().enabled = false;
        yield return new WaitForSeconds(transitionTime);
        if (teleportToSetPosition)  {
          Vector2 newPosition = new Vector2(posX, posY);
          player.position = newPosition;
        }
        playerObject.GetComponent<PlayerHealth>().enabled = true;
        //playerObject.GetComponent<PlayerMovement>().enabled = true;
        if (!continueMusic) {
          try {
            FindObjectOfType<AudioManager>().Stop(FindObjectOfType<MusicPlayer>().themeName);
          }
          catch (NullReferenceException e){
            //Debug.Log("No music found to stop");
          }
        }
        SceneManager.LoadScene(levelIndex);
	}
}
