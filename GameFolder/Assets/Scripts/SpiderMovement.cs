using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMovement : MonoBehaviour
{
    public float spiderSpeed = 5f;
    public float pounceSpeed = 0f;
    public Rigidbody2D rb;
    private Transform target;
    public Animator animator;
    private bool hasHit = false;
    //public Camera cam;

    Vector2 mousePos;
    Vector3 attackPosition;
    Vector3 attackTarget;
    // Update is called once per frame
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {
        Vector3 attackPosition = transform.position;
        Vector3 attackTarget = target.position;
        //Move the Spider towards the player IsClose is the animation variable name so i can switch between the attack animation and the chase animation
        if (Vector2.Distance(transform.position, target.position) > 3 || hasHit == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, spiderSpeed * Time.deltaTime);
           
            animator.SetFloat("IsClose", -1);
            
        }
        else
        {
            animator.SetFloat("IsClose", 1);
            transform.position = Vector2.MoveTowards(attackPosition, attackTarget, pounceSpeed * Time.deltaTime);
            hasHit = true;
        }

        mousePos.Set(target.position.x, target.position.y);
        //mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    void FixedUpdate()
    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg -90;
        rb.rotation = angle;
    }
}
