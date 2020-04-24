using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    private Transform target;
    private IsNeerInteractable IsNeerInteractableScript;
    public mobDrop loot;
    public Animator animator;
    public bool isActive = true;
    // Start is called before the first frame update!!!!
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        IsNeerInteractableScript = GameObject.FindGameObjectWithTag("Player").GetComponent<IsNeerInteractable>();
        animator = GetComponent<Animator>();
        loot = GameObject.FindGameObjectWithTag("lootData").GetComponent<mobDrop>();
    }

    // Update is called once per frame
    void Update()
    {
        if((Vector2.Distance(transform.position, target.position) < 3) && isActive){
              if(Input.GetKey("e")){
                Invoke("dropLoot", 1f);

                animator.SetTrigger("open");
                isActive = false;
		      }
		}

    }

    void dropLoot() {
      loot.ChestDrop(transform.position);
    }

}
