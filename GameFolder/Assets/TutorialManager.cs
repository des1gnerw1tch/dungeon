using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TutorialManager : MonoBehaviour
{
  private int counter;
  [SerializeField] private GameObject sentence2;
  [SerializeField] private GameObject sentence3;
  [SerializeField] private GameObject minimap;
  [SerializeField] private GameObject sentence4;

  // Update is called once per frame
  void Update()
  {
      if (Input.GetKeyDown(KeyCode.Space))
      {
          counter += 1;
          switch (counter)  {
            case 1:
              //show 2nd sentence
              sentence2.SetActive(true);
              FindObjectOfType<AudioManager>().Play("blip");
              break;
            case 2:
              //show third sentence
              sentence3.SetActive(true);
              minimap.SetActive(true);
              FindObjectOfType<AudioManager>().Play("blip");
              break;
            case 3:
              //show fourth sentence
              sentence4.SetActive(true);
              FindObjectOfType<AudioManager>().Play("blip");
              break;
            case 4:
              FindObjectOfType<AudioManager>().Play("blip");
              SceneManager.LoadScene("Main");
              break;
          }
      }

  }
}
