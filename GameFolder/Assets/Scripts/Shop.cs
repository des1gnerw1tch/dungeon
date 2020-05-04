using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public string ShopID;
    public int cost;
    private Transform target;
    private PlayerMoney PlayerMoneyScript;
    public mobDrop loot;
    public DialogueTrigger noMoneyDialogue;
    public DialogueTrigger boughtDialogue;
    //HealthDrops ID is "HealthPotion". the others are the same as the Gun ID in the inventory so Sniper,RPG, AR.
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        PlayerMoneyScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMoney>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, target.position) < 3){
            if(Input.GetKeyDown("e")){
              if (PlayerMoneyScript.coins >= cost) {
                loot.ShopDrop(ShopID, cost, transform.position);
                if (boughtDialogue != null) {
                  boughtDialogue.TriggerDialogue();
                }
              } else	{
            			FindObjectOfType<AudioManager>().Play("negative");
                  if (noMoneyDialogue != null)  {
                  noMoneyDialogue.TriggerDialogue();
                  }
            	}

		        }
		}

    }
}
