using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    Vector2 movement;
    Vector2 mousePos;

    Vector2 dashDir;

    // Update is called once per frame
    void Update()
    {
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
        if(Input.GetKey(KeyCode.LeftShift) && dashCooldown<=0f)
        {
            dashDir = movement;
            dashCooldown = 2f;
            dash = true;
        }

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    void FixedUpdate()
    {
        if (dash == true) {
            if (dashLength > 0f)
            {
                rb.velocity = dashDir * moveSpeed*3;
                dashLength -= (Time.fixedDeltaTime);
            }
            else
            {
                dash = false;
                dashLength = startDashLength;
            }
        }
        else
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
        if (dashCooldown > 0f)
        {
            dashCooldown -= Time.fixedDeltaTime;
        }
        
        //rb.MovePosition(rb.position + movement * (moveSpeed) * Time.fixedDeltaTime);
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 90;
        rb.rotation = angle;
    }

    public void SpeedBoost() {
      moveSpeed = 10f;
      Invoke("StopSpeedBoost", 10f);
    }

    void StopSpeedBoost() {
      moveSpeed = 5f;
    }

    public void StartSlowMode() {
      Time.timeScale = .5f;
      moveSpeed = 10f;
      Invoke("StopSlowMode", 8f);
      FindObjectOfType<AudioManager>().Play("focusStart");
    }

    void StopSlowMode() {
      Time.timeScale = 1f;
      moveSpeed = 5f;
      FindObjectOfType<AudioManager>().Play("focusEnd");
    }
}
