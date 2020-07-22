using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth = 100;

    public HealthBar healthBar;
    private Tint body;
    private Rigidbody2D rb;
    public shakeCamera Camera;
    public CaveToMain deathTransition;

    [SerializeField]
    private float regenDuration = 15f;
    [SerializeField]
    private Animator regenEffectIcon;
    private bool regenEffect;
    private int regenTime = 15; //this effects how long it takes to regen health under effect. lower regen time = faster healing
    private float counter;
    // Start is called before the first frame update
    void Start()
    {
        //currentHealth = maxHealth;
        body = GetComponent<Tint>();
        healthBar.SetMaxHealth(maxHealth);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealth <= 0){
            //SceneManager.LoadScene("Death");

            deathTransition.TransitionToScene("Death");
            //currentHealth = maxHealth / 4;
            //SceneManager.LoadScene("Main");
            //Vector3 reset = new Vector3(24.35f, 22.94f, 0f);
            //transform.position = reset;

            //tries to stop music
            try {
              FindObjectOfType<AudioManager>().Stop(FindObjectOfType<MusicPlayer>().themeName);
            }
            catch (NullReferenceException e){
                //Debug.Log("No music found to stop");
            }

		    }
        healthBar.SetHealth(currentHealth);
        if(currentHealth > maxHealth){
            currentHealth = maxHealth;
		      }
          //regeneration effect
          if (regenEffect && currentHealth < maxHealth)  {
            counter += Time.deltaTime * 1000;
            if (counter >= regenTime)  {
              currentHealth += 1;
              counter = 0;
            }
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

    public void StartRegen()  {
      counter = 0;
      regenEffect = true;
      regenEffectIcon.gameObject.SetActive(true);
      Invoke("StopRegen", regenDuration);
      Invoke("WarnBoostEnd", regenDuration - 3f);
    }

    void StopRegen()  {
      regenEffect = false;
      regenEffectIcon.gameObject.SetActive(false);
    }

    void WarnBoostEnd() {
      regenEffect = false;
      regenEffectIcon.SetTrigger("Warning");
    }
}
