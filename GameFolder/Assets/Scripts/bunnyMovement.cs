using UnityEngine;

public class bunnyMovement : MonoBehaviour  {
    private bool moveState = true;
    private float speed;
    Vector2 destination;
    public Animator animator;

    void Start()  {
      destination.Set(transform.position.x, transform.position.y);
    }
    void Update()
    {
      if(moveState) {
        moveBunny();
      }

    }

    void moveBunny()  {
      if (Vector2.Distance(transform.position,destination) > .2f) {
        transform.position = Vector2.MoveTowards(transform.position, destination, 2 * Time.deltaTime);
        animator.SetFloat("Speed", speed);
      } else  {
        moveState = false;
        animator.SetFloat("Speed", 0f);
        Invoke("startMoving", Random.Range(3f, 8f));
        randomSpot();
      }
    }

    void randomSpot() {
      float x = Random.Range(transform.position.x -5, transform.position.x + 5);
      if (x < transform.position.x) {      
        speed = -1f;
      } else {
        speed = 1f;
      }
      float y = Random.Range(transform.position.y -5, transform.position.y + 5);
      destination.Set(x,y);
    }

    void startMoving()  {
      if (speed < 0f)  {
        animator.SetBool("lastMoveRight", false);
      } else {
        animator.SetBool("lastMoveRight", true);
      }
      moveState = true;
    }

}
