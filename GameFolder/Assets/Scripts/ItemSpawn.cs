using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawn : MonoBehaviour
{
    public GameObject item;
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
	}
    public void SpawnDroppedItem(){
        Vector2 playerPos = new Vector2(player.position.x, player.position.y);
        Vector2 pushPos = player.up*(-2);
        //Instantiate(item, playerPos + pushPos, Quaternion.identity);

        GameObject instance = Instantiate(item, playerPos + (pushPos / 6), Quaternion.identity);
        instance.GetComponent<PickUp>().wasDropped = true;
        Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
        rb.AddForce(pushPos * 10, ForceMode2D.Impulse);

	}
}
