using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TutorialManager : MonoBehaviour
{
  private int counter;
  [SerializeField] private GameObject sentence1;
  [SerializeField] private GameObject sentence2;
  [SerializeField] private GameObject sentence3;
  [SerializeField] private GameObject TutCan;
  [SerializeField] private GameObject sentence4;
    [SerializeField] private GameObject space;

    public bool sequencePassed;
  // Update is called once per frame
  void Update()
  {
        if (sequencePassed)
        {
            space.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                counter += 1;
                switch (counter)
                {
                    case 1:
                        //show 2nd sentence
                        sentence2.SetActive(true);
                        FindObjectOfType<AudioManager>().Play("blip");
                        sentence1.SetActive(false);
                        sequencePassed = false;
                        space.SetActive(false);
                        break;
                    case 2:
                        //show third sentence
                        sentence3.SetActive(true);
                        FindObjectOfType<AudioManager>().Play("blip");
                        sentence2.SetActive(false);
                       
                        break;
                    case 3:
                        //show fourth sentence
                        sentence4.SetActive(true);
                        FindObjectOfType<AudioManager>().Play("blip");
                        sentence3.SetActive(false);
                        
                        break;
                    case 4:
                        TutCan.SetActive(false);
                        FindObjectOfType<AudioManager>().Play("blip");
                        sequencePassed = false;
                        break;
                }
            }
        }
  }
}
