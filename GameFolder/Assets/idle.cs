using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idle : StateMachineBehaviour
{
    private float timer;
    public float radius = 5f;
    private Transform target;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      timer = Random.Range(6f, 10f);
      target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      if (timer > 0)  {
        timer -= Time.deltaTime;
      } else {
        animator.SetBool("isMoving", true);
      }

      /* seen player? */
      if (Vector2.Distance(animator.transform.position, target.position) < radius )
      {
         animator.SetBool("seenPlayer", true);
      }
    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }




}
