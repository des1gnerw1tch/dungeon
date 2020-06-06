using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering.Universal;

public class LevelManager : MonoBehaviour
{
    public GameObject mage;
    public Collider2D mageDialogueTrigger;
    public Transform magePos;
    public GameObject gift;
    public Text progressText;

    [HideInInspector]
    public int numOfGlobes;
    [HideInInspector]
    public int numCompleted = 0;

    void Start()  {
      Globe[] globes = FindObjectsOfType<Globe>();
      foreach (Globe globe in globes) {
        numOfGlobes++;
      }
      progressText.text = numCompleted + " / " + numOfGlobes;

      //if dungeon is completed
      if (PlayerProgress.wizardFreed) {
        progressText.text = numOfGlobes + " / " + numOfGlobes;
        mage.SetActive(false);
        foreach (Globe globe in globes) {
          globe.activated = true;
          globe.GetComponent<Animator>().SetBool("Completed", true);
          globe.GetComponent<Collider2D>().enabled = false;
          Color purple = new Color(.75f, 0, 1);
          globe.transform.GetChild(0).GetComponent<Light2D>().color = purple;
        }
      }
    }

    public void CompleteLevel()  {
      mageDialogueTrigger.enabled = false;
      Vector3 pos = new Vector3(magePos.position.x, magePos.position.y - 2f, 0f);
      Instantiate(gift, pos, Quaternion.identity);
      PlayerProgress.wizardFreed = true;
    }

    public void UpdateText()  {
      progressText.text = numCompleted + " / " + numOfGlobes;
    }
}
