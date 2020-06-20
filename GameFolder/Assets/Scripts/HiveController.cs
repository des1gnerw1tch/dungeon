using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiveController : MonoBehaviour
{
    public MinionSpawn minionSpawn;
    private Transform target;
    public float spawnRadius;
    public Color GizmosColor = new Color(0.5f, 0.5f, 0.5f, 0.2f);
    // Update is called once per frame
    void Start()  {
      target = FindObjectOfType<PlayerHealth>().GetComponent<Transform>();
    }

    void Update()
    {
    //  Debug.Log(Vector2.Distance(new Vector2 (target.position.x, target.position.y), new Vector2(transform.position.x, transform.position.y)));
      if (Vector2.Distance(new Vector2 (target.position.x, target.position.y), new Vector2(transform.position.x, transform.position.y)) < spawnRadius) {
        minionSpawn.enabled = true;
      } else {
        minionSpawn.enabled = false;
      }
    }

    void OnDrawGizmos() {
      Gizmos.color = GizmosColor;
      Gizmos.DrawWireCube(transform.position, new Vector2(spawnRadius, spawnRadius) * 2);
    }
}
