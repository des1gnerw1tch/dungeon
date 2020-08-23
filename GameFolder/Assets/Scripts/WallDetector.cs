using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetector : MonoBehaviour
{
    [SerializeField]    private bool ShouldBounceOffSameType = false;

    private Animator animator;
    void Start() {
      animator = GetComponent<Animator>();
    }
    void OnCollisionStay2D(Collision2D other)  {
      if (!(other.gameObject.CompareTag("Player")) && other.gameObject.GetComponent<EnemyHealth>() == null && !ShouldBounceOffSameType) {
        animator.SetBool("isPatrolling", false);
      }else if (!(other.gameObject.CompareTag("Player")))
      {
            animator.SetBool("isPatrolling", false);
      }

    }
}
