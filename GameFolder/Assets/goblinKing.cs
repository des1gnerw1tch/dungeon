using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goblinKing : MonoBehaviour
{
    [SerializeField] private EnemyHealth health;
    [SerializeField] private RuntimeAnimatorController phase2Animator;
    [SerializeField] private Animator animator;
    [SerializeField] private float timeCrying;
    [SerializeField] private DialogueTrigger cryingDialogue;

    private bool phase2Triggered = false;

    // Update is called once per frame
    void Update()
    { // when goblin health is at half, activate second stage
      if (health.GetHealth() <= health.maxHealth/2 && !phase2Triggered) {
        cryingDialogue.TriggerDialogue();
        GetComponent<Animator>().runtimeAnimatorController = phase2Animator;
        StartCoroutine(StopCrying());
        phase2Triggered = true;
      }
    }

    //this is how long he will be invincible for, and also crying
    IEnumerator StopCrying() {
      yield return new WaitForSeconds(timeCrying);
      animator.SetTrigger("stopCrying");
    }
}
