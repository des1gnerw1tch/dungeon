﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadPatrol : StateMachineBehaviour
{
    Vector2 destination;
    private float timer;
    public float radius = 5f;
    private Transform target;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = Random.Range(6f, 10f);
        float x = Random.Range(animator.transform.position.x - 100, animator.transform.position.x + 100);
        float y = Random.Range(animator.transform.position.y - 100, animator.transform.position.y + 100);
        destination.Set(x, y);
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        /* timer to stop moving */
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, destination, 2 * Time.deltaTime);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

        /* seen player? */
        
        if (Vector2.Distance(animator.transform.position, target.position) < radius)
        {
            float dy = target.position.y - animator.transform.position.y;
            if (dy > 0)
            {
                animator.SetBool("seenPlayerUp", true);
            }
            else
            {
                animator.SetBool("seenPlayerDown", true);
            }

        }






    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}