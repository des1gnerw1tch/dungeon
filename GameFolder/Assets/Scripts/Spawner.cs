using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Transform target;
    private bool hasSpawned = false;
    public GameObject SpiderPrefab;
    public float spawnTime;
    private float spawnTimeCounter;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
    }
    void Spawn()
    {
        offset.Set(Random.Range(-10.0f, 10.0f) + 10, Random.Range(-10.0f, 10.0f) + 10, 0f);
        GameObject Spider = Instantiate(SpiderPrefab, target.position - offset, target.rotation);
        
            
	}

    // Update is called once per frame
    void Update()
    {
        
        if(spawnTimeCounter > 0){
              spawnTimeCounter -= Time.deltaTime;
		}
        if(spawnTimeCounter <= 0){
              Spawn();
              spawnTimeCounter = spawnTime;
		}
    }
}
