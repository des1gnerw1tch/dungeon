using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goblinIdle : StateMachineBehaviour
{
    private float timer;
    public float lookRadius = 5f;
    private Transform target;
    public float minWalkTime = 1f;
    public float maxWalkTime = 7f;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      timer = Random.Range(minWalkTime, maxWalkTime);
      target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      if (timer > 0)  {
        timer -= Time.deltaTime;
      } else {
        animator.SetBool("isPatrolling", true);
      }

      /* seen player? */
      if (Vector2.Distance(animator.transform.position, target.position) < lookRadius )
      {
         //animator.SetBool("followingPlayer", true);
      }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
﻿
