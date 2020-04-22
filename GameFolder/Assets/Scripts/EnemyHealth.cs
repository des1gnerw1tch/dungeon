using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public float maxHealth = 100;
    private float curHealth;
    public string enemyID;

    Vector2 pos;
    private bool hasDied = false;

    //scripts
    public mobDrop gunDrop;
    public Dissolve dissolve;
    public Tint tint;
    public Animator animator;

    void Start()
    {
        curHealth = maxHealth;
        pos.Set(0f, 0f);
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
       curHealth -= damage;
       tint.SetTintColor(new Color(1, 1, 1, 1f));
       /*when shot while idling, the enemy will move away (start patrolling). */
       if (animator != null)  {
         animator.SetBool("isPatrolling", true);
       }
       if(curHealth <= 0 && !hasDied){
        Die();
	   }
    }
    void Die()
    {
        hasDied = true;
        dissolve.play(2f);

        switch(enemyID) {
          case "Spider":
            gunDrop.SpiderDrop(transform.position);
            break;
          case "Goblin":
            //gunDrop.
            break;
        }

	   }

}
