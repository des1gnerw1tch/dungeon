
using UnityEngine;

public class chestSpawn : MonoBehaviour
{
    public GameObject chestPrefab;
    [Range(0f, 1f)]
    public float chanceOfSpawn;
    void Start()
    {
      float num = Random.Range(0f, 1f);
      if (num < chanceOfSpawn)  {
        Instantiate(chestPrefab, transform.position, Quaternion.identity);
      }
    }



}
