using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldManager : MonoBehaviour
{
    public BoxCollider2D dialogueCollider;
    public BoxCollider2D portalCollider;
    //public PlayerProgress progress;
    // Start is called before the first frame update
    void Start()
    {

      if (PlayerProgress.wizardFreed) {
        dialogueCollider.enabled = false;
        portalCollider.enabled = true;
      } else {
        dialogueCollider.enabled = true;
        portalCollider.enabled = false;
      }
    }

    // Update is called once per frame
    public void UpdateScene()
    {
      if (PlayerProgress.wizardFreed) {
        dialogueCollider.enabled = false;
        portalCollider.enabled = true;
      } else {
        dialogueCollider.enabled = true;
        portalCollider.enabled = false;
      }

      Debug.Log("Scene UPdated");
    }
}
