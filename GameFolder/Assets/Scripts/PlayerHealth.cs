using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;
    public Tint body;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        body = GetComponent<Tint>();
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

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        body.SetTintColor(new Color (1, 0, 0, 1f));

    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EnemyHealth enemy = hitInfo.GetComponent<EnemyHealth>();


        if(enemy != null){
            TakeDamage(10);
		        }
    }
}
