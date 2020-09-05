using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelingMerchant : MonoBehaviour
{
    private int counter = 0;
    // Start is called before the first frame update
    [SerializeField] private bool trig = false;
    [SerializeField] private GameObject shopObject;
    [SerializeField] private DialogueTrigger notice;
    void Start()
    {
      counter = 0;
      //starts dialogue late, not on start because of bug where dialogue isn't shown
      StartCoroutine(StartDialogue());
    }

    void OnTriggerEnter2D(Collider2D other) {
      if (other.CompareTag("Player")) {
        trig = true;
      }
    }

    void OnTriggerExit2D(Collider2D other) {
      if (other.CompareTag("Player")) {
        trig = false;
      }
    }

    void Update()  {

      if (trig) {
        if (Input.GetKeyDown(KeyCode.Space))  {
          counter += 1;
          if (counter == 2)  {
            //activates the shop after a certain amount of dialogue presses
            shopObject.SetActive(true);
            //disables the dialogue collider so that merchant does not repeat greeting
            GetComponent<BoxCollider2D>().enabled = false;
          }
        }
    }

    }

    IEnumerator StartDialogue() {
      yield return new WaitForSeconds(1);
      FindObjectOfType<AudioManager>().Play("coin");
      notice.TriggerDialogue();
    }
}
