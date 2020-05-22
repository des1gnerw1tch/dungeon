using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAwayWhenLight : StateMachineBehaviour
{
    private Vector2 Player;
    private Vector2 LightRunner;
    private Vector2 Differance;
    private Vector2 Direction;
    private Transform target;
    public float lookRad;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Player.Set(target.position.x, target.position.y);
        LightRunner.Set(animator.transform.position.x, animator.transform.position.y);
        Differance = LightRunner - Player;
        Differance = Differance.normalized;
        if(Vector2.Distance(animator.transform.position, target.position) < lookRad)
        {

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
