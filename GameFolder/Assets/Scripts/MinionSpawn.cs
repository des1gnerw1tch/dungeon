
using UnityEngine;
using System;

public class MinionSpawn : MonoBehaviour
{
    public GameObject minion;
    public int minsPerSpawn;
    public float spawnInterval;
    public string spawnSound;
    public Animator animator;
    private float counter;
    [SerializeField] private float offsetX = 0;
    [SerializeField] private float offsetY = 0;

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
      Vector2 pos = new Vector2(transform.position.x + offsetX, + transform.position.y + offsetY);
      for (int i = minsPerSpawn; i > 0 ; i--) {
        GameObject instance = Instantiate(minion, pos, Quaternion.identity);
        Animator animator = instance.GetComponent<Animator>();
        animator.SetBool("isPatrolling", true);
      }
      try {
        FindObjectOfType<AudioManager>().Play(spawnSound);
      }
      catch(NullReferenceException e) {

      }
      //this will set an animation to the thing that is spawning, if needed
      if (animator != null) {
        animator.SetTrigger("Spawn");
      }
    }
}
