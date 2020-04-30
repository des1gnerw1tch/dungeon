using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CaveToMain : MonoBehaviour
{
    public string sceneToLoad;
    private Transform player;
    public bool teleportToSetPosition = false;
    public float posX;
    public float posY;
    // Start is called before the first frame update

    void Start()  {
      player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void OnTriggerEnter2D(Collider2D hitInfo) {

    if(hitInfo.gameObject.tag == "Player"){
          SceneManager.LoadScene(sceneToLoad);
          if (teleportToSetPosition)  {
            Vector2 newPosition = new Vector2(posX, posY);
            player.position = newPosition;
          }
      }

    }
}
