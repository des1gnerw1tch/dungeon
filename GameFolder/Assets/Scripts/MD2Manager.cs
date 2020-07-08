using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MD2Manager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject bossTeleporter;
    [SerializeField] private GameObject completedDialogue;
    void Start()
    {
        UpdateScene();
    }

    // Update is called once per frame
    void UpdateScene()
    {
      if (PlayerProgress.nurseFreed)  {
        bossTeleporter.SetActive(false);
        completedDialogue.SetActive(true);
      } else {
        bossTeleporter.SetActive(true);
        completedDialogue.SetActive(false);
      }
    }
}
