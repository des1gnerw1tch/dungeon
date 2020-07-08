using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyHealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public Animator animator;
    private PlayerHealth PlayerHealthScript;

    void Start()
    {
        animator.SetBool("IsEnemy", true);
        PlayerHealthScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    public void SetEnemyMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "GoblinBossFight")
        {
            animator.SetBool("IsEnemy", true );
        }
    }

    public void SetEnemyHealth(float health)
    {

        slider.value = health;
        animator.SetBool("IsEnemy",false);
        
        if (health <= 0 || PlayerHealthScript.currentHealth <= 0)
        {
            animator.SetBool("IsEnemy", true);
        }
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

}