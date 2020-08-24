using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDetector : MonoBehaviour
{
    [SerializeField]    private bool ShouldBounceOffSameType = false;
    private bool isWaiting;
    private Animator animator;
    void Start() {
      animator = GetComponent<Animator>();
    }
    void OnCollisionStay2D(Collision2D other)  {
      if (!(other.gameObject.CompareTag("Player")) && other.gameObject.GetComponent<EnemyHealth>() == null && !ShouldBounceOffSameType) {
        animator.SetBool("isPatrolling", false);
      }else if (!other.gameObject.CompareTag("Player") && !isWaiting)
      {
            animator.SetBool("isPatrolling", false);
            StartCoroutine(waitTime());
      }

    }
    private IEnumerator waitTime()
    {
        isWaiting = true;
        animator.GetBehaviour<Check>().patrolWalkSpeed = 4;
        yield return new WaitForSeconds(.5f);
        animator.GetBehaviour<Check>().patrolWalkSpeed = 2;
        isWaiting = false;
    }
}
