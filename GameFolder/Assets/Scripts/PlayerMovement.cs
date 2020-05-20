using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Camera cam;
    public Animator animator;
    public bool running = false;
    public float stamina = 10f;

    Vector2 movement;
    Vector2 mousePos;


    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        //Still feels a little choppy, but also works, maybe fix camera while running?
        if (Input.GetKey(KeyCode.LeftShift) && stamina>1f)
        {
            running = true;
            stamina -= 1f;
        }
        else if (stamina > 10f)
        {
            stamina = 10f;
        }
        else
        {
            stamina += .4f;
        }
        animator.SetFloat("Speed",Mathf.Abs(movement.y));
        animator.SetFloat("HSpeed", Mathf.Abs(movement.x));

        movement = movement.normalized;
        /*if (Input.GetAxisRaw("Horizontal") != 0
        || Input.GetAxisRaw("Vertical") != 0)  {
          FindObjectOfType<AudioManager>().Play("footsteps");
        }*/
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    void FixedUpdate()
    {
        if (running == true && stamina>1f){
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime * 2);
            running = false;
        }
        else
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg +90;
        rb.rotation = angle;
    }
}
