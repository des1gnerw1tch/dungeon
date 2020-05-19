using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skeletonAttack : StateMachineBehaviour
{
  public float atkRadius = 1f;

  private Transform target;
  private PlayerHealth player;
  public GameObject projectile;
  public float projectileSpeed;

  public float atkCooldown = 2f;

  private float timer;
  override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  {
    target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    timer = 0;
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

        Vector3 pos = new Vector3(animator.transform.position.x, animator.transform.position.y, 0f);
        GameObject instance = Instantiate(projectile, pos, Quaternion.identity);
        Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();

        //push the projectile
        Vector3 force = (target.position - animator.transform.position).normalized * projectileSpeed;
        //make sure bullet is facing the right direction
        if (target.position.x - animator.transform.position.x >=0)  {
          instance.transform.Rotate(0, 0, (Mathf.Atan(force.y / force.x)) * Mathf.Rad2Deg + 90, Space.Self);
        } else {
          instance.transform.Rotate(0, 0, (Mathf.Atan(force.y / force.x)) * Mathf.Rad2Deg + 270, Space.Self);
        }

        rb.AddForce(force, ForceMode2D.Impulse);

        timer = atkCooldown;
      }
    }

  }


  override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  {

  }
}
