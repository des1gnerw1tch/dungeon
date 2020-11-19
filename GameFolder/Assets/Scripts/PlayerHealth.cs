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
    private Inventory inventoryScript;
    private scroll scrollScript;
    private bool KeepItem = false;
    private GameObject player;
    public bool transported = false;
    // Start is called before the first frame update
    void Start()
    {
        //currentHealth = maxHealth;
        body = GetComponent<Tint>();
        healthBar.SetMaxHealth(maxHealth);
        rb = GetComponent<Rigidbody2D>();
        inventoryScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        scrollScript = GameObject.FindGameObjectWithTag("Player").GetComponent<scroll>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerProgress.blueCrystalDestroyed && PlayerProgress.redCrystalDestroyed && PlayerProgress.greenCrystalDestroyed)
        {
            KeepItem = true;
        }

        if(currentHealth <= 0){
            if (SceneManager.GetActiveScene().name == "3rdDoor")
            {

                for (int i = 0; i < inventoryScript.item.Length; i++)
                {
                    if (inventoryScript.item[i] == "CrystalGauntletRed" && !KeepItem)
                    {
                        scrollScript.activeSlot = i;
                        scrollScript.activeCanvasSlot.DestroyItem();
                        inventoryScript.item[i] = null;
                    }
                }

            }
            FindObjectOfType<GameSaveManager>().SavePlayer();
            //transfers to our salvage feature
            if (UnityEngine.Random.Range(1,10) == 1 && SceneManager.GetActiveScene().name != "Arena")
            {
                player = GameObject.FindWithTag("Player");
                player.GetComponent<PlayerHealth>().currentHealth = player.GetComponent<PlayerHealth>().maxHealth;
                Vector3 reset = new Vector3(-15, -5, 0);
                player.transform.position = reset;
                SceneManager.LoadScene("Arena");
                transported = true;
            }
            else
            {
                deathTransition.TransitionToScene("Death");
                transported = false;
            }



            //tries to stop music / footsteps
            try {
              FindObjectOfType<AudioManager>().Stop(FindObjectOfType<MusicPlayer>().themeName);
            }
            catch (NullReferenceException e){
                //Debug.Log("No music found to stop");
            }
            //tries to stop siren noise and footsteps
            FindObjectOfType<AudioManager>().Stop("siren");
            FindObjectOfType<AudioManager>().Stop("footsteps");

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
        
        //only play player hit sound when player is not dying
        if (currentHealth >= 0) {
          FindObjectOfType<AudioManager>().Play("playerHurt");
        }

    }

    public void SetKnockback(int knockback, Transform other) {

      GetComponent<PlayerMovement>().freezeMovement = true;
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
      GetComponent<PlayerMovement>().freezeMovement = false;
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
