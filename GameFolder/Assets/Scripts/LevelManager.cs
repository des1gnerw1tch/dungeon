using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject mage;
    public Collider2D mageDialogueTrigger;
    public Transform magePos;
    public GameObject gift;
    [HideInInspector]
    public int numOfGlobes;
    [HideInInspector]
    public int numCompleted = 0;

    void Start()  {
      Globe[] globes = FindObjectsOfType<Globe>();
      foreach (Globe globe in globes) {
        numOfGlobes++;
      }
    }

    public void CompleteLevel()  {
      mageDialogueTrigger.enabled = false;
      Vector3 pos = new Vector3(magePos.position.x, magePos.position.y - 2f, 0f);
      Instantiate(gift, pos, Quaternion.identity);
    }
}
