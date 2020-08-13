using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class butterfly : MonoBehaviour
{
    private Transform player;
    [SerializeField]
    private float despawnDistance;
    // Start is called before the first frame update
    void Start()
    {
      player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
      Vector2 butterfly = new Vector2(transform.position.x, transform.position.y);
      Vector2 playerPos = new Vector2(player.position.x, player.position.y);
      if (Mathf.Abs(Vector2.Distance(butterfly, playerPos)) > despawnDistance)  {
        Destroy(this.gameObject);
      }
    }
}
