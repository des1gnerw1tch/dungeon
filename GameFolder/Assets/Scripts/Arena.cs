using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Arena : MonoBehaviour
{
    public GameObject[] Spawners;
    private int counter = 0;
    public Text WaveText;
    public GameObject WaveUI;
    public bool lootgiven = false;
    public bool WaveCompleted = true;
    public DialogueActivator DialogueActivatorScript;
    public GameObject DialogueNextWave;
    // Start is called before the first frame update
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKey("e") && WaveCompleted)
        {
            if(lootgiven)
            {
                Spawners[counter].SetActive(true);
                lootgiven = false;
                WaveCompleted = false;

            }
            else
            {
                FindObjectOfType<DropManager>().Drop("ArenaEnd", transform.position);
                int num = counter + 1;
                WaveText.text = "Wave " + num;
                lootgiven = true;
                DialogueActivatorScript.ChangeDialogue();
                DialogueNextWave.SetActive(false);
            }
            
            WaveUI.SetActive(true);
        }

    }
    void Update()
    {
        if(Spawners[counter].GetComponent<Spawner>().numAlive == Spawners[counter].GetComponent<Spawner>().max)
        {
            if(counter < Spawners.Length - 1)
            {
                Spawners[counter].SetActive(false);
                DialogueNextWave.SetActive(true);
                counter += 1;
                WaveCompleted = true;
                
                //FindObjectOfType<DropManager>().Drop("ArenaEnd", transform.position);
                //Spawn loot at the tree
                //Spawners[counter].SetActive(true);
            }
            else
            {
                Debug.Log("end of Arena");
                //FindObjectOfType<DropManager>().Drop("ArenaEnd", transform.position);
                WaveUI.SetActive(false);
            }
            
        }
    }
}
