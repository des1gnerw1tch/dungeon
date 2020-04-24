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
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        body = GetComponent<Tint>();
        healthBar.SetMaxHealth(maxHealth);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0){
            SceneManager.LoadScene("GameOver");
		    }
        healthBar.SetHealth(currentHealth);
        if(currentHealth > maxHealth){
            currentHealth = maxHealth;
		}
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

    public void SetKnockback(int knockback, Transform other) {
      GetComponent<PlayerMovement>().enabled = false;
      int thrust = knockback;
      Vector2 difference = transform.position - other.transform.position;
      difference = difference.normalized * thrust;
      rb.AddForce(difference, ForceMode2D.Impulse);
      Debug.Log("Player knocked back with " + knockback + " amount of force!" +
      "difference" + difference + " thrust : " + thrust);
      Invoke ("startMovement", .3f);
    }

    void startMovement()  {
      GetComponent<PlayerMovement>().enabled = true;
    }
}
