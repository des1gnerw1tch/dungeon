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
    public float dashCooldown = 0f;
    public float dashLength = 1f;

    Vector2 movement;
    Vector2 mousePos;


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
        /*if(Input.GetKeyDown("left shift") && dashCooldown<=0f)
        {
            dashCooldown = 2f;
            dash = true;
        }
        */
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    void FixedUpdate()
    {
        /*while (dash == true) {

        }
        */
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        dashCooldown -= Time.fixedDeltaTime;
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg +90;
        rb.rotation = angle;
    }
}
