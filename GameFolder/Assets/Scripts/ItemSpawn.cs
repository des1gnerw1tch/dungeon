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
        Vector2 playerpos = new Vector2(player.position.x, player.position.y + 2);
        Instantiate(item, playerpos, Quaternion.identity);
	}
}
