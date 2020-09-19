using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class pickUpCoin : MonoBehaviour
{
    private PlayerMoney PlayerMoneyScript;
    private Transform player;
    [SerializeField]
    private float magnetSpeed;
    [SerializeField]
    private float magnetDistance;
    // Start is called before the first frame update
    void Start()
    {
        PlayerMoneyScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMoney>();
        player = FindObjectOfType<PlayerMovement>().gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()  {
      if (Vector2.Distance(new Vector2(transform.position.x, transform.position.y), new Vector2(player.position.x, player.position.y)) < magnetDistance) {
        transform.position = Vector3.MoveTowards(transform.position, player.position, magnetSpeed* Time.fixedDeltaTime) ;
      }
    }
    void OnTriggerEnter2D(Collider2D other){
        if  (other.CompareTag("Player")){
            PlayerMoneyScript.coins += 1;
            FindObjectOfType<AudioManager>().Play("coin");
            Destroy(gameObject);
        }

    }
}
