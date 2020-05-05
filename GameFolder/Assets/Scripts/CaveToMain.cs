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
    public bool playSound;
    public Animator transition;
    public float transitionTime = 1f;
    // Start is called before the first frame update

    void Start()  {
      player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
      playerShootingScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Shooting>();
    }
    void OnTriggerEnter2D(Collider2D hitInfo) {

        if(hitInfo.gameObject.tag == "Player"){
          if(NeedsKey){
              if(neededKey == playerShootingScript.whatGunIsEquippedString){
                if (playSound)
                  FindObjectOfType<AudioManager>().Play("door");

                if (teleportToSetPosition)  {
                Vector2 newPosition = new Vector2(posX, posY);
                player.position = newPosition;
                }

                FindObjectOfType<DialogueManager>().EndDialogue();
                StartCoroutine(LoadLevel(sceneToLoad));
		      }else{

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
