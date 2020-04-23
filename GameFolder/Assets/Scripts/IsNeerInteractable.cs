using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IsNeerInteractable : MonoBehaviour
{
    public bool isNeerInteractable;
    public Text InteractText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isNeerInteractable){
            InteractText.text = "Press E to interact.";
		}else{
            InteractText.text = "";
		}
    }
    void OnTriggerEnter2D(Collider2D other){
        Chest ChestScript = other.GetComponent<Chest>();
        if(ChestScript != null) {
            if(ChestScript.isActive){
                isNeerInteractable = true;         
			}
		}
		
	}
    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "Interactable"){
              isNeerInteractable = false;
		}
	}
}
