using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.CoreModule;

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
    public Color GizmosColor = new Color(0.5f, 0.5f, 0.5f, 0.2f);
    Vector3 spawnRadius;
    Vector3 offset;
    Vector2 pos;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        healthScript = prefab.GetComponent<EnemyHealth>();
        spawnRadius.Set(xDimension,yDimension,0f);
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
    void OnDrawGizmos()
    {
        Gizmos.color = GizmosColor;
        Gizmos.DrawCube(transform.position,spawnRadius);
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
