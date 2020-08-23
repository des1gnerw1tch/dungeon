using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Check : StateMachineBehaviour
{
    private Transform target;
    public bool CheckPlayer;
    public int patrolWalkSpeed;
    private bool reachedPos = true;
    public int patrolArea = 5;
    public int sightRange = 7;
    public GameObject treeplacement;
    Vector2 pos;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (CheckPlayer)
        {
            pos.Set(target.position.x - animator.transform.position.x, target.position.y - animator.transform.position.y);
        }
        else
        {
            if ((reachedPos  && Random.Range(0,70) == 4)|| !animator.GetBool("isPatrolling"))
            {
                animator.speed = 1;
                int area = Random.Range(-patrolArea, patrolArea);
                pos.Set(animator.transform.position.x + area, animator.transform.position.y + Random.Range(-area, area));
                pos.Set(pos.x - animator.transform.position.x , pos.y - animator.transform.position.y);
                reachedPos = false;
                animator.SetBool("isPatrolling",true);
                //Debug.Log(patrolArea);
            }
            else
            {
                if (reachedPos)
                {
                    animator.speed =0;
                }
                
            }

            if (animator.transform.position.x == pos.x && animator.transform.position.y == pos.y)
            {
                reachedPos = true;
                
            }
            else
            {
                animator.transform.position = Vector2.MoveTowards(animator.transform.position, pos, patrolWalkSpeed * Time.deltaTime);
            }
            if (Vector2.Distance(animator.transform.position, target.position) < sightRange)
            {
                animator.SetBool("seenPlayer", true);
            }
        }
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
