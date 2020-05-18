using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeletonAttack : StateMachineBehaviour
{
  public float atkRadius = 1f;

  private Transform target;
  private PlayerHealth player;
  public GameObject projectile;

  public float atkCooldown = 2f;
  public int atkDamage = 10;
  public int knockback = 0;

  private float timer;
  override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  {
    target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    timer = 0;
    Debug.Log("started attack");
  }


  override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  {
    //if outside attack radius
    if (Vector2.Distance(animator.transform.position, target.position) > atkRadius) {
      animator.SetBool("isAttacking", false);
    }
    //when inside attack radius
    else {
      if (timer > 0)  {
        timer -= Time.deltaTime;
      } else {
        //player.TakeDamage(atkDamage);
      //  player.SetKnockback(knockback, animator.transform);
        Vector3 pos = new Vector3(animator.transform.position.x, animator.transform.position.y, 0f);
        GameObject instance = Instantiate(projectile, pos, Quaternion.identity);
        Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
        Debug.Log((target.position - animator.transform.position).normalized * 100);
        rb.AddForce((target.position - animator.transform.position).normalized * 10, ForceMode2D.Impulse);

        timer = atkCooldown;
      }
    }

  }


  override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  {

  }
}
