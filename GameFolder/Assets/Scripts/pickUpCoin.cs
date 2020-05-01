using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class pickUpCoin : MonoBehaviour
{
    private PlayerMoney PlayerMoneyScript;
    // Start is called before the first frame update
    void Start()
    {
        PlayerMoneyScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMoney>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other){
        if  (other.CompareTag("Player")){
            PlayerMoneyScript.coins += 10;
            FindObjectOfType<AudioManager>().Play("coin");
            Destroy(gameObject);
        }

    }
}
