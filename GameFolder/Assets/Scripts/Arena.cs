using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Arena : MonoBehaviour
{
    public GameObject[] Spawners;
    public GameObject[] infiniteSpawner;
    private int counter = 0;
    public int inCounter = 0;
    public Text WaveText;
    public GameObject WaveUI;
    public bool lootgiven = false;
    public bool WaveCompleted = true;
    public DialogueActivator DialogueActivatorScript;
    public GameObject DialogueNextWave;
    public bool infiniteLoopActivated = false;
    // Start is called before the first frame update
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKey("e") && WaveCompleted)
        {
            
            if (infiniteLoopActivated)
            {
                for (int i = 0; i < infiniteSpawner.Length; i++)
                {
                    infiniteSpawner[i].GetComponent<Spawner>().numAlive = 0;
                    infiniteSpawner[i].GetComponent<Spawner>().max = inCounter;
                    
                }
                FindObjectOfType<DropManager>().Drop("ArenaEnd", transform.position);
                FindObjectOfType<DropManager>().Drop("ArenaEnd", transform.position);
                WaveCompleted = false;
                inCounter++;
                WaveText.text = "Hard: Wave " + inCounter;
                DialogueActivatorScript.ChangeDialogue();
            }
            else
            {
                if (lootgiven)
                {
                    Spawners[counter].SetActive(true);
                    lootgiven = false;
                    WaveCompleted = false;

                }
                else
                {
                    FindObjectOfType<DropManager>().Drop("ArenaEnd", transform.position);
                    int num = counter + 1;
                    WaveText.text = "Easy: Wave " + num;
                    lootgiven = true;
                    DialogueActivatorScript.ChangeDialogue();
                    DialogueNextWave.SetActive(false);
                }
            }
            WaveUI.SetActive(true);
        }

    }
    void Update()
    {
        if((Spawners[counter].GetComponent<Spawner>().numAlive == Spawners[counter].GetComponent<Spawner>().max) && !infiniteLoopActivated)
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
                Debug.Log("Switch");
                infiniteLoopActivated = true;
                //FindObjectOfType<DropManager>().Drop("ArenaEnd", transform.position);
                
                //DialogueNextWave.SetActive(false);
            }
            
            
        }
        if (infiniteLoopActivated)
        {
            if (WaveCompleted)
            {
                DialogueNextWave.SetActive(true);
            }
            else
            {
                DialogueNextWave.SetActive(false);
            }
                for (int i = 0; i < infiniteSpawner.Length; i++)
                {
                    infiniteSpawner[i].SetActive(true);
                    
                    if (infiniteSpawner[i].GetComponent<Spawner>().numAlive == infiniteSpawner[i].GetComponent<Spawner>().max)
                    {
                        WaveCompleted = true; 
                    }
                }
            
            
            
            
        }
    }
}
