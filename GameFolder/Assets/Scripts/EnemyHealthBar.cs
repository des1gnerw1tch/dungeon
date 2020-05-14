using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public Animator animator;

    public void SetEnemyMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetEnemyHealth(float health)
    {

        slider.value = health;
        animator.SetBool("IsEnemy",false);
        if(health <= 0)
        {
            animator.SetBool("IsEnemy", true);
        }
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}