using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    private Queue<string> sentances;


    void Start()
    {
        sentances = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue){

        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;
        sentances.Clear();

        foreach(string sentance in dialogue.sentances){
            sentances.Enqueue(sentance);

		}

        DisplayNextSentance();
	}
    public void DisplayNextSentance(){
        if(sentances.Count == 0){
            EndDialogue();
            return;
		}
        string sentance = sentances.Dequeue();
        FindObjectOfType<AudioManager>().Play("next");
        //dialogueText.text = sentance;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentance));
    }

    IEnumerator TypeSentence(string sentance){
        dialogueText.text = "";
        foreach(char letter in sentance.ToCharArray()){
            dialogueText.text += letter;
            yield return null;
		}
	}
    public void EndDialogue(){
        animator.SetBool("IsOpen", false);
	}

  void Update() {
    if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space key was pressed.");
            DisplayNextSentance();
        }
  }
}
