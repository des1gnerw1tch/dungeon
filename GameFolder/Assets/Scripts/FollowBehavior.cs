using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBehavior : StateMachineBehaviour
{

    private Transform target;
    public float spiderSpeed = -3f;
    public float AttackDistance;
    public float radius = 5f;
    public float lookRad = 5f;
    private ItemManager ItemManagerScript;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        ItemManagerScript = GameObject.FindGameObjectWithTag("ItemManager").GetComponent<ItemManager>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (Vector2.Distance(animator.transform.position, target.position) > AttackDistance )
        {
           animator.transform.position = Vector2.MoveTowards(animator.transform.position, target.position, spiderSpeed * Time.deltaTime);

        }
        else
        {
           animator.SetFloat("IsClose", 1);

        }
        /*back to patrol*/
        if  (Vector2.Distance(animator.transform.position, target.position) > radius) {
          animator.SetBool("seenPlayer", false);
        }
        if ((Vector2.Distance(animator.transform.position, target.position) < lookRad) && (ItemManagerScript.itemString == "Torch"))
        {
            animator.SetBool("HasTorch", true);
        }

    }


    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
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
