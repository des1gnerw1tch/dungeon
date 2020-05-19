using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    Spawner[] spawners;
    EnemyHealth[] enemies;
    public int maxEnemies;
    void Start()
    {
        spawners = FindObjectsOfType<Spawner>();
    }

    // Update is called once per frame
    void Update()
    {
      enemies = FindObjectsOfType<EnemyHealth>();
      if (enemies.Length >= maxEnemies) {
        foreach(Spawner s in spawners)  {
          s.enabled = false;
        }
      } else {
        foreach(Spawner s in spawners)  {
          s.enabled = true;
        }
      }
    }
}
