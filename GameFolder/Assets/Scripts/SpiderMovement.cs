using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMovement : MonoBehaviour
{
    public float spiderSpeed = 5f;
    public Rigidbody2D rb;
    private Transform target;
    public Animator animator;
    //public Camera cam;

    Vector2 mousePos;

    // Update is called once per frame
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {
        if(Vector2.Distance(transform.position, target.position) > 3)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, spiderSpeed * Time.deltaTime);
            animator.SetFloat("IsClose", -1);
        }
        else
        {
            animator.SetFloat("IsClose", 1);
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
