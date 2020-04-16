using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : StateMachineBehaviour
{
    private Transform target;
    //public float spiderSpeed = 3f;
    public float pounceSpeed = 20f;
    public float lifeTimeFirstAttack = 5f;
    public float lifeTimeAttack = 5f;
    private bool hasAttacked = false;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if(lifeTimeFirstAttack > 0){
            lifeTimeFirstAttack -= Time.deltaTime;


		}
        if (lifeTimeFirstAttack <= 0){
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, target.position, pounceSpeed * Time.deltaTime);
            animator.SetFloat("IsClose", -1);
            lifeTimeFirstAttack = lifeTimeAttack;
        }




           //Attack();



      //void Attack() {

	    //}
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

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
