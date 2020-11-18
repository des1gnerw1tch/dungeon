using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goblinAttack : StateMachineBehaviour
{
    public float atkRadius = 1f;

    private Transform target;
    private PlayerHealth player;

    public float atkCooldown = 2f;
    public int atkDamage = 10;
    public int knockback = 0;

    private float timer;
    private bool attackedOnce = false;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
      player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
      timer = 0;
      attackedOnce = false;
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      //if outside attack radius
      if (Vector2.Distance(animator.transform.position, target.position) > atkRadius && attackedOnce) {
        animator.SetBool("isAttacking", false);
      }
      //when inside attack radius
      else {
        if (timer > 0)  {
          timer -= Time.deltaTime;
        } else {
          player.TakeDamage(atkDamage);
          player.SetKnockback(knockback, animator.transform);
          timer = atkCooldown;
          attackedOnce = true;
        }
      }


    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }


}
