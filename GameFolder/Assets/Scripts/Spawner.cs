using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Transform target;
    private bool hasSpawned = false;
    public GameObject SpiderPrefab;
    Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        offset.Set(Random.Range(-10.0f, 10.0f) + 10, Random.Range(-10.0f, 10.0f) + 10, 0f);
    }
    void Spawn(){
        if(hasSpawned == false){
            GameObject Spider = Instantiate(SpiderPrefab, target.position - offset, target.rotation);
            hasSpawned = true;
		}
	}

    // Update is called once per frame
    void Update()
    {
        Invoke("Spawn",5f);
    }
}
