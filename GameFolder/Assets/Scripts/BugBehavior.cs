using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugBehavior : MonoBehaviour
{
    [SerializeField] private Animator animator;
    void OnCollisionEnter2D(Collision2D other)  {
      if (other.gameObject.CompareTag("Player")) {
      animator.SetTrigger("cooldown");
      }
    }
}
