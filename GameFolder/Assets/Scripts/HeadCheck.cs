using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCheck : StateMachineBehaviour
{
    private Transform target;
    public float radius = 5;
    public bool isConductor;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float dy = target.position.y - animator.transform.position.y;
        if (dy > 0)
        {
            animator.SetFloat("Vertical", 1);
        }
        else
        {
            animator.SetFloat("Vertical", -1);
        }
        if ((Vector2.Distance(animator.transform.position, target.position) > radius) && isConductor)
        {
            animator.SetFloat("Speed", 0);
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
