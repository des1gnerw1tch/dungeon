using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goblinKing : MonoBehaviour
{
    [SerializeField] private EnemyHealth health;
    [SerializeField] private RuntimeAnimatorController phase2Animator;
    private bool phase2Triggered = false;

    // Update is called once per frame
    void Update()
    {
      if (health.GetHealth() <= health.maxHealth/2 && !phase2Triggered) {
        GetComponent<Animator>().runtimeAnimatorController = phase2Animator;
      }
    }
}
