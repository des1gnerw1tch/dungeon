using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chest : MonoBehaviour
{
    private Transform target;
    private IsNeerInteractable IsNeerInteractableScript;
    public string chestID;
    private Animator animator;
    public bool isActive = true;
    private DialogueTrigger dialogue;
    // Start is called before the first frame update!!!!
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        IsNeerInteractableScript = GameObject.FindGameObjectWithTag("Player").GetComponent<IsNeerInteractable>();
        animator = GetComponent<Animator>();
        dialogue = GetComponent<DialogueTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        if((Vector2.Distance(transform.position, target.position) < 3) && isActive){
              if(Input.GetKey("e")){
                Invoke("dropLoot", .2f);

                animator.SetBool("open", true);
                GetComponent<Collider2D>().enabled = false;
                isActive = false;
		      }
		}

    if (!isActive)  {
      animator.SetBool("open", true);
    }
    }

    void dropLoot() {
      FindObjectOfType<DropManager>().Drop(chestID, transform.position);
      FindObjectOfType<AudioManager>().Play("chest");
      Destroy(dialogue);
    }

}
