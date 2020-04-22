using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goblinFollow : StateMachineBehaviour
{

    private Transform target;
    public float speed = 3f;
    public float lookRadius = 5f;
    public float atkRadius = 1f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      //follows if greater than attack radius
      if (Vector2.Distance(animator.transform.position, target.position) > atkRadius) {

        //actually moves the enemy towards the player
        animator.transform.position = Vector2.MoveTowards(animator.transform.position,
        target.position, speed * Time.deltaTime);

        //sets the animation direction the goblin should be walking
        float dx = target.position.x - animator.transform.position.x;
        float dy = target.position.y - animator.transform.position.y;

        //if horizontal is a good amount greater than vertical movement
        if (Mathf.Abs(dx) > Mathf.Abs(dy))  {
          if (dx > 0)  {
            animator.SetTrigger("trigR");
          } else {
            animator.SetTrigger("trigL");
          }
        }
        //if vertical movement is greater than horizontal movement
        else {
          if (dy > 0)  {
            animator.SetTrigger("trigU");
          } else  {
            animator.SetTrigger("trigF");
          }
        }


      }
      else {
        animator.SetBool("isAttacking", true);
      }
      //if out of look radius, reboots patrolling
        if (Vector2.Distance(animator.transform.position, target.position) > lookRadius) {
          animator.SetBool("followingPlayer", false);
          animator.SetBool("isPatrolling", true);
        }


    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      //on exit, triggers are reset so that direction can be picked
      animator.ResetTrigger("trigF");
      animator.ResetTrigger("trigU");
      animator.ResetTrigger("trigR");
      animator.ResetTrigger("trigL");
    }


}
