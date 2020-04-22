using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goblinPatrol : StateMachineBehaviour
{

    private float timer;

    public float lookRadius = 5f;
    public float speed = 2f;
    public float minWaitTime = 1f;
    public float maxWaitTime = 7f;
    Vector2 destination;
    private Transform target;
     //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      timer = Random.Range(minWaitTime, maxWaitTime);

      destination.Set(animator.GetFloat("destX"), animator.GetFloat("destY"));
      target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      /*timer to stop moving*/
      if (timer > 0)  {
        timer -= Time.deltaTime;
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, destination, speed * Time.deltaTime);
      } else  {
        animator.SetBool("isPatrolling", false);
      }

      /* seen player? */
      if (Vector2.Distance(animator.transform.position, target.position) < lookRadius )
      {
         animator.SetBool("followingPlayer", true);
      }

    }



}
