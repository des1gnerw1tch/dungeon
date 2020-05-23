using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    /*The shop ID should match the string of the item that it wants to drop*/
    public GameObject prefab;
    public int cost;
    private Transform target;
    private PlayerMoney PlayerMoneyScript;
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
                Instantiate(prefab, transform.position, Quaternion.identity);
                PlayerMoneyScript.coins -= cost;
                if (boughtDialogue != null) {
                  boughtDialogue.TriggerDialogue();
                  FindObjectOfType<AudioManager>().Play("coin");
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
