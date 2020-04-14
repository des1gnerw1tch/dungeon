using UnityEngine;

public class bunnyMovement : MonoBehaviour
{
    private bool isMoving = false;
    Vector2 destination;

    void Start()  {
      destination.Set(transform.position.x, transform.position.y);
    }
    void Update()
    {
      if (Vector2.Distance(transform.position,destination) > .2f) {
        transform.position = Vector2.MoveTowards(transform.position, destination, 2 * Time.deltaTime);
        isMoving = true;
      } else  {
        isMoving = false;
      }

      /*if (transform.position.x == destination.x && transform.position.y == destination.y) {
        isMoving = false;
      }*/

      if (!isMoving) {
        Debug.Log("called");
        //Invoke("randomMovement", 4);
        randomMovement();
        isMoving = true;
      }


    }
    void randomMovement() {

      destination.Set(Random.Range(transform.position.x -15, transform.position.x + 15)
      , Random.Range(transform.position.y -15, transform.position.y + 15));

      //isMoving = false;
    }

}
