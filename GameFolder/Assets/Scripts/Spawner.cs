﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    private Transform target;
    public GameObject prefab;
    public float spawnTime;
    private float spawnTimeCounter;
    public int max;
    public int numAlive = 0;
    public float xDimension = 50f;
    public float yDimension = 50f;
    private EnemyHealth healthScript;

    Vector3 offset;
    Vector2 pos;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        healthScript = prefab.GetComponent<EnemyHealth>();
    }
    void Spawn()
    {


        pos.Set(Random.Range(transform.position.x-xDimension, transform.position.x + xDimension), Random.Range(transform.position.y - yDimension, transform.position.y + yDimension));
        if (Vector2.Distance(pos, target.position) > 10)  {
          GameObject Spider = Instantiate(prefab, pos, Quaternion.identity);
          numAlive++;

        } else {
          Debug.Log("Spawned inside the player :(");
          Spawn();
        }



	}

    // Update is called once per frame
    void Update()
    {



        if(spawnTimeCounter > 0){
              spawnTimeCounter -= Time.deltaTime;
		}
        if(spawnTimeCounter <= 0){

              if (numAlive < max) {
              Spawn();
              }
              spawnTimeCounter = spawnTime;
		}
    }
}
