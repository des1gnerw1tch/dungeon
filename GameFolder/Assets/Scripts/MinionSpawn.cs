
using UnityEngine;

public class MinionSpawn : MonoBehaviour
{
    public GameObject minion;
    public int minsPerSpawn;
    public float spawnInterval;
    private float counter;

    void Start()
    {
      counter = spawnInterval;
    }

    void Update()
    {

      if (counter > 0)  {
        counter -= Time.deltaTime;
      } else {
        Spawn();
        counter = spawnInterval;
      }

    }

    void Spawn()  {
      //spawns minions
      Vector2 pos = transform.position;
      for (int i = minsPerSpawn; i > 0 ; i--) {
        GameObject instance = Instantiate(minion, pos, Quaternion.identity);
        Animator animator = instance.GetComponent<Animator>();
        animator.SetBool("isPatrolling", true);
      }

    }
}
