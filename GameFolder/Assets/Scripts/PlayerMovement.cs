using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UIElements;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    /*note: moveSpeed is changed to 5f after talking with some NPC's, when changing moveSpeed,
    you will need to change the move speed in the NPC's scripts too*/
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Camera cam;
    public Animator animator;
    public bool dash = false;
    public float dashCooldown;
    public float dashLength;
    public float startDashLength;
    [SerializeField] private Animator speedEffectIcon;
    public float speedBoostLength = 10f;
    [SerializeField] private Animator focusEffectIcon;
    public float focusEffectLength = 8f;
    public GameObject dashParts;
    public Slider StaminaSlider;

    Vector2 movement;
    Vector2 mousePos;

    Vector2 dashDir;

    // Update is called once per frame
    void Update()
    {
        StaminaSlider.value = dashCooldown;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Speed",Mathf.Abs(movement.y));
        animator.SetFloat("HSpeed", Mathf.Abs(movement.x));

        movement = movement.normalized;
        /*if (Input.GetAxisRaw("Horizontal") != 0
        || Input.GetAxisRaw("Vertical") != 0)  {
          FindObjectOfType<AudioManager>().Play("footsteps");
        }*/
        //Dash Function
        if(Input.GetKey(KeyCode.LeftShift) && dashCooldown >= 2f)
        {
            dashDir = movement;
            dashCooldown = 0f;
            dash = true;
            animator.SetBool("Dash", true);
        }

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    void FixedUpdate()
    {
        if (dash == true) {
            if (dashLength > 0f)
            {
                rb.velocity = dashDir * moveSpeed*3;
                GameObject Temp = Instantiate(dashParts, transform.position, transform.rotation);
                Destroy(Temp, 1);
                dashLength -= (Time.fixedDeltaTime);

            }
            else
            {
                dash = false;
                dashLength = startDashLength;
                animator.SetBool("Dash", false);
            }
        }
        else
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
        if (dashCooldown < 2f)
        {
            dashCooldown += Time.fixedDeltaTime;
        }

        //rb.MovePosition(rb.position + movement * (moveSpeed) * Time.fixedDeltaTime);
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 90;
        rb.rotation = angle;
    }

    public void SpeedBoost() {
      moveSpeed = 10f;
      speedEffectIcon.gameObject.SetActive(true);
      Invoke("StopSpeedBoost", speedBoostLength);
      Invoke("WarnBoostEnd", speedBoostLength - 3f);
    }

    void StopSpeedBoost() {
      moveSpeed = 5f;
      speedEffectIcon.gameObject.SetActive(false);
    }

    void WarnBoostEnd() {
      speedEffectIcon.SetTrigger("Warning");
    }

    public void StartSlowMode() {
      Time.timeScale = .5f;
      moveSpeed = 10f;
      focusEffectIcon.gameObject.SetActive(true);
      Invoke("StopSlowMode", focusEffectLength);
      Invoke("WarnFocusEnd", focusEffectLength - 3f);
      FindObjectOfType<AudioManager>().Play("focusStart");
    }

    void StopSlowMode() {
      Time.timeScale = 1f;
      moveSpeed = 5f;
      focusEffectIcon.gameObject.SetActive(false);
      FindObjectOfType<AudioManager>().Play("focusEnd");
    }

    void WarnFocusEnd() {
      focusEffectIcon.SetTrigger("Warning");
    }
}
