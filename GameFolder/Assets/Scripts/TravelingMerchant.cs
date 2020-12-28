using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelingMerchant : MonoBehaviour
{
    private int counter = 0;
    private bool trig = false;
    [SerializeField] private GameObject shopObject;
    [SerializeField] private DialogueTrigger notice;
    [SerializeField] private Shop shop;
    [SerializeField] private DialogueTrigger costDialogue;
    [SerializeField] private GameObject[] itemDrops;
    [SerializeField] private int[] itemCost;
    [SerializeField] private BoxCollider2D triggerCollider;


    void Start()
    {
      counter = 0;
      //starts dialogue late, not on start because of bug where dialogue isn't shown
      StartCoroutine(StartDialogue());


      MerchantTimer merchantTimer = FindObjectOfType<MerchantTimer>();
      /*this will pick the random item for the shop and set the dialogue.
      if this is first visit, have it sell a chosen item FIRST*/

      if (merchantTimer.firstVisit)  {

        //this will make sure fairy bow is picked every time on first merchant!
        int itemNum = 3;
        shop.prefab = itemDrops[itemNum];
        shop.cost = itemCost[itemNum];
        costDialogue.dialogue.sentances[0] = "Today I am selling a " + itemDrops[itemNum].GetComponent<PickUp>().inventoryID + " for " +
        itemCost[itemNum]  + " coins. Press 'e' to buy";

        merchantTimer.firstVisit = false;
      } else {
      int rand = Random.Range(0, itemDrops.Length);
      shop.prefab = itemDrops[rand];
      shop.cost = itemCost[rand];
      costDialogue.dialogue.sentances[0] = "Today I am selling a " + itemDrops[rand].GetComponent<PickUp>().inventoryID + " for " +
        itemCost[rand]  + " coins. Press 'e' to buy";
      }
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
            triggerCollider.enabled = false;
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
