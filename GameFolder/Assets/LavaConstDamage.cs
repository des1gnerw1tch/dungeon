using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaConstDamage : MonoBehaviour
{
    private bool ShouldCauseDamage = true;
    [SerializeField] private int damage;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyHealth>() != null && ShouldCauseDamage) {
            StartCoroutine(CauseDamage(collision));
        }
    }
    private IEnumerator CauseDamage(Collider2D other)
    {
        ShouldCauseDamage = false;
        other.GetComponent<EnemyHealth>().TakeDamage(damage, false);
        yield return new WaitForSeconds(.3f);
        ShouldCauseDamage = true;
    }
}
