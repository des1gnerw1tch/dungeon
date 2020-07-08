using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chooseDestination : StateMachineBehaviour
{

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      float dx = Random.Range( -100, 100);
      float dy = Random.Range( -100, 100);
      //makes sure that goblin runs in the right direction
      animator.SetFloat("destX", animator.transform.position.x + dx);
      animator.SetFloat("destY", animator.transform.position.y + dy);

      //if horizontal is a good amount greater than vertical movement
      if (Mathf.Abs(dx) - Mathf.Abs(dy) > -20)  {
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

}
