using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0){
            SceneManager.LoadScene("GameOver");
		    }
        healthBar.SetHealth(currentHealth);
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;


    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EnemyHealth enemy = hitInfo.GetComponent<EnemyHealth>();

        if(enemy != null){
            TakeDamage(10);
		}


    }
}
