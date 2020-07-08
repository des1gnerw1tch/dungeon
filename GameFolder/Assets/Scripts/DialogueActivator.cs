using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueActivator : MonoBehaviour
{
    public GameObject[] DialogueTiggers;
    // Start is called before the first frame update
    public void ChangeDialogue()
    {

        DialogueTiggers[0].SetActive(false);
        DialogueTiggers[1].SetActive(false);
        DialogueTiggers[2].SetActive(true);
    }
}
