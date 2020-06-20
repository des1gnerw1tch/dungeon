using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TDRotation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private Transform target;
    [SerializeField] private Rigidbody2D rb;

    /*this script will correctly position the top down mob when patrolling and
    also when in attack state. */
    void Start()
    {
      target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void FixedUpdate()  {
        //if is following player
        if (animator.GetBool("followingPlayer")) {
          Vector2 targetVector = new Vector2(target.position.x, target.position.y);
          Vector2 lookDir = targetVector - rb.position;
          float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 90;
          rb.rotation = angle;
        }
        //if is patrolling
        else if (animator.GetBool("isPatrolling"))  {
          Vector2 targetVector = new Vector2(animator.GetFloat("destX"), animator.GetFloat("destY"));
          Vector2 lookDir = targetVector - rb.position;
          float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 90;
          rb.rotation = angle;
        }

    }
}
