using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : StateMachineBehaviour
{
    private Transform target;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        Vector2 pos = new Vector2(target.position.x - animator.transform.position.x, target.position.y - animator.transform.position.y);
        /*if(pos.x < 0)
        {
            animator.SetFloat("Horizontal", -1);
        }
        else
        {
            animator.SetFloat("Horizontal", 1);
        }*/
        if (pos.y < 0 && Mathf.Abs(pos.y) > Mathf.Abs(pos.x))
        {
            animator.SetFloat("Vertical", -1);
            animator.SetFloat("Horizontal", 0);

        }
        else if (pos.y > 0 && Mathf.Abs(pos.y) > Mathf.Abs(pos.x))
        {
            animator.SetFloat("Vertical", 1);
            animator.SetFloat("Horizontal", 0);

        }
        else if (pos.x > 0 && Mathf.Abs(pos.y) < Mathf.Abs(pos.x))
        {
            animator.SetFloat("Horizontal", 1);
            animator.SetFloat("Vertical", 0);
        }

        else if (pos.x < 0 && Mathf.Abs(pos.y) < Mathf.Abs(pos.x))
        {
            animator.SetFloat("Horizontal", -1);
            animator.SetFloat("Vertical", 0);

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
