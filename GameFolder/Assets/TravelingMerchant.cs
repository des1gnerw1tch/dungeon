using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelingMerchant : MonoBehaviour
{
    private int counter = 0;
    // Start is called before the first frame update
    [SerializeField] private bool trig = false;
    [SerializeField] private GameObject shopObject;
    void Start()
    {
      counter = 0;
    }

    void OnTriggerEnter2D(Collider2D other) {
      if (other.CompareTag("Player")) {
        trig = true;
      }
    }

    void Update()  {

      if (Input.GetKeyDown(KeyCode.Space))  {
        counter += 1;
        if (counter == 2)  {
          shopObject.SetActive(true);
          GetComponent<BoxCollider2D>().enabled = false;
        }
      }

    }
}
