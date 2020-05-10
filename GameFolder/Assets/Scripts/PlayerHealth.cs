using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;
    private Tint body;
    private Rigidbody2D rb;
    public shakeCamera Camera;
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
            //SceneManager.LoadScene("GameOver");
            currentHealth = maxHealth;
            SceneManager.LoadScene("Main");
            Vector3 reset = new Vector3(24.35f, 22.94f, 0f);
            transform.position = reset;
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
        Camera.shake(5f, 2f, .3f);
        FindObjectOfType<AudioManager>().Play("playerHurt");

    }

    public void SetKnockback(int knockback, Transform other) {

      GetComponent<PlayerMovement>().enabled = false;
      int thrust = knockback;
      Vector2 difference = transform.position - other.transform.position;
      difference = difference.normalized * thrust;
      rb.AddForce(difference, ForceMode2D.Impulse);


    }

    //this is for knockback, will start movement again once finished knocking back
    void FixedUpdate()  {
      if (rb.velocity.magnitude < 1 )  {
        startMovement();
      }
    }

    void startMovement()  {
      GetComponent<PlayerMovement>().enabled = true;
    }
}
