using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    private Transform target;
    public Animator animator;

    //private bool hasHit = false;
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


        mousePos.Set(target.position.x, target.position.y);
    }
    void FixedUpdate()
    {
      if (animator.GetBool("seenPlayer")) {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg -90;
        rb.rotation = angle;
      }
    }
}
