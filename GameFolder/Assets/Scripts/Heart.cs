using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    private Transform player;
    [SerializeField]
    private float magnetSpeed;
    [SerializeField]
    private float magnetDistance;
    void Start()  {
      player = FindObjectOfType<PlayerMovement>().gameObject.GetComponent<Transform>();
    }
    void OnTriggerEnter2D(Collider2D other) {
      if(other.CompareTag("Player"))  {
        FindObjectOfType<PlayerHealth>().currentHealth += 20;
        FindObjectOfType<AudioManager>().Play("Heart");
        Destroy(gameObject);
      }
    }

    void FixedUpdate()  {
      if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(player.position.x, player.position.y)) < magnetDistance) {
        transform.position = Vector3.MoveTowards(transform.position, player.position, magnetSpeed* Time.fixedDeltaTime) ;
        magnetSpeed += Time.deltaTime * 3; //will increase speed the longer it is latched on
      }
    }
}
