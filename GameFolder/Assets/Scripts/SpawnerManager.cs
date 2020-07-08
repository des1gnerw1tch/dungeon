using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    Spawner[] spawners;
    EnemyHealth[] enemies;
    public int maxEnemies;
    public int currentEnemies;
    void Start()
    {
        spawners = FindObjectsOfType<Spawner>();
    }

    // Update is called once per frame
    void Update()
    {
      //very badly optimized i think
      enemies = FindObjectsOfType<EnemyHealth>();
      currentEnemies = enemies.Length;
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
